--
-- Author: donglizhang2011@126.com
-- Date: 2014-09-24 11:30:35
-- 创建节点工厂类

ZDLNodeFactory = class("ZDLNodeFactory")

--[[
	* 单例，获取实例
]]
local factoryObj = nil;
function ZDLNodeFactory.getInstance()
	if factoryObj == nil then
		factoryObj = ZDLNodeFactory.new();
	end
	return factoryObj;
end

function ZDLNodeFactory:ctor()
	NodeClass = {
		["ZDLNodePrioritySelector"]=ZDLNodePrioritySelector,
		["ZDLNodeNonePrioritySelector"]=ZDLNodeNonePrioritySelector,
		["ZDLNodeSequence"]=ZDLNodeSequence,
		["ZDLNodeParallel"]=ZDLNodeParallel,
		["ZDLNodeLoop"]=ZDLNodeLoop,
		
		-- 每添加一个自定义节点记得这儿要加上
		
	};

	PreconditionClass = {
		["ZDLNodePreconditionAND"]=ZDLNodePreconditionAND,
		["ZDLNodePreconditionFALSE"]=ZDLNodePreconditionFALSE,
		["ZDLNodePreconditionNOT"]=ZDLNodePreconditionNOT,
		["ZDLNodePreconditionOR"]=ZDLNodePreconditionOR,
		["ZDLNodePreconditionTRUE"]=ZDLNodePreconditionTRUE,
		
		-- 每添加一个自定义条件记得这儿要加上
		
	};

	FactoryCache = {};
end

-------------------------------------------------------------------
-------------------------------------------------------------------
----------------------------公有函数--------------------------------
-------------------------------------------------------------------

--[[
	* 将json转化为一棵树
	* fullPath string json文件路径
	* 返回值 ZDLTreeNode 树的根节点
]]
function ZDLNodeFactory:createTreeByPath(fullPath)

	-- 从缓存里读取
	local treeTable = FactoryCache[tostring(fullPath)];

	if treeTable == nil then
		-- 从文件里读取json
		local jsonStr = self:getJsonByPath(fullPath);

		if jsonStr == nil then
			return nil;
		end
		-- 将json转化为table
		treeTable = json.decode(jsonStr);
		if treeTable == nil then
			return nil;
		end

		-- 加入缓存
		FactoryCache[tostring(fullPath)] = treeTable;
	end

	return self:createNode(nil,treeTable);
end

-------------------------------------------------------------------
-------------------------------------------------------------------
----------------------------私有函数--------------------------------
-------------------------------------------------------------------

function ZDLNodeFactory:getJsonByPath(fullPath)
	local res = cc.FileUtils:getInstance():getStringFromFile(fullPath)
	return res;
end

function ZDLNodeFactory:createNode(parent,nodeInfo)
	-- 取得信息
	local nodeType = nodeInfo["type"];
	local nodePrecondition = nodeInfo["precondition"];
	local nodeChilds = nodeInfo["child"];

	-- 取得条件
	local precondition = self:createPrecondition(nil,nodePrecondition);
	if precondition == nil then
		return nil;
	end

	-- 取得节点对应的类
	local nodeClass = NodeClass[nodeType];
	if nodeClass == nil then
		-- print("------------->>>>>节点错误：",nodeType);
		return nil;
	end

	-- 取得节点
	local node = nodeClass.new(parent,nil);
	
	-- 设置父子关系
	if parent ~= nil then
		parent:addChildNode(node);
	end

	-- 设置名称
	node:setName(nodeType);

	-- 设置条件
	node:setNodePrecondition(precondition);

	-- 添加子节点
	if nodeChilds ~= nil and table.nums(nodeChilds) > 0 then
		for i,nodeChild in ipairs(nodeChilds) do
			-- 递归创建子节点
			self:createNode(node,nodeChild);
		end
	end

	return node;
end

function ZDLNodeFactory:createPrecondition(parent,preconditionInfo)
	
	-- 取得信息
	local preconditionType = preconditionInfo["type"];
	local preconditionChilds = preconditionInfo["child"];

	-- 取得条件对应的类
	local preconditionClass = PreconditionClass[preconditionType];
	if preconditionClass == nil then
		-- print("------------->>>>>条件错误：",preconditionType);
		return nil;
	end

	-- 创建条件
	local precondition = nil;

	-- 如果不是复合条件
	if preconditionType ~= "ZDLNodePreconditionAND" 
		and preconditionType ~= "ZDLNodePreconditionNOT"
		and preconditionType ~= "ZDLNodePreconditionOR" then
		-- 从缓存里读取
		precondition = FactoryCache[preconditionType];
		if precondition == nil then
			precondition = preconditionClass.new();
			--加入缓存
			FactoryCache[preconditionType] = precondition;
		end
	else
		-- 直接 new
		precondition = preconditionClass.new();	
	end

	-- 设置父子关系
	if parent ~= nil then
		parent:addPrecondition(precondition);
	end

	-- 添加子条件
	if preconditionChilds ~= nil and table.nums(preconditionChilds) > 0 then
		for i,preconditionChild in ipairs(preconditionChilds) do
			-- 递归创建子条件
			self:createPrecondition(precondition,preconditionChild);
		end
	end

	return precondition;
end

return ZDLNodeFactory;