using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player03TriggerController : MonoBehaviour {

	public Player03MusicController player03MusicController;
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
		Player03MusicController.Hand = SetHand;
	}


	void OnTriggerStay(Collider c){
		if (Player03MusicController.Hand == "F") {
			Player03MusicController.Hand = SetHand;
		}

		if (Player03MusicController.Hand == SetHand) {
			switch (c.name) {

			case "Head03":
				Player03MusicController.Player03 = true;
				Player03MusicController.Body [0] = true;
				break;

			case "Chest03":
				Player03MusicController.Player03 = true;
				Player03MusicController.Body [1] = true;
				break;

			case "Stomach03":
				Player03MusicController.Player03 = true;
				Player03MusicController.Body [2] = true;
				break;

			case "Elbow03":
				Player03MusicController.Player03 = true;
				Player03MusicController.Body [3] = true;
				break;

			case "Shoulder" +
			"03":
				Player03MusicController.Player03 = true;
				Player03MusicController.Body [4] = true;
				break;

			case "LegL03":
				Player03MusicController.Player03 = true;
				Player03MusicController.Body [5] = true;
				break;

			case "LegR03":
				Player03MusicController.Player03 = true;
				Player03MusicController.Body [6] = true;
				break;
			}
		}
	}

	void OnTriggerExit(Collider c){
		Player03MusicController.Player03 = false;
		Player03MusicController.Hand = "F";
		for(int i=0;i<7;i++){
			Player03MusicController.Body [i] = false;
		}
	}
}
