using UnityEngine;
using System.Collections;
using ffDevelopmentSpace;
using UnityEngine.Networking;
using LitJson;
using System.Text;


/* 
    Author:     fyw 
    CreateDate: 2018-03-14 15:42:22 
    Desc:       注释 
*/


public class HttpWebManagerControoler : SingletonMB<HttpWebManagerControoler>
{

    //#region public property
    //#endregion
    //#region private property
    //#endregion

    //#region unity function
    //void OnEnable()
    //{
    //}
    //void Start()
    //{
    //}
    //void Update()
    //{
    //}
    //void OnDisable()
    //{
    //}
    //void OnDestroy()
    //{
    //}
    //#endregion

    #region Login function
    public void OnLogIn()
    {
        StartCoroutine(LogIn());
        //HttpWebRequest  
    }
    IEnumerator LogIn()
    {
        string url = Singleton<LoginModel>.GetInstance().GetStringWithDataUrl() + "user/login.do";
        UnityWebRequest request = new UnityWebRequest(url, "POST");
        JsonData data = new JsonData();
        //data["license"] = "17N6-UE25-3333-WSCH-LONG";
        data["username"] = Singleton<LoginModel>.GetInstance().login_Name;
        data["password"] = Singleton<LoginModel>.GetInstance().login_Password;
        byte[] postBytes = System.Text.Encoding.Default.GetBytes(data.ToJson());

        request.uploadHandler = (UploadHandler)new UploadHandlerRaw(postBytes);
        request.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
        //request.SetRequestHeader("accept", "application/json; charset=UTF-8");
        request.SetRequestHeader("Content-Type", "application/json");
        //request.SetRequestHeader("CLEARANCE", "I_AM_ADMIN");

        yield return request.Send();

        Debug.Log("Status Code: " + request.responseCode);
        if (request.responseCode == 200)
        {
            string text = request.downloadHandler.text;
            Singleton<LoginModel>.GetInstance().SetLoginData(text);
            Debug.Log(text);
            Singleton<ModuleEventDispatcher>.GetInstance().dispatchEvent(ModuleEventDispatcher.GAME_LOAD_START);
        }

    }
    #endregion

    #region DownLoadTargetImage function
    public void DownloadTargetImage()
    {
        StartCoroutine(LoadImage());
    }
    IEnumerator LoadImage()
    {
        UnityWebRequest request = UnityWebRequest.Get(Singleton<LoginModel>.GetInstance().GetStringWithFileUrl() + "file/downByzip.do?");
        //   
        yield return request.Send();
        //   
        if (request.isNetworkError)
        {
            Debug.Log(request.error);
        }
        else
        {
            if (request.responseCode == 200)
            {
                byte[] results = request.downloadHandler.data;
                //Debug.Log("Application.persistentDataPath=" + AssetConst.ImageSavePath);
                ZipUtility.UnzipFile(results, AssetConst.ImageSavePath);
                Singleton<ModuleEventDispatcher>.GetInstance().dispatchEvent(ModuleEventDispatcher.IMAGE_LOAD_COMPLETE);
                //CreatAllImageTarget();
            }
        }
    }

    #endregion
    #region DownLoadImageData function
    public void DownloadImageData(string imageId)
    {
        Debug.Log(gameObject.name + "DownLoadData");
        StartCoroutine(LoadImageData(imageId));
    }
    //   "http://%@:%@/%@dataserver/points/%@.do"
    IEnumerator LoadImageData(string imageId)
    {
        string url = Singleton<LoginModel>.GetInstance().GetStringWithDataUrl() + "dataserver/points/" + imageId + ".do?v=2&x-access-token=" + Singleton<LoginModel>.GetInstance().GetLoginData_Token();
        //string url = Singleton<LoginModel>.GetInstance().GetStringWithDataUrl() + "dataserver/points/" + imageId + ".do?v=2";
        Debug.Log(url);
        UnityWebRequest request = UnityWebRequest.Get(url);
        //request.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
        request.SetRequestHeader("x-access-token", Singleton<LoginModel>.GetInstance().GetLoginData_Token());
        //request.SetRequestHeader("Content-Type", "application/json");
        //request.SetRequestHeader("accept", "application/json; charset=UTF-8");
        yield return request.Send();
        if (request.isNetworkError)
        {
            Debug.Log(request.error);
        }
        else
        {
            //if (request.responseCode == 200)
            //{
            string text = request.downloadHandler.text;
            //text.Replace("result", "\result");
            //text += "";
            //text = Encoding.UTF8.GetString(request.downloadHandler.data);
            //Debug.Log(gameObject.name + "   json tokon=" + Singleton<LoginModel>.GetInstance().GetLoginData_Token());
            Debug.Log("jason=" + text);
            //string json_test_data = "{\"image_info\":[{\"point_info\":[{\"image_name\":\"1111\",\"item_id\":\"12\",\"item_type\":8,\"item_url\":\"http://10.122.139.4:8088/resources/image/20171207135203.jpg\",\"text\":\"123\"}],\"point_type\":5,\"x\":1567,\"y\":1332},{\"point_info\":[{\"image_name\":\"1111\",\"item_id\":\"12\",\"item_type\":8,\"item_url\":\"http://10.122.139.4:8088/resources/image/20171207135203.jpg\",\"text\":\"123\"}],\"point_type\":5,\"x\":300,\"y\":1332},{\"point_info\":[{\"image_name\":\"1111\",\"item_id\":\"12\",\"item_type\":8,\"item_url\":\"http://10.122.139.4:8088/resources/image/20171207135203.jpg\",\"text\":\"123\"}],\"point_type\":1,\"x\":400,\"y\":400}],\"image_name\":\"c\"}";

            //json_test_data = "{\"image_info\":[{\"point_info\":[{\"item_id\":\"54\",\"item_type\":2,\"item_url\":\"\",\"text\":\"压力过大，请开启泄压阀！！！,当前值:\"}],\"point_type\":2,\"x\":2715,\"y\":1324},{\"point_info\":[{\"item_id\":\"55\",\"item_type\":2,\"item_url\":\"\",\"text\":\" 全自动车床\"}],\"point_type\":2,\"x\":809,\"y\":1224},{\"point_info\":[{\"item_id\":\"56\",\"item_type\":3,\"item_url\":\"http://101.231.84.231:8081/data/index.html?point_id=49&&metric_id=1\",\"text\":\"保养时间,当前值:\"}],\"point_type\":3,\"x\":1487,\"y\":1385},{\"point_info\":[{\"item_id\":\"57\",\"item_type\":9,\"item_url\":\"http://10.122.139.11:8088/resources/pdf/20171220145851.pdf\",\"text\":\"操作手册\"},{\"item_id\":\"58\",\"item_type\":6,\"item_url\":\"http://10.122.139.11:8088/resources/video/20171220145326.mp4\",\"text\":\"操作指导\"}],\"point_type\":4,\"x\":1876,\"y\":1190}],\"image_name\":\"20180314145356\"}";
            //json_test_data ={ "result":"{\"image_info\":[{\"point_info\":[{\"item_id\":\"54\",\"item_type\":2,\"item_url\":\"\",\"text\":\"压力过大，请开启泄压阀！！！,当前值:\"}],\"point_type\":2,\"x\":2715,\"y\":1324},{\"point_info\":[{\"item_id\":\"55\",\"item_type\":2,\"item_url\":\"\",\"text\":\" 全自动车床\"}],\"point_type\":2,\"x\":809,\"y\":1224},{\"point_info\":[{\"item_id\":\"56\",\"item_type\":3,\"item_url\":\"http://101.231.84.231:8081/data/index.html?point_id=49&&metric_id=1\",\"text\":\"保养时间,当前值:\"}],\"point_type\":3,\"x\":1487,\"y\":1385},{\"point_info\":[{\"item_id\":\"57\",\"item_type\":9,\"item_url\":\"http://10.122.139.11:8088/resources/pdf/20171220145851.pdf\",\"text\":\"操作手册\"},{\"item_id\":\"58\",\"item_type\":6,\"item_url\":\"http://10.122.139.11:8088/resources/video/20171220145326.mp4\",\"text\":\"操作指导\"}],\"point_type\":4,\"x\":1876,\"y\":1190}],\"image_name\":\"20180314145356\"}"};
            //Debug.Log("Pason=" + json_test_data);
            Singleton<ImageTargetDataModel>.GetInstance().SetTargetImageData(imageId, text);
            //byte[] results = request.downloadHandler.data;
        }
    }

    #endregion

    #region private function
    #endregion

    #region event function
    #endregion
}
