using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player01MusicController : MonoBehaviour {

	public DrumMusicController drumMusicController;

	private GuitarSoundLoad guitarSoundLoad;
	private BassSoundLoad bassSoundLoad;
	private KeybordSoundLoad keybordSoundLoad;
	private MiscSoundLoad miscSoundLoad;

	private GameObject soundList;

	public static AudioSource PlayerSound01;

	public bool guitar;
	private bool nowGuitar;
	public bool bass;
	private bool nowBass;
	public bool keybord;
	private bool nowKeybord;
	public bool misc;
	private bool nowMisc;

	public static bool Player01;
	public static string Hand;
	public static bool[] Body = new bool[7];


	// Use this for initialization
	void Start () {
		soundList = GameObject.Find ("SoundList");
		guitarSoundLoad = soundList.GetComponent<GuitarSoundLoad> ();
		bassSoundLoad = soundList.GetComponent<BassSoundLoad> ();
		keybordSoundLoad = soundList.GetComponent<KeybordSoundLoad> ();
		miscSoundLoad = soundList.GetComponent<MiscSoundLoad> ();

		guitar = true;
		bass = false;
		keybord = false;
		misc = false;

		nowGuitar = guitar;
		nowBass = bass;
		nowKeybord = keybord;
		nowMisc = misc;

		PlayerSound01 = gameObject.GetComponent<AudioSource> ();
		Player01 = false;
		Hand = "F";

	}
	
	// Update is called once per frame
	void Update () {
//		if (Player01 == true) {

		if (nowGuitar != guitar) {
			if (guitar == true) {
				bass = false;
				keybord = false;
				misc = false;
			}
		}
		if (nowBass != bass) {
			if (bass == true) {
				guitar = false;
				keybord = false;
				misc = false;
			}
		}
		if (nowKeybord != keybord) {
			if (keybord == true) {
				guitar = false;
				bass = false;
				misc = false;
			}
		}
		if (nowMisc != misc) {
			if (misc == true) {
				guitar = false;
				keybord = false;
				bass = false;
			}
		}
			
		if (guitar == true) {
			if (Hand == "R") {
				for (int i = 0; i < 7; i++) {
					if (Body [i] == true) {
						if ((PlayerSound01.clip == null) || (PlayerSound01.clip != guitarSoundLoad.Sound01R [drumMusicController.BPM] [drumMusicController.key [0]] [i])) {
							PlayerSound01.clip = guitarSoundLoad.Sound01R [drumMusicController.BPM] [drumMusicController.key [0]] [i];
						}
						Body [i] = false;
					}
				}
			} else if (Hand == "L") {
				for (int i = 0; i < 7; i++) {
					if (Body [i] == true) {
						if ((PlayerSound01.clip == null) || (PlayerSound01.clip != guitarSoundLoad.Sound01L [drumMusicController.BPM] [drumMusicController.key [0]] [i])) {
							PlayerSound01.clip = guitarSoundLoad.Sound01L [drumMusicController.BPM] [drumMusicController.key [0]] [i];
						}
						Body [i] = false;
					}
				}
			}
		} else if (bass == true) {
			if (Hand == "R") {
				for (int i = 0; i < 7; i++) {
					if (Body [i] == true) {
						if ((PlayerSound01.clip == null) || (PlayerSound01.clip != bassSoundLoad.Sound02R [drumMusicController.BPM] [drumMusicController.key [0]] [i])) {
							PlayerSound01.clip = bassSoundLoad.Sound02R [drumMusicController.BPM] [drumMusicController.key [0]] [i];
						}
						Body [i] = false;
					}
				}
			} else if (Hand == "L") {
				for (int i = 0; i < 7; i++) {
					if (Body [i] == true) {
						if ((PlayerSound01.clip == null) || (PlayerSound01.clip != bassSoundLoad.Sound02L [drumMusicController.BPM] [drumMusicController.key [0]] [i])) {
							PlayerSound01.clip = bassSoundLoad.Sound02L [drumMusicController.BPM] [drumMusicController.key [0]] [i];
						}
						Body [i] = false;
					}
				}
			}
		} else if (keybord == true) {
			if (Hand == "R") {
				for (int i = 0; i < 7; i++) {
					if (Body [i] == true) {
						if ((PlayerSound01.clip == null) || (PlayerSound01.clip != keybordSoundLoad.Sound03R [drumMusicController.BPM] [drumMusicController.key [0]] [i])) {
							PlayerSound01.clip = keybordSoundLoad.Sound03R [drumMusicController.BPM] [drumMusicController.key [0]] [i];
						}
						Body [i] = false;
					}
				}
			} else if (Hand == "L") {
				for (int i = 0; i < 7; i++) {
					if (Body [i] == true) {
						if ((PlayerSound01.clip == null) || (PlayerSound01.clip != keybordSoundLoad.Sound03L [drumMusicController.BPM] [drumMusicController.key [0]] [i])) {
							PlayerSound01.clip = keybordSoundLoad.Sound03L [drumMusicController.BPM] [drumMusicController.key [0]] [i];
						}
						Body [i] = false;
					}
				}
			}
		} else if (misc == true) {
			if (Hand == "R") {
				for (int i = 0; i < 7; i++) {
					if (Body [i] == true) {
						if ((PlayerSound01.clip == null) || (PlayerSound01.clip != miscSoundLoad.Sound04R [drumMusicController.BPM] [drumMusicController.key [0]] [i])) {
							PlayerSound01.clip = miscSoundLoad.Sound04R [drumMusicController.BPM] [drumMusicController.key [0]] [i];
						}
						Body [i] = false;
					}
				}
			} else if (Hand == "L") {
				for (int i = 0; i < 7; i++) {
					if (Body [i] == true) {
						if ((PlayerSound01.clip == null) || (PlayerSound01.clip != miscSoundLoad.Sound04L [drumMusicController.BPM] [drumMusicController.key [0]] [i])) {
							PlayerSound01.clip = miscSoundLoad.Sound04L [drumMusicController.BPM] [drumMusicController.key [0]] [i];
						}
						Body [i] = false;
					}
				}
			}
		}

		if (Player01 == true) {
			if (!PlayerSound01.isPlaying) {
				PlayerSound01.time = drumMusicController.getSoundTime () % drumMusicController.MusicTotalTime [drumMusicController.BPM];
				PlayerSound01.Play ();
			}

		} else {
			PlayerSound01.Stop ();
		}
		nowGuitar = guitar;
		nowBass = bass;
		nowKeybord = keybord;
		nowMisc = misc;
	}
//	}
}