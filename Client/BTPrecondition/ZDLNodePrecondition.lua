--
-- Author: donglizhang2011@126.com
-- Date: 2014-09-20 17:28:16
-- 条件基类

ZDLNodePrecondition = class("ZDLNodePrecondition")
ZDLNodePrecondition.doCallNumber = 0; -- 条件调用次数
ZDLNodePrecondition.doCallTimeDict = {}; -- 每个条件的计时器

function ZDLNodePrecondition:ctor()
	self.lhs = nil;
	self.rhs = nil;
end

--[[
	* 添加子条件
	* childPrecondition ZDLNodePrecondition 子条件
]]
function ZDLNodePrecondition:addPrecondition(childPrecondition)
	if self.lhs == nil then
		self.lhs = childPrecondition;		
	elseif self.rhs == nil then
		self.rhs = childPrecondition;
	end
end

-----------------------------------------------
-----------------------------------------------
--------------需要子类重写的函数------------------
-----------------------------------------------

--[[
	* 判断条件是否满足函数
]]
function ZDLNodePrecondition:externalCondition(input)
	return false;
end

--[[
	* DEBUG下得调用函数
]]
function ZDLNodePrecondition:debugExternalCondition(input)
	print(self.__cname.."：没有覆写调试函数");
	return false;
end

return ZDLNodePrecondition;