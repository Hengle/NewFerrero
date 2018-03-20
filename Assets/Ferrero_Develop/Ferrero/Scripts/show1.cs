using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using LitJson;

public class show1 : MonoBehaviour
{

    private Vector3 pos;
    // Use this for initialization
    void Start()
    {
        Show2_1.SetActive(false);
        Show2_2.SetActive(false);
        Show2_3.SetActive(false);
        Show2_4.SetActive(false);
        Show2_5.SetActive(false);
        TransparentSprite = Resources.LoadAll("firstbtns", typeof(Sprite));
    }

    //用来判断是否点击打开

    public bool isOpen;
    public GameObject Show1;
    public GameObject Show2_1;
    public GameObject Show2_2;
    public GameObject Show2_3;
    public GameObject Show2_4;
    public GameObject Show2_5;
    private Camera cameraObj;
    private Object[] TransparentSprite;
    private Sprite src_sprite;

    public void ButtonOnClick(GameObject go)
    {
    }

    public void set_isOpen(GameObject go)
    {
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(true);
        }
        isOpen = true;
        InvokeRepeating("LaunchProjectile", 5, 0);
    }

    //point_type 气泡  1 警告、2 提示、3 数据（折线图）、4 文件、5 打开
    public void updataPointsData(FirstModel firstModel)
    {
        var firstDisplayImageName = "";
        if (firstModel.point_type == 1)
        {
            firstDisplayImageName = "firstbtns/1";
        }
        else if (firstModel.point_type == 2)
        {
            firstDisplayImageName = "firstbtns/2";
        }
        else if (firstModel.point_type == 3)
        {
            firstDisplayImageName = "firstbtns/3";
        }
        else if (firstModel.point_type == 4)
        {
            firstDisplayImageName = "firstbtns/4";
        }
        else if (firstModel.point_type == 5)
        {
            firstDisplayImageName = "firstbtns/5";
        }
        GetComponent<Image>().sprite = Resources.Load<Sprite>(firstDisplayImageName);
        for (int j = 0; j < firstModel.point_info.Count; j++)
        {
            var btn_2 = transform.Find("sbtn_0_" + j);
//            pointSp psp = (pointSp)btn_2.GetComponent(typeof(pointSp));
            SecondModel secondModel = firstModel.point_info[j];
//            psp.set_secondModel(secondModel, j);
        }
    }

    public void set_firstModel(FirstModel firstModel)
    {
//        /**
//			 * ipad
//				width 图片宽度  3264
//				hight 图片高度  2448
//				x 点横坐标  起始点为图片左上角
//				y 点纵坐标  起始点为图片左上角
//				pic_x = (x - (width/2.f))/2.25  	
//				pic_y = (higth/2 - y)/2.25			
//		*/
//        float width = 3264;
//        float hight = 2448;
//        float pic_x = (firstModel.x - (width / 2f)) / 2.238f;
//        float pic_y = (hight / 2f - firstModel.y) / 2.238f;
//        GetComponent<RectTransform>().anchoredPosition3D = new Vector3(pic_x, pic_y, 0);
//        EventTriggerListener.Get(gameObject).onDown = set_isOpen;
//
//        for (int j = 0; j < firstModel.point_info.Count; j++)
//        {
//            var btn_2 = transform.Find("sbtn_0_" + j);
//            pointSp psp = (pointSp)btn_2.GetComponent(typeof(pointSp));
//            SecondModel secondModel = firstModel.point_info[j];
//            psp.set_secondModel(secondModel, j);
//            EventTriggerListener.Get(btn_2.gameObject).onDown = ButtonOnClick;
//        }
    }

    void LaunchProjectile()
    {
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(false);
        }
        isOpen = false;
    }

    void Update()
    {
        if (Show1 != null)
        {
            cameraObj = GameObject.Find("RenderCamera").GetComponent<Camera>();
            pos = cameraObj.WorldToScreenPoint(Show1.transform.position);
            pos.z = 0;
            if (Show1.GetComponent<Image>().sprite != (Sprite)TransparentSprite[0])
            {
                src_sprite = Show1.GetComponent<Image>().sprite;//记录一级菜单原有的图标
            }
            if (pos.x < (0.5 * Screen.width + 100) && pos.x > (0.5 * Screen.width - 100) && pos.y < (0.5 * Screen.height + 100) && pos.y > (0.5 * Screen.height - 100))
            {
                Show1.GetComponent<Image>().sprite = (Sprite)TransparentSprite[0]; //一级菜单设置为透明；
                Show2_1.SetActive(true);
                Show2_2.SetActive(true);
                Show2_3.SetActive(true);
                Show2_4.SetActive(true);
                Show2_5.SetActive(true);
            }
            else if (isOpen == false)
            {

                Show1.GetComponent<Image>().sprite = src_sprite;//一级菜单设置为原有的图标；

                Show2_1.SetActive(false);
                Show2_2.SetActive(false);
                Show2_3.SetActive(false);
                Show2_4.SetActive(false);
                Show2_5.SetActive(false);
            }
        }

    }
}

//
//public class BuildHeadWord : MonoBehaviour {
//
//	public GameObject Head;      //头顶的点
//	public Transform UI;         //头顶的字,zD sprite
//	private float baseFomat;     //默认字与摄像机的距离
//	private float currentFomat;  //当前相机的距离
//	private float Scale;
//	void Start()
//	{
//		//计算以下默认的距离
//		baseFomat = Vector3.Distance(Head.transform.position, Camera.main.transform.position);
//		Scale = 1-UI.localScale.x;//默认缩放差值
//		currentFomat = 0;
//	}
//
//	void Update()
//	{
//		if (baseFomat != currentFomat)
//		{
//			//保存当前相机到文字UI的距离
//			currentFomat = Vector3.Distance(Head.transform.position, Camera.main.transform.position);
//			float myscale = baseFomat / currentFomat - Scale;  //计算出缩放比例 
//			UI.position = WorldToUI(Head.transform.position); //计算UI显示的位置
//			UI.localScale = Vector3.one * myscale;           //缩放UI 
//		}
//	}
//
//	/// <summary>
//	/// 把3D点换算成NGUI屏幕上的2D点。
//	/// </summary>
//	public static Vector3 WorldToUI(Vector3 point)
//	{
//		Vector3 pt = Camera.main.WorldToScreenPoint(point);  //将世界坐标转换为视口坐标
//		Vector3 ff = UICamera.currentCamera.ScreenToWorldPoint(pt);//将视口坐标转换为世界坐标
//		ff.z = 0;
//		return ff;
//	}
//}
