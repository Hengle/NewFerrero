using UnityEngine;

public class AssetConst
{
    ////稀有度
    //public static string Rare = "rare" ;

    ////整容模块相关
    ////战舰icon
    //public static string WarShips = "warships" ;
    ////装备icon
    //public static string WarEquips = "warequips" ;
    ////军队（宝物icon）
    //public static string WarAmy = "waramy" ;

    //Json 数据 所有的json数据都打包一个文件中 具体策略可以根据后面的需要进行调整
    public static string JsonData = "data.u3d";

    public static string ImageSavePath = Application.persistentDataPath + "/TargetImageSave";

    ///一级菜单 标注点 perfab
    public static string firstPointIcon = "PointPerfabs/firstIcon";
    ///// <summary>
    ///// 一级菜单
    ///// </summary>
    //public static string firstPointMenu = "firstMenu";


    /// <summary>
    ///二级菜单 item perfab
    /// </summary>
    public static string secondMenu = "PointPerfabs/secondMenu";

    /// <summary>
    ///  根据类型赋值图标
    ///  //point_type 气泡  1 警告、2 提示、3 数据（折线图）、4 文件、5 打开
    /// </summary>
    public static string GetSpriteByPointType(int type)
    {
        return "pointType/pointType" + type;

    }
    /// <summary>
    /// 根据 item 类型 赋值
    /// //item_type 1 警告、2提示、3 数据（折线图）、4 文件、5cad  6 视频 7手机  8 打开
    /// </summary>
    /// <returns>The sprite by item type.</returns>
    /// <param name="type">Type.</param>
    public static string GetSpriteByItemType(int type)
    {
        return "itemType/itemType" + type;
    }
}
