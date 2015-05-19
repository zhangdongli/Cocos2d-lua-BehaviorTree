--
-- Author: donglizhang2011@126.com
-- Date: 2014-09-20 17:56:00
-- 行为节点基类

ZDLNodeTerminal = class("ZDLNodeTerminal",ZDLTreeNode)

function ZDLNodeTerminal:ctor(parent,precondition)
	ZDLNodeTerminal.super.ctor(self,parent,precondition)

	self.status = ZDLTerminalNodeStaus.k_TNS_Ready;
	self.needExit = false;

end

-----------------------------------------------
-----------------------------------------------
-----------------重写父类的函数------------------
-----------------------------------------------


function ZDLNodeTerminal:doTransition(input)
	if self.needExit then
		self:doExit(input,ZDLRunningStatus.k_BRS_ERROR_Transition)
	end

	self:setActiveNode(nil);
	self.status = ZDLTerminalNodeStaus.k_TNS_Ready;
	self.needExit = false;
end

function ZDLNodeTerminal:doTick(input,output)	
	-- 默认状态为完成		
	local state = ZDLRunningStatus.k_BRS_Finish;

	-- 如果我在准备
	if self.status == ZDLTerminalNodeStaus.k_TNS_Ready then
		self:doEnter(input,output);--调用doEnter
		self.needExit = true;--需要调用退出函数
		self.status = ZDLTerminalNodeStaus.k_TNS_Running;--我转化为正在执行
		self:setActiveNode(self);--设置自己为激活节点
	end

	-- 如果我正在执行
	if self.status == ZDLTerminalNodeStaus.k_TNS_Running then
		
		state = self:doExecute(input,output);--调用doExecute		
		self:setActiveNode(self);--设置自己为激活节点

		-- 如果doExecute返回状态为完成或者错误
		if state == ZDLRunningStatus.k_BRS_Finish 
			or state < ZDLRunningStatus.k_BRS_Executing then
			--自己转化为完成
			self.status = ZDLTerminalNodeStaus.k_TNS_Finish;
		end
	end

	-- 如果我已经完成
	if self.status == ZDLTerminalNodeStaus.k_TNS_Finish then
		
		-- 如果需要退出
		if self.needExit then
			self:doExit(input,ZDLRunningStatus.k_BRS_Finish);
		end


		self:setActiveNode(nil);--将激活节点置空
		self.status = ZDLTerminalNodeStaus.k_TNS_Ready;--复位到我在准备
		self.needExit = false;--不需要退出了

		return state;
	end

	return state;
end

-----------------------------------------------
-----------------------------------------------
--------------需要子类重写的函数------------------
-----------------------------------------------

--[[
	* 进入函数
]]
function ZDLNodeTerminal:doEnter(input,output)

end

--[[
	* 执行函数
]]
function ZDLNodeTerminal:doExecute(input,output) 
  	return ZDLRunningStatus.k_BRS_Finish;
end

--[[
	* 退出函数
	* input 不解释
	* exitStatus ZDLRunningStatus 退出的状态
]]
function ZDLNodeTerminal:doExit(input,exitStatus)

end

return ZDLNodeTerminal;