using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using ffDevelopmentSpace;
using LitJson;
using EasyAR;
using UnityEngine.Networking;


/* 
    Author:     fyw 
    CreateDate: 2018-03-09 11:23:17 
    Desc:       每个ImageTarget的控制器
*/


public class ImageTargetController : MonoBehaviour
{
    public GameObject m_canvas;
    public GameObject BG_IMG;
    private void OnEnable()
    {
        Singleton<ImageTargetDataModel>.GetInstance().addEvent(ModuleEventDispatcher.IMAGE_DATA_LOAD_COMPLETE, OnDataLoaded);

    }
    private void OnDisable()
    {
        Singleton<ImageTargetDataModel>.GetInstance().removeEvent(ModuleEventDispatcher.IMAGE_DATA_LOAD_COMPLETE, OnDataLoaded);
    }

    private ImageTargetBehaviour _itb;

    public ImageTargetBehaviour itb
    {
        get
        {
            if (_itb == null) _itb = GetComponent<ImageTargetBehaviour>();
            return _itb;
        }
    }


    private void OnDataLoaded(EventObject e)
    {
        //string json_test_data = "{\"image_info\":[{\"point_info\":[{\"image_name\":\"1111\",\"item_id\":\"12\",\"item_type\":8,\"item_url\":\"http://10.122.139.4:8088/resources/image/20171207135203.jpg\",\"text\":\"123\"}],\"point_type\":5,\"x\":1567,\"y\":1332},{\"point_info\":[{\"image_name\":\"1111\",\"item_id\":\"12\",\"item_type\":8,\"item_url\":\"http://10.122.139.4:8088/resources/image/20171207135203.jpg\",\"text\":\"123\"}],\"point_type\":5,\"x\":300,\"y\":1332},{\"point_info\":[{\"image_name\":\"1111\",\"item_id\":\"12\",\"item_type\":8,\"item_url\":\"http://10.122.139.4:8088/resources/image/20171207135203.jpg\",\"text\":\"123\"}],\"point_type\":1,\"x\":400,\"y\":400}],\"image_name\":\"c\"}";
        //GetData(json_test_data);
        GetData(Singleton<ImageTargetDataModel>.GetInstance().GetTargetImageData(gameObject.name));
    }
    public void GetData(string data)
    {
        Debug.Log("Json data=========" + data);
        ImageTargetDataConfigInfo JsonObject = JsonMapper.ToObject<ImageTargetDataConfigInfo>(data);
        //FirstLevelMenuConfigInfo JsonObject = JsonMapper.ToObject<FirstLevelMenuConfigInfo>(data);
        //JsonData jData = JsonMapper.ToObject(data);
        //Debug.Log("Json  Analysis Success ============imgtarget_id=========" + jData["image_name"]);
        //修改所有显示btns 位置,并设定Btn功能

        GameObject k_bgImageObjcet = gameObject.transform.Find("picCanvas(Clone)/backgroundImage").gameObject;
        for (int i = 0; i < JsonObject.image_info.Count; i++)
        {
            GameObject pointInfo = Instantiate(Resources.Load(AssetConst.firstPointIcon)) as GameObject;
            if (pointInfo) InitPointInfo(pointInfo, JsonObject.image_info[i]);
            //isShow.set_firstModel(JsonObject.image_info[i]);
        }
        Debug.Log("Get Data Success =======================");
        //        //更新数据
        //UpdateImagePointsData(data);
        //        返回初始化已完成
        //SendFinishSingal(k_targetName);
    }
    private void InitPointInfo(GameObject pointInfo, FirstLevelMenuConfigInfo imageInfo)
    {
        pointInfo.transform.parent = BG_IMG.transform;

        pointInfo.transform.localScale = Vector3.one;//* 5;
        pointInfo.GetComponent<RectTransform>().anchoredPosition3D = new Vector3(imageInfo.x, -imageInfo.y, 0);
        pointInfo.GetComponent<UnityEngine.UI.Image>().sprite = Resources.Load<Sprite>(AssetConst.GetSpriteByPointType(imageInfo.point_type));
        pointInfo.GetComponent<UnityEngine.UI.Image>().SetNativeSize();
        for (int i = 0; i < imageInfo.point_info.Count; i++)
        {
            GameObject menuItem = Instantiate(Resources.Load(AssetConst.secondMenu)) as GameObject;
            if (menuItem)
            {
                menuItem.SetActive(false);
                menuItem.transform.parent = pointInfo.transform;
                menuItem.transform.localPosition = Vector3.one * 0.1f;
                InitMenuItem(menuItem, imageInfo.point_info[i]);
            }
        }
    }
    private void InitMenuItem(GameObject menuItem, SecondLevelMenuConfigInfo itemData)
    {
        Debug.Log("InitMenuItem");
        menuItem.transform.localScale = Vector3.one;
        menuItem.GetComponent<MenuItemScript>().configInfo = itemData;
        menuItem.GetComponent<UnityEngine.UI.Image>().sprite = Resources.Load<Sprite>(AssetConst.GetSpriteByItemType(itemData.item_type));
        menuItem.GetComponentInChildren<Text>().text = itemData.text;
        menuItem.GetComponent<Button>().onClick.AddListener(OnItemClick);
    }
    private void OnItemClick()
    {
        Debug.Log("MenuItem click");
    }
}
