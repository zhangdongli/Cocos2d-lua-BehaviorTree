--
-- Author: donglizhang2011@126.com
-- Date: 2014-09-20 17:22:41
-- 节点基类

ZDLTreeNode = class("ZDLTreeNode")

--[[
	* 行为数默认参数，需要外部调用
]]
function ZDLTreeNode.initBehaviorTreeParam()

	--子节点最大个数
	k_BLimited_MaxChildNodeCnt = 16

	-- 最小下标
	k_BLimited_MinChildNodeIndex = -1;

	--节点执行状态
	ZDLRunningStatus = {
		k_BRS_Executing = 0, --执行中
		k_BRS_Finish = 1, --执行完毕
		k_BRS_ERROR_Transition = -1 --转化失败
	}

	--行为节点的状态
	ZDLTerminalNodeStaus = {
		k_TNS_Ready   = 1,--准备执行
		k_TNS_Running = 2,--执行中
		k_TNS_Finish  = 3--执行完成
	};

	--是否是调试模式
	k_DEBUG_FLAG = GameInfo.TestAI;
end

--[[
	* 构造函数
	* name string 节点名称
	* parent ZDLTreeNode 父亲节点
	* precondition ZDLNodePrecondition 进入前提
]]
function ZDLTreeNode:ctor(parent,precondition)
	-- initBehaviorTreeParam();

	self.name = nil;	
	self.parent = parent;--父亲节点
	self.activeNode = nil;
	self.lastActiveNode = nil;
	self.nodePrecondition = precondition;--进入条件	
	self.children = {};--子节点集合
end

-----------------------------------------------
-----------------------------------------------
-------------------对外接口---------------------
-----------------------------------------------

--[[
	* 获取节点名称
]]
function ZDLTreeNode:getName()
	return self.name;
end

--[[
	* 设置节点名称
	* newName string 新名称
]]
function ZDLTreeNode:setName(newName)	
	self.name = newName;
end

--[[
	* 设置新的进入条件
	* newPrecondition ZDLNodePrecondition 进入条件
]]
function ZDLTreeNode:setNodePrecondition(newPrecondition)	
	self.nodePrecondition = newPrecondition;
end

--[[
	* 获取最后激活的节点
]]
function ZDLTreeNode:getLastActiveNode()
	return self.lastActiveNode;
end

--[[
	* 设置激活的节点
	* activeNode ZDLTreeNode 要激活的节点
]]
function ZDLTreeNode:setActiveNode(activeNode)
	self.lastActiveNode = self.activeNode;
	self.activeNode = activeNode;
	if(self.parent)then
		self.parent:setActiveNode(activeNode);
	end
end

--[[
	* 添加子节点
	* childNode ZDLTreeNode 子节点
]]
function ZDLTreeNode:addChildNode(childNode)
	if(#self.children >= k_BLimited_MaxChildNodeCnt)then
		---- print("ZDLTreeNode:addChildNode:最多包含16个子节点")
		return;
	end
	self.children[#self.children + 1] = childNode;
end

--[[
	* 边界判定
]]
function ZDLTreeNode:checkIndex(index)
	return index > 0 and index <= #self.children;
end

-----------------------------------------------
-----------------决策相关接口--------------------
-----------------------------------------------

--[[
	* 检测是否满足条件
]]
function ZDLTreeNode:evaluate(inputParam)
	return self.nodePrecondition == nil or self.nodePrecondition:externalCondition(inputParam) and self:doEvaluate(inputParam);	
end

--[[
	* 转化到下一个节点
]]
function ZDLTreeNode:transition(inputParam)
    self:doTransition(inputParam);
end

--[[
	* 获取执行状态
]]
function ZDLTreeNode:tick(inputParam,outputParam)	
    return self:doTick(inputParam,outputParam);
end


-----------------------------------------------
-----------------------------------------------
--------------需要子类重写的函数------------------
-----------------------------------------------

--[[
	* 条件判定
]]
function ZDLTreeNode:doEvaluate(inputParam)	
	return true;
end


--[[
	* 转化到下一节点之前的处理
]]
function ZDLTreeNode:doTransition(inputParam)

end

--[[
	* 每次执行事件
]]
function ZDLTreeNode:doTick(inputParam,outputParam)
	return ZDLRunningStatus.k_BRS_Finish;
end


return TreeNode;