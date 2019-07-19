using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasSetScript : MonoBehaviour {

	public SetPlayerScript setPlayerScript;
	public CanvasRenderer canvasP;
	Text changeTextP;

	float time;
	public static bool changeTriggerP;

	public static int MusicCount;
	public static int changeCount;

	// Use this for initialization
	void Start () {
		setPlayerScript = GameObject.Find ("ReadController").GetComponent<SetPlayerScript> ();

		for (int i = 0; i < 4; i++) {
			setPlayerScript.jump [i] = true;
		}
		for (int i = 0; i < SetPlayerScript.actPlayer; i++) {
			setPlayerScript.jump [i] = false;
		}

		changeTriggerP = false;
		changeTextP = canvasP.GetComponent<Text> ();

		time = 0.0f;

		MusicCount = 0;
		changeCount = 0;
//		changeTextP.text = "右手で頭を触ってください";
		changeTextP.text = "Put your Right Hand on your Hwad";
	}
	
	// Update is called once per frame
	void Update () {
		if ((changeCount == 0) || (changeCount == 2) || (changeCount == 4)) {
			time += Time.deltaTime;
			if (time > 5.0f) {
				time = 0.0f;
				changeTriggerP = true;
			}
		}

		if (changeTriggerP == true) {
			changeCount++;
			TextChangeP (changeCount);
			changeTriggerP = false;
		}
	}

	void TextChangeP(int count){
		switch (count) {
		case 1:
//			changeTextP.text = "全員でジャンプしてください";
			changeTextP.text = "Please Jump with All Player";
			break;
		case 2:
//			changeTextP.text = "右手で頭を触ってください";
			changeTextP.text = "Put your Right Hand on your Hwad";
			MusicCount = 1;
			break;
		case 3:
//			changeTextP.text = "一歩前に進んでください";
			changeTextP.text = "Please Step Forward";
			break;
		case 4:
//			changeTextP.text = "右手で頭を触ってください";
			changeTextP.text = "Put your Right Hand on your Hwad";
			MusicCount = 2;
			break;
		case 5:
//			changeTextP.text = "元の位置に戻ってください";
			changeTextP.text = "Please Return";
			break;
		case 6:
//			changeTextP.text = "全員でジャンプしてゲームスタート";
			changeTextP.text = "Please Jump together to Start Game";
			break;
		default:
			changeTextP.text = "Now Loading";
			break;
		}
				
	}
}
