using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetPlayerScript : MonoBehaviour {

	public LoadScript loadScript;
	public List<GameObject> readPlayer;
	public List<Transform> playerTransform;
	private List<Vector3> nowTransform;
	public List<GameObject> gamePlayer;

	private string nowScene;
	public static int actPlayer;

	private bool readTrigger = false;
	public bool[] jump = new bool[4];
	public static bool[] move = new bool[4];

	void Awake(){
		DontDestroyOnLoad (gameObject);
		for (int i = 0; i < 4; i++) {
			DontDestroyOnLoad (readPlayer [i]);
			DontDestroyOnLoad (gamePlayer [i]);
		}
	}

	// Use this for initialization
	void Start () {
		loadScript = GameObject.Find ("SceneController").GetComponent<LoadScript>();
		actPlayer = loadScript.getPlayerCount ();
		nowTransform = new List<Vector3> ();

		for (int i = 0; i < 4; i++) {
			jump [i] = true;
			move [i] = true;
		}

		for (int i = 0; i < actPlayer; i++) {
			nowTransform.Add (playerTransform[i].localPosition);
			readPlayer [i].SetActive (true);
			gamePlayer [i].SetActive (true);
			jump [i] = false;
			move [i] = false;
		}
	}
	
	// Update is called once per frame
	void Update () {
		nowScene = loadScript.nowSceneName;

		for (int i = 0; i < actPlayer; i++) {
			if (System.Math.Abs(System.Math.Abs(playerTransform[i].localPosition.y)-System.Math.Abs(nowTransform[i].y)) >= 0.04f) {
				jump [i] = true;
			} else if (System.Math.Abs(System.Math.Abs(playerTransform[i].localPosition.y)-System.Math.Abs(nowTransform[i].y)) <= 0.001f) {
				jump [i] = false;
			}

			if (playerTransform[i].localPosition.z < -0.3f) {
				move [i] = true;
			} else if (playerTransform[i].localPosition.z > 0.0f) {
				move [i] = false;
			}
		}

		if (nowScene == "PlayerReadScene") {
			if (Input.GetKeyDown (KeyCode.Space)) {
				for (int i = 0; i < actPlayer; i++) {
					jump [i] = true;
				}
			}
			if (TextChangeScript.now >= 4) {
				if ((jump [0] == true) && (jump [1] == true) && (jump [2] == true) && (jump [3] == true)) {
					if (readTrigger == true) {
						
					} else {
						readTrigger = true;
						TextChangeScript.changeTrigger = true;
						for (int i = 0; i < 4; i++) {
							jump [i] = false;
						}
						//loadScript.desSceneLoad ();

						//DiGRA用
						for (int i = 0; i < 4; i++) {
							readPlayer [i].SetActive (false);
							Destroy (readPlayer [i]);
						}
						for (int i = 0; i < actPlayer; i++) {
							gamePlayer [i].SetActive (true);
						}
						for (int i = 3; i >= actPlayer; i--) {
							Destroy (gamePlayer [i]);
						}
						loadScript.GameSceneLoad ();
						Destroy (this.gameObject);
					}
				}
			}
		} else if (nowScene == "PracScene") {
			if (CanvasSetScript.changeCount == 1) {
				if ((jump [0] == true) && (jump [1] == true) && (jump [2] == true) && (jump [3] == true)) {
					for (int i = 0; i < actPlayer; i++) {
						jump [i] = false;
					}
					CanvasSetScript.changeTriggerP = true;
				}
			} else if (CanvasSetScript.changeCount == 3) {
				if ((move [0] == true) && (move [1] == true) && (move [2] == true) && (move [3] == true)) {
					CanvasSetScript.changeTriggerP = true;
					for (int i = 0; i < 4; i++) {
						move [i] = false;
					}
					for (int i = 0; i < actPlayer; i++) {
						move [i] = true;
					}
				}
			} else if (CanvasSetScript.changeCount == 5) {
				if ((move [0] == false) && (move [1] == false) && (move [2] == false) && (move [3] == false)) {
					CanvasSetScript.changeTriggerP = true;
				}
			} else if (CanvasSetScript.changeCount > 5) {
				if ((jump [0] == true) && (jump [1] == true) && (jump [2] == true) && (jump [3] == true)) {
					CanvasSetScript.changeTriggerP = true;
					for (int i = 0; i < actPlayer; i++) {
						jump [i] = false;
					}
					for (int i = 0; i < 4; i++) {
						readPlayer [i].SetActive (false);
//						playerTransform.Remove (playerTransform [i]);
//						readPlayer.Remove (readPlayer [i]);

					}
					for (int i = 0; i < actPlayer; i++) {
						gamePlayer [i].SetActive (true);
					}
					loadScript.GameSceneLoad ();
					Destroy (this.gameObject);
				}
			}
		}

		for (int i = 0; i < actPlayer; i++) {
			nowTransform [i] = playerTransform [i].transform.localPosition;
		}
	}
}
