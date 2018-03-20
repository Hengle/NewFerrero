using UnityEngine;
using UnityEditor;
using UnityEditor.Callbacks;
using UnityEditor.iOS.Xcode;
using System.IO;

public class Develop_iOS_build : MonoBehaviour
{

    [PostProcessBuild]
    public static void AppendBuildProperty(BuildTarget buildTarget, string pathToBuiltProject)
    {
        if (buildTarget == BuildTarget.iOS)
        { OnPostprocessBuildIOS(pathToBuiltProject); }
    }
    private static void OnPostprocessBuildIOS(string pathToBuiltProject)
    {

        PBXProject proj = new PBXProject();
        // path to pbxproj file
        string projPath = pathToBuiltProject + "/Unity-iPhone.xcodeproj/project.pbxproj";

        var file = File.ReadAllText(projPath);
        proj.ReadFromString(file);
        string target = proj.TargetGuidByName("Unity-iPhone");


        //proj.AddBuildProperty(target, "Bitcode Enable", "No");


        File.WriteAllText(projPath, proj.WriteToString());
    }
}
