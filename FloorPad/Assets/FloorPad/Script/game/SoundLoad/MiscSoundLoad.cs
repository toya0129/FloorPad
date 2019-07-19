using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiscSoundLoad : MonoBehaviour {

	public LoadScript loadScript;

	public List<List<AudioClip[]>> Sound04R;//1:音程 2:テンポ 3:音の種類
	public List<List<AudioClip[]>> Sound04L;

	List<AudioClip[]> Sound04R_80;
	List<AudioClip[]> Sound04R_100;
	List<AudioClip[]> Sound04R_120;
	List<AudioClip[]> Sound04R_140;
	List<AudioClip[]> Sound04R_160;

	List<AudioClip[]> Sound04L_80;
	List<AudioClip[]> Sound04L_100;
	List<AudioClip[]> Sound04L_120;
	List<AudioClip[]> Sound04L_140;
	List<AudioClip[]> Sound04L_160;

	AudioClip[] Sound04R_0_80= new AudioClip[7];
	AudioClip[] Sound04R_0_100 = new AudioClip[7];
	AudioClip[] Sound04R_0_120 = new AudioClip[7];
	AudioClip[] Sound04R_0_140 = new AudioClip[7];
	AudioClip[] Sound04R_0_160 = new AudioClip[7];

	AudioClip[] Sound04R_1_80= new AudioClip[7];
	AudioClip[] Sound04R_1_100 = new AudioClip[7];
	AudioClip[] Sound04R_1_120 = new AudioClip[7];
	AudioClip[] Sound04R_1_140 = new AudioClip[7];
	AudioClip[] Sound04R_1_160 = new AudioClip[7];

	AudioClip[] Sound04R_2_80= new AudioClip[7];
	AudioClip[] Sound04R_2_100 = new AudioClip[7];
	AudioClip[] Sound04R_2_120 = new AudioClip[7];
	AudioClip[] Sound04R_2_140 = new AudioClip[7];
	AudioClip[] Sound04R_2_160 = new AudioClip[7];

	AudioClip[] Sound04R_m1_80= new AudioClip[7];
	AudioClip[] Sound04R_m1_100 = new AudioClip[7];
	AudioClip[] Sound04R_m1_120 = new AudioClip[7];
	AudioClip[] Sound04R_m1_140 = new AudioClip[7];
	AudioClip[] Sound04R_m1_160 = new AudioClip[7];

	AudioClip[] Sound04R_m2_80= new AudioClip[7];
	AudioClip[] Sound04R_m2_100 = new AudioClip[7];
	AudioClip[] Sound04R_m2_120 = new AudioClip[7];
	AudioClip[] Sound04R_m2_140 = new AudioClip[7];
	AudioClip[] Sound04R_m2_160 = new AudioClip[7];

	AudioClip[] Sound04L_0_80= new AudioClip[7];
	AudioClip[] Sound04L_0_100 = new AudioClip[7];
	AudioClip[] Sound04L_0_120 = new AudioClip[7];
	AudioClip[] Sound04L_0_140 = new AudioClip[7];
	AudioClip[] Sound04L_0_160 = new AudioClip[7];

	AudioClip[] Sound04L_1_80= new AudioClip[7];
	AudioClip[] Sound04L_1_100 = new AudioClip[7];
	AudioClip[] Sound04L_1_120 = new AudioClip[7];
	AudioClip[] Sound04L_1_140 = new AudioClip[7];
	AudioClip[] Sound04L_1_160 = new AudioClip[7];

	AudioClip[] Sound04L_2_80= new AudioClip[7];
	AudioClip[] Sound04L_2_100 = new AudioClip[7];
	AudioClip[] Sound04L_2_120 = new AudioClip[7];
	AudioClip[] Sound04L_2_140 = new AudioClip[7];
	AudioClip[] Sound04L_2_160 = new AudioClip[7];

	AudioClip[] Sound04L_m1_80= new AudioClip[7];
	AudioClip[] Sound04L_m1_100 = new AudioClip[7];
	AudioClip[] Sound04L_m1_120 = new AudioClip[7];
	AudioClip[] Sound04L_m1_140 = new AudioClip[7];
	AudioClip[] Sound04L_m1_160 = new AudioClip[7];

	AudioClip[] Sound04L_m2_80= new AudioClip[7];
	AudioClip[] Sound04L_m2_100 = new AudioClip[7];
	AudioClip[] Sound04L_m2_120 = new AudioClip[7];
	AudioClip[] Sound04L_m2_140 = new AudioClip[7];
	AudioClip[] Sound04L_m2_160 = new AudioClip[7];

	public static AudioSource PlayerSound04;

	float StartTime = 2.0f;//ロード開始時間
	float LoadTime; 
	string[] LoadBpm;
	string[] LoadPitch;
	int BpmCount;

	string fileName = "C:\\Users\\toya\\大学資料\\研究室関係\\FFT\\音源データ\\ather";

	void Awake(){
		DontDestroyOnLoad (gameObject);
	}

	// Use this for initialization
	void Start () {
		//Loadするための変数
		LoadBpm = new string[5]{"80", "100", "120", "140", "160" };	
		LoadPitch = new string[5]{ "-2", "-1", "0", "1", "2" };
		BpmCount = 0;
		LoadTime = StartTime;

		Sound04R = new List<List<AudioClip[]>> ();
		Sound04L = new List<List<AudioClip[]>> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (loadScript.soundLoad [3] == true) {
			if (LoadTime > 0) {
				LoadTime -= Time.deltaTime;
			}

			if (LoadTime <= 0) {
				loadScript.soundLoad [3] = false;
				LoadTime = 1.0f;
				StartCoroutine (StreamPlayAudioFile (BpmCount));
				BpmCount++;
			}
		}
	}

	IEnumerator StreamPlayAudioFile(int bpm)
	{
		Debug.Log("AtherのBPM"+LoadBpm[bpm]+"読み込み開始");
		//右手音源データ読み込み
		for(int i =1;i<8;i++){
			for (int j = 0; j < 5; j++) {
				using (WWW www = new WWW ("file:///" + fileName + "\\bpm" + LoadBpm [bpm] + "\\" + LoadPitch [j] + "\\ather" + i.ToString() + "_" + LoadPitch [j] + "_BPM" + LoadBpm [bpm] + ".WAV")) {
					//読み込み完了まで待機
					yield return www;

					if (bpm == 0) {
						if (j == 0) {
							Sound04R_m2_80 [i - 1] = www.GetAudioClip (true, true);
						} else if (j == 1) {
							Sound04R_m1_80 [i - 1] = www.GetAudioClip (true, true);
						} else if (j == 2) {
							Sound04R_0_80 [i - 1] = www.GetAudioClip (true, true);
						} else if (j == 3) {
							Sound04R_1_80 [i - 1] = www.GetAudioClip (true, true);
						} else if (j == 4) {
							Sound04R_2_80 [i - 1] = www.GetAudioClip (true, true);
						}
					}else if (bpm == 1) {
						if (j == 0) {
							Sound04R_m2_100 [i - 1] = www.GetAudioClip (true, true);
						} else if (j == 1) {
							Sound04R_m1_100 [i - 1] = www.GetAudioClip (true, true);
						} else if (j == 2) {
							Sound04R_0_100 [i - 1] = www.GetAudioClip (true, true);
						} else if (j == 3) {
							Sound04R_1_100 [i - 1] = www.GetAudioClip (true, true);
						} else if (j == 4) {
							Sound04R_2_100 [i - 1] = www.GetAudioClip (true, true);
						}
					} else if (bpm == 2) {
						if (j == 0) {
							Sound04R_m2_120 [i - 1] = www.GetAudioClip (true, true);
						} else if (j == 1) {
							Sound04R_m1_120 [i - 1] = www.GetAudioClip (true, true);
						} else if (j == 2) {
							Sound04R_0_120 [i - 1] = www.GetAudioClip (true, true);
						} else if (j == 3) {
							Sound04R_1_120 [i - 1] = www.GetAudioClip (true, true);
						} else if (j == 4) {
							Sound04R_2_120 [i - 1] = www.GetAudioClip (true, true);
						}
					} else if (bpm == 3) {
						if (j == 0) {
							Sound04R_m2_140 [i - 1] = www.GetAudioClip (true, true);
						} else if (j == 1) {
							Sound04R_m1_140 [i - 1] = www.GetAudioClip (true, true);
						} else if (j == 2) {
							Sound04R_0_140 [i - 1] = www.GetAudioClip (true, true);
						} else if (j == 3) {
							Sound04R_1_140 [i - 1] = www.GetAudioClip (true, true);
						} else if (j == 4) {
							Sound04R_2_140 [i - 1] = www.GetAudioClip (true, true);
						}
					} else if (bpm == 4) {
						if (j == 0) {
							Sound04R_m2_160 [i - 1] = www.GetAudioClip (true, true);
						} else if (j == 1) {
							Sound04R_m1_160 [i - 1] = www.GetAudioClip (true, true);
						} else if (j == 2) {
							Sound04R_0_160 [i - 1] = www.GetAudioClip (true, true);
						} else if (j == 3) {
							Sound04R_1_160 [i - 1] = www.GetAudioClip (true, true);
						} else if (j == 4) {
							Sound04R_2_160 [i - 1] = www.GetAudioClip (true, true);
						}
					}
				}
			}
		}

		//左手音源データ読み込み
		for(int i =8;i<15;i++){
			for (int j = 0; j < 5; j++) {
				using (WWW www = new WWW ("file:///" + fileName + "\\bpm" + LoadBpm [bpm] + "\\" + LoadPitch [j] + "\\ather" + i + "_" + LoadPitch [j] + "_BPM" + LoadBpm [bpm] + ".WAV")) 
				{
					//読み込み完了まで待機
					yield return www;

					if (bpm == 0) {
						if (j == 0) {
							Sound04L_m2_80 [i - 8] = www.GetAudioClip (true, true);
						} else if (j == 1) {
							Sound04L_m1_80 [i - 8] = www.GetAudioClip (true, true);
						} else if (j == 2) {
							Sound04L_0_80 [i - 8] = www.GetAudioClip (true, true);
						} else if (j == 3) {
							Sound04L_1_80 [i - 8] = www.GetAudioClip (true, true);
						} else if (j == 4) {
							Sound04L_2_80 [i - 8] = www.GetAudioClip (true, true);
						}
					}else if (bpm == 1) {
						if (j == 0) {
							Sound04L_m2_100 [i - 8] = www.GetAudioClip (true, true);
						} else if (j == 1) {
							Sound04L_m1_100 [i - 8] = www.GetAudioClip (true, true);
						} else if (j == 2) {
							Sound04L_0_100 [i - 8] = www.GetAudioClip (true, true);
						} else if (j == 3) {
							Sound04L_1_100 [i - 8] = www.GetAudioClip (true, true);
						} else if (j == 4) {
							Sound04L_2_100 [i - 8] = www.GetAudioClip (true, true);
						}
					} else if (bpm == 2) {
						if (j == 0) {
							Sound04L_m2_120 [i - 8] = www.GetAudioClip (true, true);
						} else if (j == 1) {
							Sound04L_m1_120 [i - 8] = www.GetAudioClip (true, true);
						} else if (j == 2) {
							Sound04L_0_120 [i - 8] = www.GetAudioClip (true, true);
						} else if (j == 3) {
							Sound04L_1_120 [i - 8] = www.GetAudioClip (true, true);
						} else if (j == 4) {
							Sound04L_2_120 [i - 8] = www.GetAudioClip (true, true);
						}
					} else if (bpm == 3) {
						if (j == 0) {
							Sound04L_m2_140 [i - 8] = www.GetAudioClip (true, true);
						} else if (j == 1) {
							Sound04L_m1_140 [i - 8] = www.GetAudioClip (true, true);
						} else if (j == 2) {
							Sound04L_0_140 [i - 8] = www.GetAudioClip (true, true);
						} else if (j == 3) {
							Sound04L_1_140 [i - 8] = www.GetAudioClip (true, true);
						} else if (j == 4) {
							Sound04L_2_140 [i - 8] = www.GetAudioClip (true, true);
						}
					} else if (bpm == 4) {
						if (j == 0) {
							Sound04L_m2_160 [i - 8] = www.GetAudioClip (true, true);
						} else if (j == 1) {
							Sound04L_m1_160 [i - 8] = www.GetAudioClip (true, true);
						} else if (j == 2) {
							Sound04L_0_160 [i - 8] = www.GetAudioClip (true, true);
						} else if (j == 3) {
							Sound04L_1_160 [i - 8] = www.GetAudioClip (true, true);
						} else if (j == 4) {
							Sound04L_2_160 [i - 8] = www.GetAudioClip (true, true);
						}
					}
				}
			}
		}

		//BPM80読み込み
		if (bpm == 0) {
			Sound04R_80= new List<AudioClip[]> ();
			Sound04R_80.Add (new[] {
				Sound04R_0_80[0],
				Sound04R_0_80[1],
				Sound04R_0_80[2],
				Sound04R_0_80[3],
				Sound04R_0_80[4],
				Sound04R_0_80[5],
				Sound04R_0_80[6]
			});
			Sound04R_80.Add (new[] {
				Sound04R_1_80[0],
				Sound04R_1_80[1],
				Sound04R_1_80[2],
				Sound04R_1_80[3],
				Sound04R_1_80[4],
				Sound04R_1_80[5],
				Sound04R_1_80[6]
			});
			Sound04R_80.Add (new[] {
				Sound04R_2_80[0],
				Sound04R_2_80[1],
				Sound04R_2_80[2],
				Sound04R_2_80[3],
				Sound04R_2_80[4],
				Sound04R_2_80[5],
				Sound04R_2_80[6]
			});
			Sound04R_80.Add (new[] {
				Sound04R_m1_80[0],
				Sound04R_m1_80[1],
				Sound04R_m1_80[2],
				Sound04R_m1_80[3],
				Sound04R_m1_80[4],
				Sound04R_m1_80[5],
				Sound04R_m1_80[6]
			});
			Sound04R_80.Add (new[] {
				Sound04R_m2_80[0],
				Sound04R_m2_80[1],
				Sound04R_m2_80[2],
				Sound04R_m2_80[3],
				Sound04R_m2_80[4],
				Sound04R_m2_80[5],
				Sound04R_m2_80[6]
			});

			Sound04L_80= new List<AudioClip[]> ();
			Sound04L_80.Add (new[] {
				Sound04L_0_80[0],
				Sound04L_0_80[1],
				Sound04L_0_80[2],
				Sound04L_0_80[3],
				Sound04L_0_80[4],
				Sound04L_0_80[5],
				Sound04L_0_80[6]
			});
			Sound04L_80.Add (new[] {
				Sound04L_1_80[0],
				Sound04L_1_80[1],
				Sound04L_1_80[2],
				Sound04L_1_80[3],
				Sound04L_1_80[4],
				Sound04L_1_80[5],
				Sound04L_1_80[6]
			});
			Sound04L_80.Add (new[] {
				Sound04L_2_80[0],
				Sound04L_2_80[1],
				Sound04L_2_80[2],
				Sound04L_2_80[3],
				Sound04L_2_80[4],
				Sound04L_2_80[5],
				Sound04L_2_80[6]
			});
			Sound04L_80.Add (new[] {
				Sound04L_m1_80[0],
				Sound04L_m1_80[1],
				Sound04L_m1_80[2],
				Sound04L_m1_80[3],
				Sound04L_m1_80[4],
				Sound04L_m1_80[5],
				Sound04L_m1_80[6]
			});
			Sound04L_80.Add (new[] {
				Sound04L_m2_80[0],
				Sound04L_m2_80[1],
				Sound04L_m2_80[2],
				Sound04L_m2_80[3],
				Sound04L_m2_80[4],
				Sound04L_m2_80[5],
				Sound04L_m2_80[6]
			});

			Sound04R.Add (Sound04R_80);
			Sound04L.Add (Sound04L_80);

		} 

		//BPM100読み込み
		else if (bpm == 1) {
			Sound04R_100 = new List<AudioClip[]> ();
			Sound04R_100.Add (new[] {
				Sound04R_0_100 [0],
				Sound04R_0_100 [1],
				Sound04R_0_100 [2],
				Sound04R_0_100 [3],
				Sound04R_0_100 [4],
				Sound04R_0_100 [5],
				Sound04R_0_100 [6]
			});
			Sound04R_100.Add (new[] {
				Sound04R_1_100 [0],
				Sound04R_1_100 [1],
				Sound04R_1_100 [2],
				Sound04R_1_100 [3],
				Sound04R_1_100 [4],
				Sound04R_1_100 [5],
				Sound04R_1_100 [6]
			});
			Sound04R_100.Add (new[] {
				Sound04R_2_100 [0],
				Sound04R_2_100 [1],
				Sound04R_2_100 [2],
				Sound04R_2_100 [3],
				Sound04R_2_100 [4],
				Sound04R_2_100 [5],
				Sound04R_2_100 [6]
			});
			Sound04R_100.Add (new[] {
				Sound04R_m1_100 [0],
				Sound04R_m1_100 [1],
				Sound04R_m1_100 [2],
				Sound04R_m1_100 [3],
				Sound04R_m1_100 [4],
				Sound04R_m1_100 [5],
				Sound04R_m1_100 [6]
			});
			Sound04R_100.Add (new[] {
				Sound04R_m2_100 [0],
				Sound04R_m2_100 [1],
				Sound04R_m2_100 [2],
				Sound04R_m2_100 [3],
				Sound04R_m2_100 [4],
				Sound04R_m2_100 [5],
				Sound04R_m2_100 [6]
			});

			Sound04L_100 = new List<AudioClip[]> ();
			Sound04L_100.Add (new[] {
				Sound04L_0_100 [0],
				Sound04L_0_100 [1],
				Sound04L_0_100 [2],
				Sound04L_0_100 [3],
				Sound04L_0_100 [4],
				Sound04L_0_100 [5],
				Sound04L_0_100 [6]
			});
			Sound04L_100.Add (new[] {
				Sound04L_1_100 [0],
				Sound04L_1_100 [1],
				Sound04L_1_100 [2],
				Sound04L_1_100 [3],
				Sound04L_1_100 [4],
				Sound04L_1_100 [5],
				Sound04L_1_100 [6]
			});
			Sound04L_100.Add (new[] {
				Sound04L_2_100 [0],
				Sound04L_2_100 [1],
				Sound04L_2_100 [2],
				Sound04L_2_100 [3],
				Sound04L_2_100 [4],
				Sound04L_2_100 [5],
				Sound04L_2_100 [6]
			});
			Sound04L_100.Add (new[] {
				Sound04L_m1_100 [0],
				Sound04L_m1_100 [1],
				Sound04L_m1_100 [2],
				Sound04L_m1_100 [3],
				Sound04L_m1_100 [4],
				Sound04L_m1_100 [5],
				Sound04L_m1_100 [6]
			});
			Sound04L_100.Add (new[] {
				Sound04L_m2_100 [0],
				Sound04L_m2_100 [1],
				Sound04L_m2_100 [2],
				Sound04L_m2_100 [3],
				Sound04L_m2_100 [4],
				Sound04L_m2_100 [5],
				Sound04L_m2_100 [6]
			});

			Sound04R.Add (Sound04R_100);
			Sound04L.Add (Sound04L_100);

		} 
		//BPM120読み込み	
		else if (bpm == 2) {
			Sound04R_120 = new List<AudioClip[]> ();
			Sound04R_120.Add (new[] {
				Sound04R_0_120 [0],
				Sound04R_0_120 [1],
				Sound04R_0_120 [2],
				Sound04R_0_120 [3],
				Sound04R_0_120 [4],
				Sound04R_0_120 [5],
				Sound04R_0_120 [6]
			});
			Sound04R_120.Add (new[] {
				Sound04R_1_120 [0],
				Sound04R_1_120 [1],
				Sound04R_1_120 [2],
				Sound04R_1_120 [3],
				Sound04R_1_120 [4],
				Sound04R_1_120 [5],
				Sound04R_1_120 [6]
			});
			Sound04R_120.Add (new[] {
				Sound04R_2_120 [0],
				Sound04R_2_120 [1],
				Sound04R_2_120 [2],
				Sound04R_2_120 [3],
				Sound04R_2_120 [4],
				Sound04R_2_120 [5],
				Sound04R_2_120 [6]
			});
			Sound04R_120.Add (new[] {
				Sound04R_m1_120 [0],
				Sound04R_m1_120 [1],
				Sound04R_m1_120 [2],
				Sound04R_m1_120 [3],
				Sound04R_m1_120 [4],
				Sound04R_m1_120 [5],
				Sound04R_m1_120 [6]
			});
			Sound04R_120.Add (new[] {
				Sound04R_m2_120 [0],
				Sound04R_m2_120 [1],
				Sound04R_m2_120 [2],
				Sound04R_m2_120 [3],
				Sound04R_m2_120 [4],
				Sound04R_m2_120 [5],
				Sound04R_m2_120 [6]
			});

			Sound04L_120 = new List<AudioClip[]> ();
			Sound04L_120.Add (new[] {
				Sound04L_0_120 [0],
				Sound04L_0_120 [1],
				Sound04L_0_120 [2],
				Sound04L_0_120 [3],
				Sound04L_0_120 [4],
				Sound04L_0_120 [5],
				Sound04L_0_120 [6]
			});
			Sound04L_120.Add (new[] {
				Sound04L_1_120 [0],
				Sound04L_1_120 [1],
				Sound04L_1_120 [2],
				Sound04L_1_120 [3],
				Sound04L_1_120 [4],
				Sound04L_1_120 [5],
				Sound04L_1_120 [6]
			});
			Sound04L_120.Add (new[] {
				Sound04L_2_120 [0],
				Sound04L_2_120 [1],
				Sound04L_2_120 [2],
				Sound04L_2_120 [3],
				Sound04L_2_120 [4],
				Sound04L_2_120 [5],
				Sound04L_2_120 [6]
			});
			Sound04L_120.Add (new[] {
				Sound04L_m1_120 [0],
				Sound04L_m1_120 [1],
				Sound04L_m1_120 [2],
				Sound04L_m1_120 [3],
				Sound04L_m1_120 [4],
				Sound04L_m1_120 [5],
				Sound04L_m1_120 [6]
			});
			Sound04L_120.Add (new[] {
				Sound04L_m2_120 [0],
				Sound04L_m2_120 [1],
				Sound04L_m2_120 [2],
				Sound04L_m2_120 [3],
				Sound04L_m2_120 [4],
				Sound04L_m2_120 [5],
				Sound04L_m2_120 [6]
			});

			Sound04R.Add (Sound04R_120);
			Sound04L.Add (Sound04L_120);

		}

		//BPM140読み込み	
		else if (bpm == 3) {
			Sound04R_140 = new List<AudioClip[]> ();
			Sound04R_140.Add (new[] {
				Sound04R_0_140 [0],
				Sound04R_0_140 [1],
				Sound04R_0_140 [2],
				Sound04R_0_140 [3],
				Sound04R_0_140 [4],
				Sound04R_0_140 [5],
				Sound04R_0_140 [6]
			});
			Sound04R_140.Add (new[] {
				Sound04R_1_140 [0],
				Sound04R_1_140 [1],
				Sound04R_1_140 [2],
				Sound04R_1_140 [3],
				Sound04R_1_140 [4],
				Sound04R_1_140 [5],
				Sound04R_1_140 [6]
			});
			Sound04R_140.Add (new[] {
				Sound04R_2_140 [0],
				Sound04R_2_140 [1],
				Sound04R_2_140 [2],
				Sound04R_2_140 [3],
				Sound04R_2_140 [4],
				Sound04R_2_140 [5],
				Sound04R_2_140 [6]
			});
			Sound04R_140.Add (new[] {
				Sound04R_m1_140 [0],
				Sound04R_m1_140 [1],
				Sound04R_m1_140 [2],
				Sound04R_m1_140 [3],
				Sound04R_m1_140 [4],
				Sound04R_m1_140 [5],
				Sound04R_m1_140 [6]
			});
			Sound04R_140.Add (new[] {
				Sound04R_m2_140 [0],
				Sound04R_m2_140 [1],
				Sound04R_m2_140 [2],
				Sound04R_m2_140 [3],
				Sound04R_m2_140 [4],
				Sound04R_m2_140 [5],
				Sound04R_m2_140 [6]
			});

			Sound04L_140 = new List<AudioClip[]> ();
			Sound04L_140.Add (new[] {
				Sound04L_0_140 [0],
				Sound04L_0_140 [1],
				Sound04L_0_140 [2],
				Sound04L_0_140 [3],
				Sound04L_0_140 [4],
				Sound04L_0_140 [5],
				Sound04L_0_140 [6]
			});
			Sound04L_140.Add (new[] {
				Sound04L_1_140 [0],
				Sound04L_1_140 [1],
				Sound04L_1_140 [2],
				Sound04L_1_140 [3],
				Sound04L_1_140 [4],
				Sound04L_1_140 [5],
				Sound04L_1_140 [6]
			});
			Sound04L_140.Add (new[] {
				Sound04L_2_140 [0],
				Sound04L_2_140 [1],
				Sound04L_2_140 [2],
				Sound04L_2_140 [3],
				Sound04L_2_140 [4],
				Sound04L_2_140 [5],
				Sound04L_2_140 [6]
			});
			Sound04L_140.Add (new[] {
				Sound04L_m1_140 [0],
				Sound04L_m1_140 [1],
				Sound04L_m1_140 [2],
				Sound04L_m1_140 [3],
				Sound04L_m1_140 [4],
				Sound04L_m1_140 [5],
				Sound04L_m1_140 [6]
			});
			Sound04L_140.Add (new[] {
				Sound04L_m2_140 [0],
				Sound04L_m2_140 [1],
				Sound04L_m2_140 [2],
				Sound04L_m2_140 [3],
				Sound04L_m2_140 [4],
				Sound04L_m2_140 [5],
				Sound04L_m2_140 [6]
			});

			Sound04R.Add (Sound04R_140);
			Sound04L.Add (Sound04L_140);

		}

		//BPM160読み込み	
		else if (bpm == 4) {
			Sound04R_160 = new List<AudioClip[]> ();
			Sound04R_160.Add (new[] {
				Sound04R_0_160 [0],
				Sound04R_0_160 [1],
				Sound04R_0_160 [2],
				Sound04R_0_160 [3],
				Sound04R_0_160 [4],
				Sound04R_0_160 [5],
				Sound04R_0_160 [6]
			});
			Sound04R_160.Add (new[] {
				Sound04R_1_160 [0],
				Sound04R_1_160 [1],
				Sound04R_1_160 [2],
				Sound04R_1_160 [3],
				Sound04R_1_160 [4],
				Sound04R_1_160 [5],
				Sound04R_1_160 [6]
			});
			Sound04R_160.Add (new[] {
				Sound04R_2_160 [0],
				Sound04R_2_160 [1],
				Sound04R_2_160 [2],
				Sound04R_2_160 [3],
				Sound04R_2_160 [4],
				Sound04R_2_160 [5],
				Sound04R_2_160 [6]
			});
			Sound04R_160.Add (new[] {
				Sound04R_m1_160 [0],
				Sound04R_m1_160 [1],
				Sound04R_m1_160 [2],
				Sound04R_m1_160 [3],
				Sound04R_m1_160 [4],
				Sound04R_m1_160 [5],
				Sound04R_m1_160 [6]
			});
			Sound04R_160.Add (new[] {
				Sound04R_m2_160 [0],
				Sound04R_m2_160 [1],
				Sound04R_m2_160 [2],
				Sound04R_m2_160 [3],
				Sound04R_m2_160 [4],
				Sound04R_m2_160 [5],
				Sound04R_m2_160 [6]
			});

			Sound04L_160 = new List<AudioClip[]> ();
			Sound04L_160.Add (new[] {
				Sound04L_0_160 [0],
				Sound04L_0_160 [1],
				Sound04L_0_160 [2],
				Sound04L_0_160 [3],
				Sound04L_0_160 [4],
				Sound04L_0_160 [5],
				Sound04L_0_160 [6]
			});
			Sound04L_160.Add (new[] {
				Sound04L_1_160 [0],
				Sound04L_1_160 [1],
				Sound04L_1_160 [2],
				Sound04L_1_160 [3],
				Sound04L_1_160 [4],
				Sound04L_1_160 [5],
				Sound04L_1_160 [6]
			});
			Sound04L_160.Add (new[] {
				Sound04L_2_160 [0],
				Sound04L_2_160 [1],
				Sound04L_2_160 [2],
				Sound04L_2_160 [3],
				Sound04L_2_160 [4],
				Sound04L_2_160 [5],
				Sound04L_2_160 [6]
			});
			Sound04L_160.Add (new[] {
				Sound04L_m1_160 [0],
				Sound04L_m1_160 [1],
				Sound04L_m1_160 [2],
				Sound04L_m1_160 [3],
				Sound04L_m1_160 [4],
				Sound04L_m1_160 [5],
				Sound04L_m1_160 [6]
			});
			Sound04L_160.Add (new[] {
				Sound04L_m2_160 [0],
				Sound04L_m2_160 [1],
				Sound04L_m2_160 [2],
				Sound04L_m2_160 [3],
				Sound04L_m2_160 [4],
				Sound04L_m2_160 [5],
				Sound04L_m2_160 [6]
			});

			Sound04R.Add (Sound04R_160);
			Sound04L.Add (Sound04L_160);


		}
		Debug.Log("AtherのBPM"+LoadBpm[bpm]+"読み込み完了");

		if (BpmCount < 5) {
			loadScript.soundLoad[3] = true;
		}
	}
}
