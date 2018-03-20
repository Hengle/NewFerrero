using UnityEngine;
using System.Collections;
using ffDevelopmentSpace;
using UnityEngine.Networking;
using LitJson;
using UnityEngine.SceneManagement;


/* 
    Author:     fyw 
    CreateDate: 2018-03-13 10:07:16 
    Desc:       注释 
*/


public class LoginModule : BaseModule
{

    #region public property
    #endregion
    #region private property
    private RectTransform mainUiTrans;
    #endregion

    #region unity function
    protected override void InitView()
    {
        mainUiTrans = rectTrans.Find("MainUiPanel").gameObject.GetComponent<RectTransform>();
        //topUiTrans = rectTrans.Find("TopPanel").gameObject.GetComponent<RectTransform>();

        AddClick("MainUiPanel/bg/BtnGroup/LoginBtn");
        AddClick("MainUiPanel/bg/BtnGroup/SettingBtn");
    }
    protected override void InitEffect()
    {
        UITweener twPos = CreateTweener(mainUiTrans, TweenType.TOP_IN);
        SingletonMB<UITweenManagerController>.GetInstance().AddTweener(twPos);

    }
    override protected void OnClick(GameObject obj)
    {
        switch (obj.name)
        {
            case "LoginBtn":
                Debuger.Log("click LoginBtn");
                //OnLogIn();
                Singleton<ModuleEventDispatcher>.GetInstance().addEvent(ModuleEventDispatcher.GAME_LOAD_START, OnLoginEnter);
                SingletonMB<HttpWebManagerControoler>.GetInstance().OnLogIn();
                break;

            case "SettingBtn":
                break;

        }
    }
    public override void OnExit()
    {
        UITweener twPos = CreateTweener(mainUiTrans, TweenType.TOP_OUT);
        twPos.onEnd = ExitHandle;
        SingletonMB<UITweenManagerController>.GetInstance().AddTweener(twPos);

        //twPos = CreateTweener(topUiTrans, TweenType.TOP_OUT);
        //      SingletonMB<UITweenManagerController>.GetInstance().AddTweener(twPos);

    }
    #endregion

    #region public function
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

        request.SetRequestHeader("Content-Type", "application/json");
        //request.SetRequestHeader("CLEARANCE", "I_AM_ADMIN");

        yield return request.Send();

        Debug.Log("Status Code: " + request.responseCode);
        if (request.responseCode == 200)
        {
            string text = request.downloadHandler.text;
            Singleton<LoginModel>.GetInstance().SetLoginData(text);
            Debug.Log(text);
            SceneManager.LoadScene(StringConst.Scene1);
        }

    }
    #endregion
    #region private function


    #endregion

    #region event function
    private void OnLoginEnter(EventObject e)
    {
        ModuleManager.GetInstance().CloseModule(StringConst.Module_Login);
        //SceneManager.LoadScene(StringConst.Scene1);

    }
    #endregion
}
