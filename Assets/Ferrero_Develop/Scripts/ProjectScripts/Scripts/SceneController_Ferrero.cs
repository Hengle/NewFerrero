using UnityEngine;
using System.Collections;
using ffDevelopmentSpace;
using LitJson;
using EasyAR;
using System.IO;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;


/* 
    Author:     fyw 
    CreateDate: 2018-03-09 10:09:00 
    Desc:       Ferrero场景控制器
*/


public class SceneController_Ferrero : SingletonMB<SceneController_Ferrero>
{

    #region public property
    public bool ifLocalTest = false;
    #endregion
    #region private property
    #endregion

    #region unity function
    private void Awake()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        Singleton<ModuleEventDispatcher>.GetInstance().addEvent(ModuleEventDispatcher.GAME_LOAD_START, OnLoginEnter);

    }
    void OnEnable()
    {
    }
    void Start()
    {
        if (ifLocalTest)
        {
            string test_json = "{'images':[{\"path\" : \"/Users/eju/Desktop/Pic\",\"type\" : \"jpg\",\"name\" : \"a\"},{\"path\" : \"/Users/eju/Desktop/Pic\",\"type\" : \"jpg\",\"name\" : \"c\"}]}";
            //Get_CreateTarget(test_json);
        }
        else
        {
            //Unity2IOS.Set_StartInitial();
        }
    }
    void Update()
    {
    }
    void OnDisable()
    {
    }
    void OnDestroy()
    {
    }
    #endregion

    #region public function

    //}

    private void CreatAllImageTarget()
    {
        //路径  

        //获取指定路径下面的所有资源文件  
        if (Directory.Exists(AssetConst.ImageSavePath))
        {
            DirectoryInfo direction = new DirectoryInfo(AssetConst.ImageSavePath);
            FileInfo[] files = direction.GetFiles("*", SearchOption.AllDirectories);
            Debug.Log(files.Length);

            for (int i = 0; i < files.Length; i++)
            {
                if (Path.GetExtension(files[i].Name).ToLower() == ".jpg")
                {
                    //Debug.Log("Name:" + Path.GetFileNameWithoutExtension(files[i].Name));
                    GameObject ImageTarget = new GameObject(Path.GetFileNameWithoutExtension(files[i].Name));
                    //ImageTarget.SetActive(true);
                    ImageTarget.transform.localPosition = Vector3.zero;

                    ImageTrackerBehaviour tracker = FindObjectOfType<ImageTrackerBehaviour>();
                    ImageTargetController targetController = ImageTarget.AddComponent<ImageTargetController>();
                    FerreroImageTargetBehaviour targetBehaviour = ImageTarget.AddComponent<FerreroImageTargetBehaviour>();
                    targetBehaviour.Bind(tracker);
                    targetBehaviour.SetupWithImage(files[i].FullName, StorageType.Absolute, ImageTarget.name, new Vector2());
                    //创建画布
                    GameObject canvas = Instantiate(Resources.Load("picCanvas")) as GameObject;
                    canvas.GetComponent<RectTransform>().sizeDelta = Singleton<ImageTargetDataModel>.GetInstance().GetPadWH();
                    targetBehaviour.Bind(tracker);
                    Vector3 scaleP = Vector3.one * Singleton<ImageTargetDataModel>.GetInstance().GetScaleFatorFor(1);
                    //Debug.Log("scaleP=" + scaleP);
                    canvas.GetComponent<RectTransform>().localScale = scaleP;
                    GameObject backGroundImage = canvas.transform.Find("backgroundImage").gameObject;

                    backGroundImage.GetComponent<RectTransform>().sizeDelta = new Vector2(canvas.GetComponent<RectTransform>().sizeDelta.x, canvas.GetComponent<RectTransform>().sizeDelta.y);
                    targetController.BG_IMG = backGroundImage;
                    targetController.m_canvas = canvas;
                    //Debug.Log("Load Canvas Prefab Suceess=======================" + canvas.name);
                    canvas.transform.parent = targetBehaviour.gameObject.transform;
                }
            }

            //Debug.Log( "FullName:" + files[i].FullName );  
            //Debug.Log( "DirectoryName:" + files[i].DirectoryName );  
        }
    }
    #endregion
    #region private function
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        return;
        SceneManager.sceneLoaded -= OnSceneLoaded;
        Debug.Log("OnSceneLoaded: " + scene.name);
        Debug.Log(mode);
        Singleton<ModuleEventDispatcher>.GetInstance().addEvent(ModuleEventDispatcher.IMAGE_LOAD_COMPLETE, OnImageLoaded);
        SingletonMB<HttpWebManagerControoler>.GetInstance().DownloadTargetImage();
    }


    #endregion

    #region event function
    private void OnImageLoaded(EventObject e)
    {
        CreatAllImageTarget();
    }
    private void OnLoginEnter(EventObject e)
    {
        Singleton<ModuleEventDispatcher>.GetInstance().addEvent(ModuleEventDispatcher.IMAGE_LOAD_COMPLETE, OnImageLoaded);
        SingletonMB<HttpWebManagerControoler>.GetInstance().DownloadTargetImage();
    }
    #endregion

    //private void DownloadTargetImage()
    //{
    //    StartCoroutine(LoadImage());
    //}
    //IEnumerator LoadImage()
    //{
    //    string sPath = Application.persistentDataPath + "/test.xml";
    //    //============
    //    UnityWebRequest request = UnityWebRequest.Get(Singleton<LoginModel>.GetInstance().GetStringWithFileUrl() + "file/downByzip.do?");
    //    //   
    //    yield return request.Send();
    //    //   
    //    if (request.isNetworkError)
    //    {
    //        Debug.Log(request.error);
    //    }
    //    else
    //    {
    //        if (request.responseCode == 200)
    //        {
    //            byte[] results = request.downloadHandler.data;
    //            //Debug.Log("Application.persistentDataPath=" + AssetConst.ImageSavePath);
    //            ZipUtility.UnzipFile(results, AssetConst.ImageSavePath);

    //        }
    //    }
    //public void DownLoadData()
    //{

    //    //if (gameObject.name != "20171220144045") return;
    //    Debug.Log(gameObject.name + "DownLoadData");
    //    //return;
    //    StartCoroutine(LoadData());
    //}
    ////   "http://%@:%@/%@dataserver/points/%@.do"
    //IEnumerator LoadData()
    //{
    //    string url = Singleton<LoginModel>.GetInstance().GetStringWithDataUrl() + "dataserver/points/" + "20171220144045" + ".do?x-access-token=" + Singleton<LoginModel>.GetInstance().GetLoginData_Token();
    //    Debug.Log(url);
    //    //UnityWebRequest request = new UnityWebRequest(url, "GET");
    //    UnityWebRequest request = UnityWebRequest.Get(url);
    //    //data["x-access-token"] = Singleton<LoginModel>.GetInstance().GetLoginData_Token();
    //    //byte[] postBytes = System.Text.Encoding.Default.GetBytes(data.ToJson());
    //    //request.uploadHandler = (UploadHandler)new UploadHandlerRaw(postBytes);
    //    request.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
    //    //request.SetRequestHeader("x-access-token", Singleton<LoginModel>.GetInstance().GetLoginData_Token());
    //    //request = UnityWebRequest.Post(url, Singleton<LoginModel>.GetInstance().GetLoginData_Token());


    //    yield return request.Send();
    //    //   
    //    Debug.Log("request.Send=");

    //    if (request.isNetworkError)
    //    {
    //        Debug.Log(request.error);
    //    }
    //    else
    //    {
    //        //if (request.responseCode == 200)
    //        //{
    //        //   
    //        //string text = request.downloadHandler.text;
    //        //Debug.Log(gameObject.name + "   json tokon=" + Singleton<LoginModel>.GetInstance().GetLoginData_Token());
    //        Debug.Log("jason=" + request.downloadHandler.text);
    //        //   
    //        //byte[] results = request.downloadHandler.data;
    //        //Debug.Log("Application.persistentDataPath=" + AssetConst.ImageSavePath);
    //        //ZipUtility.UnzipFile(results, AssetConst.ImageSavePath);

    //        //    //}
    //    }
    //}
}
