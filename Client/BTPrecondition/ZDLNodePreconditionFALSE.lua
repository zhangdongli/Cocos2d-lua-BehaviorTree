--
-- Author: donglizhang2011@126.com
-- Date: 2014-09-24 10:43:30
-- 假条件

ZDLNodePreconditionFALSE = class("ZDLNodePreconditionFALSE",ZDLNodePrecondition)

function ZDLNodePreconditionFALSE:ctor()
	ZDLNodePreconditionFALSE.super.ctor(self);
end

-----------------------------------------------
-----------------------------------------------
-----------------重写父类的函数------------------
-----------------------------------------------

function ZDLNodePreconditionFALSE:externalCondition(input)
	return false;
end

return ZDLNodePreconditionFALSE;