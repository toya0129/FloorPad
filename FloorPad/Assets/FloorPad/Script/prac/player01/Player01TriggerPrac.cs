using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player01TriggerPrac : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerStay(Collider c){
		if (c.name == "Head01") {
			Player01MusicPrac.PracPlayer01 = true;
			Player01MusicPrac.PracBody = true;
		}
	}

	void OnTriggerExit(Collider c){
		Player01MusicPrac.PracPlayer01 = false;
		Player01MusicPrac.PracBody = false;
	}
}
