using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class TenmetuScript : MonoBehaviour {

	public MoveScript moveScript; 

	private Text tenmetuText;
	private float nextTime;
	public float interval;	// 点滅周期

	public static bool ChangeTrigger;

	CanvasRenderer canvas;
	float alpha;
	 
	// Use this for initialization
	void Start() {
		tenmetuText = gameObject.GetComponent<Text> ();
		canvas = gameObject.GetComponent<CanvasRenderer> ();
		nextTime = Time.time;

		ChangeTrigger = false;
//		this.tenmetuText.text = "右手を上げてください";
		this.tenmetuText.text = "Please Raise Your Right Hand";
	}
	 
	// Update is called once per frame
	void Update() {

		if ( Time.time > nextTime ) {
			alpha = canvas.GetAlpha ();
			if (alpha == 1.0f) {
				canvas.SetAlpha (0.0f);
			} else {
				canvas.SetAlpha (1.0f);
			}
			nextTime += interval;
		}

		if (ChangeTrigger == true) {
			ChangeText ();
		}
	}

	public void ChangeText(){
		ChangeTrigger = false;
//		this.tenmetuText.text = "ジャンプしてください";
		this.tenmetuText.text = "Please Jump";
		MoveScript.UpRightHand = true;
	}
}
