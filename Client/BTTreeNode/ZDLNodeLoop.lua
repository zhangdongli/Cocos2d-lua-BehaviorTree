--
-- Author: Zhang Dongli
-- Date: 2015-05-24 23:42:02
-- 循环节点

ZDLNodeLoop = class("ZDLNodeLoop", ZDLTreeNode);

function ZDLNodeLoop:ctor(parent,precondition)
	ZDLNodeLoop.super.ctor(self,parent,precondition);

	self.mi_LoopCount = kInfiniteLoop;
	self.mi_CurrentCount = 0;
end

-----------------------------------------------
-----------------------------------------------
-----------------重写父类的函数------------------
-----------------------------------------------

function ZDLNodeLoop:doEvaluate(input)

	local checkLoopCount = (self.mi_LoopCount == kInfiniteLoop) or
		self.mi_CurrentCount < self.mi_LoopCount;

	if(not checkLoopCount) then
		return false;
	end	

	if(self:checkIndex(1)) then
		local oBN = self.children[1];
		if(oBN:evaluate(input)) then
			return true;
		end	
	end
	return false;				 
end

function ZDLNodeLoop:doTransition(input)

	if(self:checkIndex(1)) then
		local oBN = self.children[1];
		oBN:transition(input);
	end
	self.mi_CurrentCount = 0;
end

function ZDLNodeLoop:doTick(input,output)

	local bIsFinish = ZDLRunningStatus.k_BRS_Finish;
	if(self:checkIndex(1)) then
	
		local oBN = self.children[1];
		bIsFinish = oBN:tick(input, output);

		if(bIsFinish == ZDLRunningStatus.k_BRS_Finish) then
		
			if(self.mi_LoopCount ~= kInfiniteLoop) then
			
				self.mi_CurrentCount = self.mi_CurrentCount + 1;
				if(self.mi_CurrentCount < self.mi_LoopCount) then
				
					bIsFinish = ZDLRunningStatus.k_BRS_Executing;
				end
			else
				bIsFinish = ZDLRunningStatus.k_BRS_Executing;
			end
		end
	end

	if (bIsFinish ~= 0) then
		self.mi_CurrentCount = 0;
	end

	return bIsFinish;
end

return ZDLNodeLoop;
