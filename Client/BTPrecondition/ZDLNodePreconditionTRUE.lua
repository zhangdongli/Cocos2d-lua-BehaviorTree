--
-- Author: donglizhang2011@126.com
-- Date: 2014-09-24 10:40:38
-- 真条件

ZDLNodePreconditionTRUE = class("ZDLNodePreconditionTRUE",ZDLNodePrecondition)

function ZDLNodePreconditionTRUE:ctor()
	ZDLNodePreconditionTRUE.super.ctor(self);
end

-----------------------------------------------
-----------------------------------------------
-----------------重写父类的函数------------------
-----------------------------------------------

function ZDLNodePreconditionTRUE:externalCondition(input)
	return true;
end

return ZDLNodePreconditionTRUE