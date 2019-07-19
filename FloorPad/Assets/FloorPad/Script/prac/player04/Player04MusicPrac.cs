using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player04MusicPrac : MonoBehaviour {

	public static bool PracPlayer04;
	public static bool PracBody;

	public AudioClip[] Player04SoundPrac;
	AudioSource Sound04Prac;

	// Use this for initialization
	void Start () {
		Sound04Prac = GetComponent<AudioSource> ();
		PracPlayer04 = false;
		PracBody = false;
	}

	// Update is called once per frame
	void Update () {
		if (PracPlayer04 == true) {
			if (PracBody == true) {
				Sound04Prac.clip = Player04SoundPrac [CanvasSetScript.MusicCount];
				PracBody = false;
			}
			if (!Sound04Prac.isPlaying) {
				Sound04Prac.Play ();
			}
		} else {
			Sound04Prac.Stop ();
		}
	}
}