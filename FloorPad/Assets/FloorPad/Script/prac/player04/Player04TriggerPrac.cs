using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player04TriggerPrac : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	void OnTriggerStay(Collider c){
		if (c.name == "Head04") {
			Player04MusicPrac.PracPlayer04 = true;
			Player04MusicPrac.PracBody = true;
		}
	}

	void OnTriggerExit(Collider c){
		Player04MusicPrac.PracPlayer04 = false;
		Player04MusicPrac.PracBody = false;
	}
}
