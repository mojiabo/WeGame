print('启动GameInit.lua')

require "Download/xLuaLogic/CtrlMgr"
require "Download/xLuaLogic/Data/DBModelMgr"


GameInit = {};
local this = GameInit;

function GameInit.InitViews()
	require('download/xLuaLogic/Modules/UIRoot/UIRootView');
	require('download/xLuaLogic/Modules/Task/TaskView');
	
	require('Download/xLuaLogic/Modules/Recharge/RechargeView');
	require('Download/xLuaLogic/Modules/Shop/ShopView');
	require('Download/xLuaLogic/Modules/RoleBackpack/RoleBackpackView');
	require('Download/xLuaLogic/Modules/RoleBackpack/RoleInfoView');
	require('Download/xLuaLogic/Modules/RoleBackpack/BackpackView');
	require('Download/xLuaLogic/Modules/RoleBackpack/RoleEquipView');
	require('Download/xLuaLogic/Modules/Goods/GoodsEquipView');
	require('Download/xLuaLogic/Modules/Goods/GoodsItemView');
	require('Download/xLuaLogic/Modules/Goods/GoodsMaterialView');
end


function GameInit.Init()
	this.InitViews();
	CtrlMgr.Init();
	
	DBModelMgr.Init();
	
	--GameInit.LoadView(CtrlNames.UIRootCtrl);
end

function GameInit.LoadView(type)
	local ctrl = CtrlMgr.GetCtrl(type);
	if ctrl ~= nil then
		ctrl.Awake();
	end
end