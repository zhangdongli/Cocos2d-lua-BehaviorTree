--
-- Author: donglizhang2011@126.com
-- Date: 2014-09-23 17:04:16
-- 带优先级的选择节点

-- 子节点的优先级从左向右，一个比一个更高
-- 例如 子1-->10, 子2-->8, 子3-->6

-- 子节点的前提从左向右，一个比一个更严格
-- 例如 子1：a > 5 且 a < 10, 子2：a > 0 且 a < 20, 子3：a == 任何值

ZDLNodePrioritySelector = class("ZDLNodePrioritySelector",ZDLTreeNode)

function ZDLNodePrioritySelector:ctor(parent,precondition)
	
	ZDLNodePrioritySelector.super.ctor(self,parent,precondition);

	-- 当前执行的子节点下标，默认-1
	self.currentSelectIndex = k_BLimited_MinChildNodeIndex;
	-- 上一个执行的子节点下标，默认-1
	self.lastSelectIndex = k_BLimited_MinChildNodeIndex;
end

-----------------------------------------------
-----------------------------------------------
-----------------重写父类的函数------------------
-----------------------------------------------

function ZDLNodePrioritySelector:doEvaluate(input)		
	self.currentSelectIndex = k_BLimited_MinChildNodeIndex;	
	
	--重头遍历子节点，有一个条件为真，执行这个。
	--注意开始的位置优先级最高，因为每次会开始查找
	if(self.children and #self.children > 0) then		
		for i,childNode in ipairs(self.children) do
			if childNode:evaluate(input) then
				self.currentSelectIndex = i;
				return true;
			end
		end
	end
	return false;
end

function ZDLNodePrioritySelector:doTransition(input)
	if self:checkIndex(self.lastSelectIndex) then
		local childNode = self.children[self.lastSelectIndex];
		childNode:transition(input)
	end
	self.lastSelectIndex = k_BLimited_MinChildNodeIndex;
end

function ZDLNodePrioritySelector:doTick(input,output)

	local state = ZDLRunningStatus.k_BRS_Finish;

	-- 如果上一次和当前不一样
	-- 那么transition上一次
	-- 上一次指向当前
	if self:checkIndex(self.currentSelectIndex) then
		if self.lastSelectIndex ~= self.currentSelectIndex then
			if self:checkIndex(self.lastSelectIndex) then
				local childNode = self.children[self.lastSelectIndex];
				childNode:transition(input);				
			end
			self.lastSelectIndex = self.currentSelectIndex;
		end
	end

	-- 现在上一次指向了当前（如果执行了上边的-.-）
	-- 执行当前tick
	if self:checkIndex(self.lastSelectIndex) then				
		local childNode = self.children[self.lastSelectIndex];
		state = childNode:tick(input,output);		
		if state == ZDLRunningStatus.k_BRS_Finish then
			self.lastSelectIndex = k_BLimited_MinChildNodeIndex;
		end
	end

	return state;
end

return ZDLNodePrioritySelector