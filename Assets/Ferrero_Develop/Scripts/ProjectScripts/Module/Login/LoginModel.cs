using UnityEngine;
using System.Collections;
using ffDevelopmentSpace;
using LitJson;


/* 
    Author:     fyw 
    CreateDate: 2018-03-13 10:37:35 
    Desc:       注释 
*/


public class LoginModel : ModelBase
{

    #region public property
    private JsonData loginData;
    public string login_Name = "admin";
    public string login_Password = "admin";


    public string data_String = "data";
    public string data_Url = "101.231.84.231";
    public string data_Port = "8081";
    public string file_String = "file";
    public string file_Url = "101.231.84.231";
    public string file_Port = "8081";
    #endregion
    #region private property
    #endregion



    #region public  function
    public string GetStringWithFileUrl()
    {
        return "http://" + file_Url + ":" + file_Port + "/" + file_String + "/";//  //@file/downByzip.do?"
    }
    public string GetStringWithDataUrl()
    {
        return "http://" + data_Url + ":" + data_Port + "/" + data_String + "/";
    }

    public void SetLoginData(string data)
    {
        loginData = JsonMapper.ToObject(data);
        //Debug.Log(loginData["token"]);
        //Debug.Log(loginData.getValue("token"));
        //Debug.Log(JsonMapper.ToJson(loginData));
    }
    public string GetLoginData_Token()
    {
        if (loginData != null)
        {
            return (string)loginData["token"];
        }
        else
        {
            return "";
        }
    }
    #endregion
}
