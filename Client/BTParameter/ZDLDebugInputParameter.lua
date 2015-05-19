--
-- Author: donglizhang2011@126.com
-- Date: 2015-01-30 14:35:38
-- 调试输入参数

ZDLDebugInputParameter = class("ZDLDebugInputParameter")

--[[ 
	* 原始设置

	self.hasTarget = false;					--bool 是否有目标
	self.attackRange = false;				--bool 目标是否在攻击范围内

	self.attackEnemies = false;				--bool 攻击距离内是否有更近的敌人
	self.switchTargetTime = false; 			--bool 下次切换目标时间是否到了
	self.attackIsComplete = false; 			--bool 4连击是否完成
	
	self.attackSpeedIsZero = true;			--bool 攻击速度是否为零
	self.moveSpeedIsZero = true;			--bool 移动速度是否为零
	
	self.attackTime = false;				--bool 普通攻击的cd时间是否到了


	self.isFight = false;					--bool 是否开战
	self.entreCamp = false;					--bool 是否到了战场的2/3的位置
	self.isFightEnded = false;				--bool 战斗是否结束
	self.isFriends = false;					--bool 是否是自己人
	self.isPlayer = false;					--bool 是否是主将

	self.inPlayerVision = false;			--bool 是否在玩家视野内
	

	self.isAllHosting = false;				--bool 是否全部托管
	self.isAutoFind = false;				--bool 是否自动寻路	

	self.isChaos = false;					--bool 是否被混乱
	self.isRidicule = false;				--bool 是否被嘲讽	
	self.isSilence = false;					--bool 是否被沉默
	self.isVertigo = false; 				--bool 是否被眩晕
	
	self.nearPlayer = false;				--bool 是否在玩家附近
	self.seeEnemies = false;				--bool 是否能看到敌人

	self.isMarch = false;					--bool 是否发出前进命令
	self.isRetreat = false;					--bool 是否发出后退命令
	self.isCenter = false;					--bool 是否发出集中命令
	
	self.angerIsFull = false;  				--bool 怒气是否满了
	self.hasCompleteGroupSkill = false;		--bool 是否有能释放的组合技


	self.skill1Time = false;				--bool 技能1的CD时间是否到了
	self.skill1Anger = false;				--bool 技能1的怒气是否满了
	
	
	self.skill2Time = false;				--bool 技能2的CD时间是否到了
	self.skill2Anger = false;				--bool 技能2的怒气是否满了

	self.isSpecialStatus = self.isChaos or self.isRidicule or (self.attackSpeedIsZero and self.moveSpeedIsZero) -- 是否不听话
	self.issueCommands = self.isMarch or self.isRetreat or self.isCenter  										-- 是否下发了指令 
]]

function ZDLDebugInputParameter:ctor()
	-- 外部赋值参数
	self.hasTarget = false;					--bool 是否有目标
	self.attackRange = false;				--bool 目标是否在攻击范围内

	self.attackEnemies = false;				--bool 攻击距离内是否有更近的敌人
	self.switchTargetTime = false; 			--bool 下次切换目标时间是否到了
	self.attackIsComplete = false; 			--bool 4连击是否完成
	
	self.attackSpeedIsZero = true;			--bool 攻击速度是否为零
	self.moveSpeedIsZero = true;			--bool 移动速度是否为零
	
	self.attackTime = false;				--bool 普通攻击的cd时间是否到了
	self.isPursuit = false;					--bool 追击目标的cd时间是否到了


	self.isFight = false;					--bool 是否开战
	self.entreCamp = false;					--bool 是否到了战场的2/3的位置
	self.isFightEnded = false;				--bool 战斗是否结束
	self.isFriends = false;					--bool 是否是自己人
	self.isPlayer = false;					--bool 是否是主将

	self.inPlayerVision = false;			--bool 是否在玩家视野内
	

	self.isAllHosting = false;				--bool 是否全部托管
	self.isAutoFind = false;				--bool 是否自动寻路	

	self.isChaos = false;					--bool 是否被混乱
	self.isRidicule = false;				--bool 是否被嘲讽	
	self.isSilence = false;					--bool 是否被沉默
	self.isVertigo = false; 				--bool 是否被眩晕
	
	self.nearPlayer = false;				--bool 是否在玩家附近
	self.seeEnemies = false;				--bool 是否能看到敌人

	self.isMarch = false;					--bool 是否发出前进命令
	self.isRetreat = false;					--bool 是否发出后退命令
	self.isCenter = false;					--bool 是否发出集中命令
	
	self.angerIsFull = false;  				--bool 怒气是否满了
	self.hasCompleteGroupSkill = false;		--bool 是否有能释放的组合技


	self.skill1Time = false;				--bool 技能1的CD时间是否到了
	self.skill1Anger = false;				--bool 技能1的怒气是否满了
	
	
	self.skill2Time = false;				--bool 技能2的CD时间是否到了
	self.skill2Anger = false;				--bool 技能2的怒气是否满了

	self.isSpecialStatus = self.isChaos or self.isRidicule or (self.attackSpeedIsZero and self.moveSpeedIsZero) -- 是否不听话
	self.issueCommands = self.isMarch or self.isRetreat or self.isCenter  										-- 是否下发了指令 
end



return ZDLDebugInputParameter;