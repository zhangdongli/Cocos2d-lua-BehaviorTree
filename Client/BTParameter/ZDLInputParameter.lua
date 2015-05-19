--
-- Author: donglizhang2011@126.com
-- Date: 2014-09-24 12:32:09
-- 输入参数

ZDLInputParameter = class("ZDLInputParameter",ZDLDebugInputParameter)

function ZDLInputParameter:ctor()
	ZDLInputParameter.super.ctor(self);
	-- 外部赋值参数
	self.dt = 0.0;--number 时间间隔	
	self.owner = nil;--npc 拥有者
	self.npcManager = nil;--NpcManager npc管理对象
	self.aiManager = nil;--AiManager ai管理对象
	self.mapManager = nil;--MapLayer map管理对象

	-- 内部传递参数
	self.enemy = nil;--npc 要攻击的敌人
end


return ZDLInputParameter;

