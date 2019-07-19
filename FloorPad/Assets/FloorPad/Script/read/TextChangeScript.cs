using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextChangeScript : MonoBehaviour {

	public static LoadScript loadScript;

	public Camera[] selectCamera;
	public CanvasRenderer canvas;

	Text changetext;
	private string[] nowMusic;
	public static int now;
	public static bool changeTrigger;

	// Use this for initialization
	void Start () {
		loadScript = GameObject.Find ("SceneController").GetComponent<LoadScript> ();
		changeTrigger = false;
		changetext = canvas.GetComponent<Text> ();

		now = 0;
		nowMusic = new string[4]{ "Guitar", "Bass", "Keybord", "Misc" };
		TextChange (now);
//		changetext.text = nowMusic[now] + "を演奏したい人は右手を挙げる";
		changetext.text = "Raise Your Right Hand who want to play the " + nowMusic[now];
	}

	// Update is called once per frame
	void Update (){

		if (changeTrigger == true) {
			now++;
			if (now < loadScript.getPlayerCount ()) {
				TextChange (now);
				changeTrigger = false;
			} else if (now == loadScript.getPlayerCount ()) {
				now = 4;
				TextChange (now);
				changeTrigger = false;
			} else if (now > 4) {//
				TextChange (now);
				changeTrigger = false;
			}
		}
	}

	void TextChange(int n){
		for(int i=0;i<4;i++){
			selectCamera [i].backgroundColor = new Color (255, 255, 255);
		}

		switch (n) {
		case 0:
//			changetext.text = nowMusic[n] + "を演奏したい人は右手を挙げる";
			changetext.text = "Raise Right Hand who want to play the " + nowMusic[now];
			selectCamera [n].backgroundColor = new Color (255, 0, 0);
			break;
		case 1:
//			changetext.text = nowMusic[n] + "を演奏したい人は右手を挙げる";
			changetext.text = "Raise Right Hand who want to play the " + nowMusic[now];
			selectCamera [n].backgroundColor = new Color (0, 0, 255);
			break;
		case 2:
//			changetext.text = nowMusic[n] + "を演奏したい人は右手を挙げる";
			changetext.text = "Raise Right Hand who want to play the " + nowMusic[now];
			selectCamera [n].backgroundColor = new Color (255, 255, 0);
			break;
		case 3:
//			changetext.text = nowMusic[n] + "を演奏したい人は右手を挙げる";
			changetext.text = "Raise Right Hand who want to play the " + nowMusic[now];
			selectCamera [n].backgroundColor = new Color (0, 255, 0);
			break;
		case 4:
//			changetext.text = "全員でジャンプして次へ進む";
			changetext.text = "Please Jump with All Players";
			selectCamera [0].backgroundColor = new Color (255, 0, 0);
			selectCamera [1].backgroundColor = new Color (0, 0, 255);
			selectCamera [2].backgroundColor = new Color (255, 255, 0);
			selectCamera [3].backgroundColor = new Color (0, 255, 0);
			break;
		default:
			changetext.text = "Now Loading";//
			break;//
		}
	}
}

