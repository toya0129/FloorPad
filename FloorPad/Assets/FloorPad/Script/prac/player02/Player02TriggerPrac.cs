using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player02TriggerPrac : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerStay(Collider c){
		if (c.name == "Head02") {
			Player02MusicPrac.PracPlayer02 = true;
			Player02MusicPrac.PracBody = true;
		}
	}

	void OnTriggerExit(Collider c){
		Player02MusicPrac.PracPlayer02 = false;
		Player02MusicPrac.PracBody = false;
	}
}
