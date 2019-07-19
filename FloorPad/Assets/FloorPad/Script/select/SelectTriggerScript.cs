using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SelectTriggerScript : MonoBehaviour {

	public LoadScript loadScript;

	private int stomachCount;

	// Use this for initialization
	void Start () {
		loadScript = GameObject.Find ("SceneController").GetComponent<LoadScript> ();
		stomachCount = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (loadScript.nowSceneName == "PlayerSelectScene") {
			if ((stomachCount >= 2) && (CanvasScript.selectImage != 0)) {
				stomachCount = 0;
				MoveScript.readLoad = true;
			}
		}
	}

	void OnTriggerEnter(Collider touch){
		if (loadScript.nowSceneName == "PlayerSelectScene") {
			if (touch.name == ("HeadT")) {
				stomachCount = 0;
				if (CanvasScript.selectImage < 3) {
					CanvasScript.selectImage++;
				} else if (CanvasScript.selectImage == 3) {
					CanvasScript.selectImage = 1;
				}
				CanvasScript.setColor = true;
			} else if (touch.name == ("Stomach")) {
				stomachCount++;
			}
		}
	}
}
