using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player02MusicPrac : MonoBehaviour {

	public static bool PracPlayer02;
	public static bool PracBody;

	public AudioClip[] Player02SoundPrac;
	AudioSource Sound02Prac;

	// Use this for initialization
	void Start () {
		Sound02Prac = GetComponent<AudioSource> ();
		PracPlayer02 = false;
		PracBody = false;
	}

	// Update is called once per frame
	void Update () {
		if (PracPlayer02 == true) {
			if (PracBody == true) {
				Sound02Prac.clip = Player02SoundPrac [CanvasSetScript.MusicCount];
				PracBody = false;
			}
			if (!Sound02Prac.isPlaying) {
				Sound02Prac.Play ();
			}
		} else {
			Sound02Prac.Stop ();
		}
	}
}