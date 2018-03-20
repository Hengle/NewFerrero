using UnityEngine;
using System.Collections;
using ffDevelopmentSpace;
using LitJson;
using System.Collections.Generic;
using System.Text;


/* 
    Author:     fyw 
    CreateDate: 2018-03-14 16:27:24 
    Desc:       注释 
*/
public class SecondModel
{
    public string image_name;
    public string item_id;
    public string text;
    public int item_type;
    public string item_url;
}
public class FirstModel
{
    public int point_type;
    public int x;
    public int y;
    public List<SecondModel> point_info;
}

public class JsonMyModel
{
    public string image_name;
    public List<FirstModel> image_info;
}

public class ImageTargetDataModel : ModelBase
{

    #region public property
    public float pad_width = 3264;
    public float pad_height = 2448;
    public string currentUrl = "https://www.baidu.com";
    #endregion
    #region private property
    private Dictionary<string, string> dataDic;
    #endregion



    #region public function
    public void SetTargetImageData(string id, string data)
    {
        if (dataDic == null) dataDic = new Dictionary<string, string>();
        //JsonMyModel JsonObject = JsonMapper.ToObject<JsonMyModel>(data);
        dataDic[id] = data;
        Debug.Log("Json  Analysis Success ============imgtarget_id=========");
        //修改所有显示btns 位置,并设定Btn功能

        //GameObject k_bgImageObjcet = gameObject.transform.Find("picCanvas(Clone)/backgroundImage").gameObject;
        //for (int i = 0; i < JsonObject.image_info.Count; i++)
        //{
        //    //动态加载内容
        //    GameObject button_objc;
        //    if (i < k_bgImageObjcet.transform.childCount)
        //    {
        //        button_objc = k_bgImageObjcet.transform.GetChild(i).gameObject;
        //    }
        //    else
        //    {
        //        button_objc = Instantiate(Resources.Load("fbtn")) as GameObject;
        //        button_objc.transform.parent = k_bgImageObjcet.gameObject.transform;
        //        button_objc.transform.localScale = new Vector3(1, 1, 1);
        //    }
        //    button_objc.SetActive(true);
        //    show1 isShow = (show1)button_objc.GetComponent(typeof(show1));
        //    isShow.set_firstModel(JsonObject.image_info[i]);
        //}
        //Debug.Log("Get Data Success =======================");


        //        //更新数据
        //UpdateImagePointsData(data);
        //        返回初始化已完成
        //SendFinishSingal(k_targetName);
        dispatchEvent(ModuleEventDispatcher.IMAGE_DATA_LOAD_COMPLETE);
    }

    public string GetTargetImageData(string id)
    {
        string data = dataDic[id];
        Debug.Log("data=" + data);
        return data;
    }
    public Vector2 GetPadWH()
    {
        return new Vector2(pad_width, pad_height);
    }
    public float GetScaleFatorFor(float size)
    {
        //Debug.Log("size=" + size + "     padWidth=" + pad_width + "   end=" + size / pad_width);
        return size / pad_width;
    }
    #endregion
    #region private function
    #endregion

    #region event function
    #endregion
}
