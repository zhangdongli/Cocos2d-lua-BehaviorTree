--
-- Author: donglizhang2011@126.com
-- Date: 2014-09-24 10:45:51
-- 取反逻辑条件，对子条件取反

ZDLNodePreconditionNOT = class("ZDLNodePreconditionNOT", ZDLNodePrecondition)

--[[
	* 构造函数
	* lhs ZDLNodePrecondition 子条件	
]]
function ZDLNodePreconditionNOT:ctor(lhs)
	ZDLNodePreconditionNOT.super.ctor(self);
	self.lhs = lhs;
end

-----------------------------------------------
-----------------------------------------------
-----------------重写父类的函数------------------
-----------------------------------------------

function ZDLNodePreconditionNOT:externalCondition(input)
	return not self.lhs:externalCondition(input);
end

return ZDLNodePreconditionNOT;