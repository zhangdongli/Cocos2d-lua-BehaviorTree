--
-- Author: donglizhang2011@126.com
-- Date: 2014-09-24 10:50:29
-- 并且逻辑条件，左条件和右条件同时满足

ZDLNodePreconditionAND = class("ZDLNodePreconditionAND", ZDLNodePrecondition)

--[[
	* 构造函数
	* lhs ZDLNodePrecondition 左边条件
	* rhs ZDLNodePrecondition 右边条件
]]
function ZDLNodePreconditionAND:ctor(lhs,rhs)
	ZDLNodePreconditionAND.super.ctor(self);
	self.lhs = lhs;
	self.rhs = rhs;
end

-----------------------------------------------
-----------------------------------------------
-----------------重写父类的函数------------------
-----------------------------------------------

function ZDLNodePreconditionAND:externalCondition(input)	
	return self.lhs:externalCondition(input) and self.rhs:externalCondition(input)
end

return ZDLNodePreconditionAND