--
-- Author: donglizhang2011@126.com
-- Date: 2014-09-23 18:16:58
-- 不带优先级的选择节点
-- 子节点的前提，要保证“互斥”
-- 例 子1：a > 10, 子2：a >= 2 且 a <= 10, 子3：a < 2

ZDLNodeNonePrioritySelector = class("ZDLNodeNonePrioritySelector", ZDLNodePrioritySelector)

function ZDLNodeNonePrioritySelector:ctor(parent,precondition)
	ZDLNodeNonePrioritySelector.super.ctor(self,parent,precondition);
end

-----------------------------------------------
-----------------------------------------------
-----------------重写父类的函数------------------
-----------------------------------------------

function ZDLNodeNonePrioritySelector:doEvaluate(input)
	-- 不带优先级的话，会首先看当前的节点是否满足条件，不满足重头找
	if self:checkIndex(self.currentSelectIndex) then
		local childNode = self.children[self.currentSelectIndex];
		if(childNode and childNode:evaluate(input)) then
			return true;
		end
	end

	-- 调用父类，重头找
	return ZDLNodeNonePrioritySelector.super.doEvaluate(self,input);
	
end

return ZDLNodeNonePrioritySelector