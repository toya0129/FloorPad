using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player03MusicPrac : MonoBehaviour {

	public static bool PracPlayer03;
	public static bool PracBody;

	public AudioClip[] Player03SoundPrac;
	AudioSource Sound03Prac;

	// Use this for initialization
	void Start () {
		Sound03Prac = GetComponent<AudioSource> ();
		PracPlayer03 = false;
		PracBody = false;
	}

	// Update is called once per frame
	void Update () {
		if (PracPlayer03 == true) {
			if (PracBody == true) {
				Sound03Prac.clip = Player03SoundPrac [CanvasSetScript.MusicCount];
				PracBody = false;
			}
			if (!Sound03Prac.isPlaying) {
				Sound03Prac.Play ();
			}
		} else {
			Sound03Prac.Stop ();
		}
	}
}