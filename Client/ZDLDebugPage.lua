--
-- Author: donglizhang2011@126.com
-- Date: 2015-01-30 18:37:36
-- AI测试页面

ZDLDebugPage = class("ZDLDebugPage", function()
	return display.newNode();
end);

function ZDLDebugPage:ctor()
	-- print("------条件-----")
	local tree = cc.FileUtils:getInstance():fullPathForFilename("tree/PlayerTree.json");
	local treeNode = ZDLNodeFactory.getInstance():createTreeByPath(tree);
	local input = ZDLDebugInputParameter.new();
	local output = ZDLOutputParameter.new();
	if treeNode:evaluate(input) then
        treeNode:tick(input, output)
    end
    -- print("------行为-----")
	print(output:commandName());
end

return ZDLDebugPage;