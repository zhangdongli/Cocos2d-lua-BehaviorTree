--
-- Author: donglizhang2011@126.com
-- Date: 2014-09-25 15:53:46
-- 输出参数

ZDLOutputParameter = class("ZDLOutputParameter")

--[[
	* 初始化参数，需要外部调用
]]
function ZDLOutputParameter.initOutputParameter()
	CommandType = {
		Default = 0,--默认
		Idle = 1,--发呆
		Move = 2,--移动
		Attack = 3,--攻击
		Fllow = 4,--跟随
        GetTarget = 5,--获取目标
        Center = 6,--集中
        March = 7,--前进
        Retreat = 8,--后退
        Skill1 = 9,--释放技能1
        Skill2 = 10,--释放技能2
        GroupSkill = 11,--释放组合技能
        AttackEnemyCamp = 12,--攻击敌营
        RemoveTarget = 13,--移除目标
	}
	CommandTypeName = {
		[0] = "默认",
		[1] = "发呆",
		[2] = "移动",
		[3] = "攻击",
		[4] = "跟随",
		[5] = "获取目标",
		[6] = "集中",
		[7] = "前进",
		[8] = "后退",
		[9] = "释放技能1",
		[10]= "释放技能2",
		[11] = "释放组合技能",
		[12] = "攻击敌营",
		[13] = "清空目标",
	}
end

function ZDLOutputParameter.getCommNameByType(commType)
	return CommandTypeName[commType];
end

function ZDLOutputParameter:ctor()
	-- initOutputParameter();
	self.commandType = 0;--CommandType 命令类型
	self.fllowTarget = nil;--npc 跟随目标，在Fllow下有作用
end

function ZDLOutputParameter:commandName()
	return ZDLOutputParameter.getCommNameByType(self.commandType);
end

return ZDLOutputParameter;

