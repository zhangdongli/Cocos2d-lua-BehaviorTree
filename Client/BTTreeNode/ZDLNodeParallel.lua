--
-- Author: Zhang Dongli
-- Date: 2015-05-24 22:54:07
-- 并行节点

ZDLNodeParallel = class("ZDLNodeParallel", ZDLTreeNode);

function ZDLNodeParallel:ctor(parent,precondition)
	ZDLNodeParallel.super.ctor(self,parent,precondition);

	self.me_FinishCondition = ZDLParallelFinishCondition.k_PFC_OR;
	self.mab_ChildNodeStatus = {};
end

--[[
	* 设置结束条件
]]
function ZDLNodeParallel:setFinishCondition(end_Condition)
	self.me_FinishCondition = end_Condition;
end

-----------------------------------------------
-----------------------------------------------
-----------------重写父类的函数------------------
-----------------------------------------------

function ZDLNodeParallel:addChildNode(childNode)

	if(#self.children >= k_BLimited_MaxChildNodeCnt)then
		---- print("ZDLTreeNode:addChildNode:最多包含16个子节点")
		return;
	end
	ZDLNodeParallel.super.ctor(self,childNode);
	self.mab_ChildNodeStatus[#self.mab_ChildNodeStatus + 1] = ZDLRunningStatus.k_BRS_Executing;
end

function ZDLNodeParallel:doEvaluate(input)

	if(self.children and #self.children > 0) then		
		for i,childNode in ipairs(self.children) do
			if self.mab_ChildNodeStatus[i] == 0 then
				if not childNode:evaluate(input) then
					return false;
				end
			end
		end
	end
	return true;
end

function ZDLNodeParallel:doTransition(input)

	for i=1,#self.mab_ChildNodeStatus do
		self.mab_ChildNodeStatus[i] = ZDLRunningStatus.k_BRS_Executing;
	end

	for i,childNode in ipairs(self.children) do
		childNode:doTransition(input);
	end
end

function ZDLNodeParallel:doTick(input,output)
   
	local finishedChildCount = 0;  
	for i,childNode in ipairs(self.children) do
	
		if(self.me_FinishCondition == ZDLParallelFinishCondition.k_PFC_OR) then
		
			if(self.mab_ChildNodeStatus[i] == 0) then
				self.mab_ChildNodeStatus[i] = childNode:tick(input, output);
			end

			if(self.mab_ChildNodeStatus[i] ~= 0) then
				for i=1,#self.mab_ChildNodeStatus do
					self.mab_ChildNodeStatus[i] = ZDLRunningStatus.k_BRS_Executing;
				end
				return ZDLRunningStatus.k_BRS_Finish;
			end
		
		elseif(self.me_FinishCondition == ZDLParallelFinishCondition.k_PFC_AND) then
		
			if(self.mab_ChildNodeStatus[i] == ZDLRunningStatus.k_BRS_Executing) then
				self.mab_ChildNodeStatus[i] = childNode:tick(input, output);
			end

			if(self.mab_ChildNodeStatus[i] ~= k_BRS_Executing) then
			
				finishedChildCount = finishedChildCount + 1;
			end
		end
	end

	if(finishedChildCount == #self.children) then
		for i=1,#self.mab_ChildNodeStatus do
			self.mab_ChildNodeStatus[i] = ZDLRunningStatus.k_BRS_Executing;
		end
		return ZDLRunningStatus.k_BRS_Finish;
	end

	return ZDLRunningStatus.k_BRS_Executing;
end


return ZDLNodeParallel;
