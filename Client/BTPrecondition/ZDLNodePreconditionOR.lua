--
-- Author: donglizhang2011@126.com
-- Date: 2014-09-24 10:53:57
-- 或者逻辑条件，左条件和右条件有一个满足

ZDLNodePreconditionOR = class("ZDLNodePreconditionOR", ZDLNodePrecondition)

--[[
	* 构造函数
	* lhs ZDLNodePrecondition 左边条件
	* rhs ZDLNodePrecondition 右边条件
]]
function ZDLNodePreconditionOR:ctor(lhs,rhs)
	ZDLNodePreconditionOR.super.ctor(self);
	self.lhs = lhs;
	self.rhs = rhs;
end

-----------------------------------------------
-----------------------------------------------
-----------------重写父类的函数------------------
-----------------------------------------------

function ZDLNodePreconditionOR:externalCondition(input)
	return self.lhs:externalCondition(input) or self.rhs:externalCondition(input)
end

return ZDLNodePreconditionOR