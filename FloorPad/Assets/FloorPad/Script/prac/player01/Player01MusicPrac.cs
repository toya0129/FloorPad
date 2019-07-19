using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player01MusicPrac : MonoBehaviour {

	public static bool PracPlayer01;
	public static bool PracBody;

	public AudioClip[] Player01SoundPrac;
	AudioSource Sound01Prac;

	// Use this for initialization
	void Start () {
		Sound01Prac = GetComponent<AudioSource> ();
		PracPlayer01 = false;
		PracBody = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (PracPlayer01 == true) {
			if (PracBody == true) {
				Sound01Prac.clip = Player01SoundPrac [CanvasSetScript.MusicCount];
				PracBody = false;
			}
			if (!Sound01Prac.isPlaying) {
				Sound01Prac.Play ();
			}
		} else {
			Sound01Prac.Stop ();
		}
	}
}
