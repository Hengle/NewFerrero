using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using System.IO;

public class OneKeyToSprite : EditorWindow {

    public  string resourcePath = AppDataPath + "/UI/UIResources";
    public static string targetPath=AppDataPath + "/UI/UIResources";
    private bool ifContain=true;//是否包含子文件
    private bool ifDefault = true;
    static string AppDataPath
    {
        get { return Application.dataPath; }
    }
	// Add menu item to the Window menu
    [MenuItem("GameProject/UI管理/One Key To Sprite")]
	static void Init () {
        //// Get existing open window or if none, make a new one:
        OneKeyToSprite window =EditorWindow.GetWindow<OneKeyToSprite>(false, "One Key To Sprite");
        window.ShowTab();
	}
	void OnGUI () {
        EditorGUILayout.BeginVertical();
        {
            OptionsGUI();
            CreateAndCancelButtonsGUI();
            //TransformToSprite();
        } EditorGUILayout.EndVertical();
	}
   
    private void OptionsGUI()
    {
      if(ifDefault)
      {
          targetPath = resourcePath;
      }
      else
      {
          targetPath = getPath();
      }
        EditorGUILayout.TextField("目标文件夹路径", targetPath);
        ifContain = EditorGUILayout.Toggle("是否包含子目录", ifContain);
        GUILayout.Space(10);
      
        //BuildAssetResource();
    }
    private void CreateAndCancelButtonsGUI()
    {
        EditorGUILayout.BeginHorizontal();
        {
            if (GUILayout.Button("默认", GUILayout.Width(80)))
            {
                Debug.Log("设置默认") ;
                ifDefault = true;
            }
            //GUI.enabled = CanCreate();
            if (GUILayout.Button("确定", GUILayout.Width(80)))
           {
               //resourcePath = targetPath;
               ifDefault = false;
               //TransformToSprite();
           }

        } EditorGUILayout.EndHorizontal();
    }
    private bool CanCreate()
    {
        if (!Selection.activeObject) return false;
        string path = AssetDatabase.GetAssetPath(Selection.activeObject);
        if (path == "") return false;
        return path != "";
    }
    private void TransformToSprite()
    {
        //Debug.Log("转化成sprite");
        resourcePath = getPath();
        //string[] fileEntries = Directory.GetFiles(path, "*.png");
        //if (ifContain)
        //{
        //    ProcessDirectory(path);
        //}
        //else
        //{
        //    foreach (string fileName in fileEntries)
        //     ProcessFile(fileName);
        //}
    }
	
    private string getPath()
    {
        if (!Selection.activeObject) return "";
        string path = AssetDatabase.GetAssetPath(Selection.activeObject);
        path = path.Replace("Assets/", "");
        path = Application.dataPath + "/" + path;
        return path;
    }
}


