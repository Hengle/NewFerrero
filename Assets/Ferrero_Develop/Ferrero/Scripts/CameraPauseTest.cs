using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;
namespace EasyAR
{

    public class CameraPauseTest : MonoBehaviour
    {
        public bool isStart = true;
		void Start () 
		{
			GameObject button = GameObject.Find("Canvas/Pause");//
//			EventTriggerListener.Get(button.gameObject).onClick = OnButtonClick;
		}

		private void OnButtonClick(GameObject go){
//			UnitytoIOS imgtarget = FindObjectOfType<UnitytoIOS>();
//			Button mbtn = go.GetComponent<Button>(); 
//			CameraDeviceBehaviour cameradevice = FindObjectOfType<CameraDeviceBehaviour>();
//
//			if (isStart){				
//				mbtn.image.sprite = Resources.Load<Sprite>("firstbtns/look_active");  
//				cameradevice.StopCapture();
//				isStart = !isStart;
//				imgtarget.k_LockScreencreen_active();
//			}else{
//				mbtn.image.sprite = Resources.Load<Sprite>("firstbtns/look");
////				imgtarget.SetBackgroundTransparent();
//				isStart = !isStart;
//				cameradevice.StartCapture();
//				GameObject currenttarget = GameObject.Find(imgtarget.k_targetName);
//				currenttarget.SetActive(false);
//				imgtarget.k_LockScreencreen_cancel();
//
//			}

		}

    }
}