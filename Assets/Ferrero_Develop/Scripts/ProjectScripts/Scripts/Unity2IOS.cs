using UnityEngine;
using System.Collections;
using ffDevelopmentSpace;
using System.Runtime.InteropServices;


/* 
    Author:     fyw 
    CreateDate: 2018-03-08 16:39:04 
    Desc:       与iOS通讯
*/
public class Unity2IOS : MonoBehaviour
{
    //#region 引入内部动态链接库函数
    //[DllImportAttribute("__Internal")]
    //public static extern int Set_StartInitial();                       
    //[DllImportAttribute("__Internal")]
    //public static extern int startimageid(string image_id);
    //[DllImportAttribute("__Internal")]
    //public static extern int endimageid(string image_id);
    //[DllImportAttribute("__Internal")]
    //public static extern int sendfinished(string image_id);
    //[DllImportAttribute("__Internal")]
    //public static extern int TakePhoto(string name);
    //[DllImportAttribute("__Internal")]
    //public static extern int OpenAttachment(string json);

    //[DllImportAttribute("__Internal")]
    //public static extern int LockScreencreen_cancel();                          //取消锁屏
    //[DllImportAttribute("__Internal")]
    //public static extern int LockScreencreen_active();  
    //#endregion

    //public  void SetBackgroundTransparent()
    //{
    //    k_bgImageObjcet.GetComponent<Image>().sprite = Resources.Load<Sprite>("secondbtns/0");
    //    foreach (Transform child in k_bgImageObjcet.transform)
    //    {
    //        child.gameObject.SetActive(false);
    //    }

    //}

    //public void resetAllGameObjc()
    //{
    //    for (int i = k_bgImageObjcet.transform.childCount - 1; i >= 0; i--)
    //    {
    //        Destroy(k_bgImageObjcet.transform.GetChild(i).gameObject);
    //    }
    //}

    //public void StartID(string image_id)
    //{
    //    Debug.Log("StartID=" + image_id);
    //    startimageid(image_id);
    //}

    //public void EndID(string image_id)
    //{
    //    endimageid(image_id);
    //}

    //public void SendFinishSingal(string image_id)
    //{
    //    sendfinished(image_id);
    //}

    //public void CaptureScreen()
    //{
    //    ScreenCapture.CaptureScreenshot("screenshot.png");
    //    TakePhoto("screenshot.png");
    //    //Application.persistentDataPath  /var/mobile/Containers/Data/Application/app sandbox/Documents
    //}

    //public void k_OpenAttachment(SecondModel model)
    //{
    //    OpenAttachment(JsonMapper.ToJson(model));
    //}

    //public void k_LockScreencreen_cancel()
    //{
    //    k_bgImageObjcet.GetComponent<Image>().sprite = Resources.Load<Sprite>("secondbtns/0");
    //    LockScreencreen_cancel();
    //}

    //public void k_LockScreencreen_active()
    //{
    //    LockScreencreen_active();
    //}
}
