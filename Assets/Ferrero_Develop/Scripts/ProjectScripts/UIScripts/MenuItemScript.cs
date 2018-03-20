using UnityEngine;
using System.Collections;
using ffDevelopmentSpace;


/* 
    Author:     fyw 
    CreateDate: 2018-03-16 14:59:07 
    Desc:       注释 
*/


public class MenuItemScript : MonoBehaviour
{

    #region public property
    public SecondLevelMenuConfigInfo configInfo;
    #endregion
    #region private property
    #endregion

    #region unity function
    void OnEnable()
    {
    }
    void Start()
    {
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
    public void OnClickItem()
    {
        Debug.Log(configInfo.item_url);
//        Singleton<ImageTargetDataModel>.GetInstance().currentUrl = configInfo.item_url;
        ModuleManager.GetInstance().CreateModule(StringConst.Module_WebExporler);
    }
    #endregion
    #region private function
    #endregion

    #region event function
    #endregion
}
