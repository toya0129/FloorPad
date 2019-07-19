using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player01TriggerController : MonoBehaviour {

	public Player01MusicController player01MusicController;
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
		Player01MusicController.Hand = SetHand;
	}

	void OnTriggerStay(Collider c){
		if (Player01MusicController.Hand == "F") {
			Player01MusicController.Hand = SetHand;
		}

		if (Player01MusicController.Hand == SetHand) {
			switch (c.name) {

			case "Head01":
				Player01MusicController.Player01 = true;
				Player01MusicController.Body [0] = true;
				break;

			case "Chest01":
				Player01MusicController.Player01 = true;
				Player01MusicController.Body [1] = true;
				break;

			case "Stomach01":
				Player01MusicController.Player01 = true;
				Player01MusicController.Body [2] = true;
				break;

			case "Elbow01":
				Player01MusicController.Player01 = true;
				Player01MusicController.Body [3] = true;
				break;

			case "Shoulder01":
				Player01MusicController.Player01 = true;
				Player01MusicController.Body [4] = true;
				break;

			case "LegL01":
				Player01MusicController.Player01 = true;
				Player01MusicController.Body [5] = true;
				break;

			case "LegR01":
				Player01MusicController.Player01 = true;
				Player01MusicController.Body [6] = true;
				break;
			}
		}
	}

	void OnTriggerExit(Collider c){
		Player01MusicController.Player01 = false;
		Player01MusicController.Hand = "F";
		for(int i=0;i<7;i++){
			Player01MusicController.Body [i] = false;
		}
	}
}
