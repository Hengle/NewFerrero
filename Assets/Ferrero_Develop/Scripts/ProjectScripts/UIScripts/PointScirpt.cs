using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using ffDevelopmentSpace;


/* 
    Author:     fyw 
    CreateDate: 2018-03-16 14:58:44 
    Desc:       一级标注点 UI 交互信息
*/


public class PointScirpt : MonoBehaviour
{

    #region public property
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
    public void OpenMenu()
    {
        this.GetComponent<Image>().enabled = false;
        Debug.Log("OpenMenu");
        ToggleMenuVisible(true);
    }
    public void CloseMenu()
    {
        this.GetComponent<Image>().enabled = true;
        ToggleMenuVisible(false);
    }


    #endregion
    #region private function
    private void ToggleMenuVisible(bool flag)
    {
        Debug.Log("game name =" + gameObject.name);
        //Image[] images = this.gameObject.GetComponentsInChildren<Image>();
        for (int i = 0; i < this.transform.childCount; i++)
        {
            //Debug.Log("menuName=" + images[i].gameObject.name);
            this.transform.GetChild(0).gameObject.SetActive(flag);
        }
        if (flag) Invoke("CloseMenu", 5);
        //Debug.Log("child count=" + this.gameObject.transform.childCount);
        //Debug.Log("child name=" + this.transform.GetChild(0));
    }
    #endregion

    #region event function
    #endregion
}
