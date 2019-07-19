using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player04TriggerController : MonoBehaviour {

	public Player04MusicController player04MusicController;
	string SetHand;
	// Use this for initialization
	void Start () {
		if (this.gameObject.name == "HandR") {
			SetHand = "R";
		} else if (this.gameObject.name == "HandL") {
			SetHand = "L";
		}
	}

	void OnTriggerEnter(Collider co){
		Player04MusicController.Hand = SetHand;
	}


	void OnTriggerStay(Collider c){
		if (Player04MusicController.Hand == "F") {
			Player04MusicController.Hand = SetHand;
		}

		if (Player04MusicController.Hand == SetHand) {
			switch (c.name) {

			case "Head04":
				Player04MusicController.Player04 = true;
				Player04MusicController.Body [0] = true;
				break;

			case "Chest04":
				Player04MusicController.Player04 = true;
				Player04MusicController.Body [1] = true;
				break;

			case "Stomach04":
				Player04MusicController.Player04 = true;
				Player04MusicController.Body [2] = true;
				break;

			case "Elbow04":
				Player04MusicController.Player04 = true;
				Player04MusicController.Body [3] = true;
				break;

			case "Shoulder" +
				"04":
				Player04MusicController.Player04 = true;
				Player04MusicController.Body [4] = true;
				break;

			case "LegL04":
				Player04MusicController.Player04 = true;
				Player04MusicController.Body [5] = true;
				break;

			case "LegR04":
				Player04MusicController.Player04 = true;
				Player04MusicController.Body [6] = true;
				break;
			}
		}
	}

	void OnTriggerExit(Collider c){
		Player04MusicController.Player04 = false;
		Player04MusicController.Hand = "F";
		for(int i=0;i<7;i++){
			Player04MusicController.Body [i] = false;
		}
	}
}
