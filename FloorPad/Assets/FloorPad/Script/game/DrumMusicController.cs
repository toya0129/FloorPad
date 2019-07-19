using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrumMusicController : MonoBehaviour {

	public LoadScript loadScript;

	AudioClip[,] DrumSound;
	AudioSource DrumMusic;
	public int BPM;
	public float[] MusicTotalTime = { 12.0f, 9.6f, 8.0f, 6.8f, 6.0f };//楽器のデータ時間
	private bool drumTrigger;

	public bool[] PlayerJump = new bool[4]{ true, true, true, true };
	private bool jumpTrigger = false;
	private int actPlayer;

	//音程 0:0 1:+1 2:+2 3:-1 4:-2
	public int[] key = new int[4]{0,0,0,0};

	public AudioClip[] drumSound_BPM80;
	public AudioClip[] drumSound_BPM100;
	public AudioClip[] drumSound_BPM120;
	public AudioClip[] drumSound_BPM140;
	public AudioClip[] drumSound_BPM160;

	public int drumSelect; //ドラムの種類

	public bool trigger;//ドラム音源手動切り替え

	public float getSoundTime()
	{
		return DrumMusic.time;
	}
		
	// Use this for initialization
	void Start () {
		loadScript = GameObject.Find ("SceneController").GetComponent<LoadScript> ();
		actPlayer = loadScript.getPlayerCount ();

		for (int i = 0; i < actPlayer; i++) {
			PlayerJump [i] = false;
		}

		DrumSound = new AudioClip[5, 3];
		for (int i = 0; i < 3; i++) {
			DrumSound [0, i] = drumSound_BPM80 [i];
			DrumSound [1, i] = drumSound_BPM100 [i];
			DrumSound [2, i] = drumSound_BPM120 [i];
			DrumSound [3, i] = drumSound_BPM140 [i];
			DrumSound [4, i] = drumSound_BPM160 [i];
		}

		drumTrigger = true;
		BPM = 0;
		DrumMusic = gameObject.GetComponent<AudioSource>();
		DrumMusic.clip = DrumSound[BPM,drumSelect];

		Debug.Log (80+BPM*20);
		trigger = false;

		MusicStart ();
	}

	void Update(){

		//ジャンプ処理
		if ((PlayerJump [0] == true) && (PlayerJump [1] == true) && (PlayerJump [2] == true) && (PlayerJump [3] == true)) {
			if (jumpTrigger == true) {
				
			} else {

				jumpTrigger = true;

//				for (int i = 0; i < actPlayer; i++) {
//					PlayerJump [i] = false;
//				}

				drumTrigger = false;

				if (BPM != 4) {
					BPM++;
				} else {
					BPM = 0;
				}

				Debug.Log (80 + BPM * 20);

			}
		}else {
			jumpTrigger = false;
		}

		if (drumTrigger == false) {
			DrumMusic.Stop ();
			DrumMusic.clip=DrumSound[BPM,drumSelect];
			MusicStart();
			drumTrigger = true;
		}

		//ドラム音源手動切り替え
		if (trigger == true) {
			if (BPM != 4) {
				BPM++;
			} else {
				BPM = 0;
			}
			DrumMusic.clip = DrumSound [BPM, drumSelect];
			MusicStart();
			trigger = false;
		}
	}

	//ドラム音楽再生
	public void MusicStart(){
		DrumMusic.Play ();
	}
}
