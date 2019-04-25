--Lua控制器的管理器 作用就是注册所有的控制器

print('启动CtrlManager.lua')

require "Download/xLuaLogic/Common/Define"

require "Download/xLuaLogic/Modules/RoleData/RoleDataCtrl"
require "Download/xLuaLogic/Modules/UIRoot/UIRootCtrl"
require "Download/xLuaLogic/Modules/Task/TaskCtrl"
require "Download/xLuaLogic/Modules/Recharge/RechargeCtrl"
require "Download/xLuaLogic/Modules/Shop/ShopCtrl"
require "Download/xLuaLogic/Modules/RoleBackpack/RoleBackpackCtrl"
require "Download/xLuaLogic/Modules/Goods/GoodsEquipCtrl"
require "Download/xLuaLogic/Modules/Goods/GoodsItemCtrl"
require "Download/xLuaLogic/Modules/Goods/GoodsMaterialCtrl"

CtrlMgr = {};

local this = CtrlMgr;

--控制器列表
local ctrlList = {};

--初始化 往列表中添加所有的控制器
function CtrlMgr.Init()
	ctrlList[CtrlNames.RoleDataCtrl] = RoleDataCtrl.New();
	ctrlList[CtrlNames.UIRootCtrl] = UIRootCtrl.New();
	ctrlList[CtrlNames.TaskCtrl] = TaskCtrl.New();
	ctrlList[CtrlNames.RechargeCtrl] = RechargeCtrl.New();
	ctrlList[CtrlNames.ShopCtrl] = ShopCtrl.New();
	ctrlList[CtrlNames.RoleBackpackCtrl] = RoleBackpackCtrl.New();
	ctrlList[CtrlNames.GoodsEquipCtrl] = GoodsEquipCtrl.New();
	ctrlList[CtrlNames.GoodsItemCtrl] = GoodsItemCtrl.New();
	ctrlList[CtrlNames.GoodsMaterialCtrl] = GoodsMaterialCtrl.New();
	return this;
end

--根据控制器的名称 获取控制器
function CtrlMgr.GetCtrl(ctrlName)
	return ctrlList[ctrlName];
end