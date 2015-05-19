--
-- Author: donglizhang2011@126.com
-- Date: 2014-09-23 18:10:11
-- 顺序节点

ZDLNodeSequence = class("ZDLNodeSequence", ZDLTreeNode)

function ZDLNodeSequence:ctor(parent,precondition)
	ZDLNodeSequence.super.ctor(self,parent,precondition);

	-- 当前正在执行的子节点下标，默认为 -1
	self.currentNodeIndex = k_BLimited_MinChildNodeIndex;
end

-----------------------------------------------
-----------------------------------------------
-----------------重写父类的函数------------------
-----------------------------------------------

function ZDLNodeSequence:doEvaluate(input)
	-- 默认为-1
	local tmpNode = k_BLimited_MinChildNodeIndex;
	
	-- 如果当前子节点为 -1 
	if self.currentNodeIndex == k_BLimited_MinChildNodeIndex then
		-- 选择第一个子节点
		tmpNode = 1; 
	else
		-- 选择当前的子节点
		tmpNode = self.currentNodeIndex;
	end

	if self:checkIndex(tmpNode) then
		local childNode = self.children[tmpNode];
		--查看是否可以进入
		if childNode:evaluate(input) then
			return true;--可以进入
		end
	end

	return false;--不可以
end

function ZDLNodeSequence:doTransition(input)
	if self:checkIndex(self.currentNodeIndex) then
		local childNode = self.children[self.currentNodeIndex];
		childNode:transition(input)
	end	
	self.currentNodeIndex = k_BLimited_MinChildNodeIndex;
end

function ZDLNodeSequence:doTick(input,output)
	-- 默认为完成
	local state = ZDLRunningStatus.k_BRS_Finish;

	-- 如果没有选择子节点默认选择第一个
	if self.currentNodeIndex == k_BLimited_MinChildNodeIndex then
		self.currentNodeIndex = 1;
	end

	-- 执行子节点的 tick
	local childNode = self.children[self.currentNodeIndex]
	state = childNode:tick(input,output);

	-- 如果子节点完成
	if state == ZDLRunningStatus.k_BRS_Finish then
		-- 在指向下一个子节点
		self.currentNodeIndex = self.currentNodeIndex + 1;

		-- 如果到头了
		if self.currentNodeIndex == #self.children + 1 then
			-- 复位
			self.currentNodeIndex = k_BLimited_MinChildNodeIndex
		else
			--没到头，表示还在执行
			state = ZDLRunningStatus.k_BRS_Executing;	
		end		
	end

	-- 如果状态为错误
	if state < ZDLRunningStatus.k_BRS_Executing then
		--复位
		self.currentNodeIndex = k_BLimited_MinChildNodeIndex
	end

	return state;
	
end

return ZDLNodeSequence