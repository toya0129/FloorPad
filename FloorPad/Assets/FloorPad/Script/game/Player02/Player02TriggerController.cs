using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player02TriggerController : MonoBehaviour {

	public Player02MusicController player02MusicController;
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
		Player02MusicController.Hand = SetHand;
	}

	void OnTriggerStay(Collider c){
		if (Player02MusicController.Hand == "F") {
			Player02MusicController.Hand = SetHand;
		}

		if (Player02MusicController.Hand == SetHand) {
			switch (c.name) {

			case "Head02":
				Player02MusicController.Player02 = true;
				Player02MusicController.Body [0] = true;
				break;

			case "Chest02":
				Player02MusicController.Player02 = true;
				Player02MusicController.Body [1] = true;
				break;

			case "Stomach02":
				Player02MusicController.Player02 = true;
				Player02MusicController.Body [2] = true;
				break;

			case "Elbow02":
				Player02MusicController.Player02 = true;
				Player02MusicController.Body [3] = true;
				break;

			case "Shoulder02":
				Player02MusicController.Player02 = true;
				Player02MusicController.Body [4] = true;
				break;

			case "LegL02":
				Player02MusicController.Player02 = true;
				Player02MusicController.Body [5] = true;
				break;

			case "LegR02":
				Player02MusicController.Player02 = true;
				Player02MusicController.Body [6] = true;
				break;
			}
		}
	}

	void OnTriggerExit(Collider c){
		Player02MusicController.Player02 = false;
		Player02MusicController.Hand = "F";
		for(int i=0;i<7;i++){
			Player02MusicController.Body [i] = false;
		}
	}
}
