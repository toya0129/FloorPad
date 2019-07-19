using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player03TriggerPrac : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	void OnTriggerStay(Collider c){
		if (c.name == "Head03") {
			Player03MusicPrac.PracPlayer03 = true;
			Player03MusicPrac.PracBody = true;
		}
	}

	void OnTriggerExit(Collider c){
		Player03MusicPrac.PracPlayer03 = false;
		Player03MusicPrac.PracBody = false;
	}
}
