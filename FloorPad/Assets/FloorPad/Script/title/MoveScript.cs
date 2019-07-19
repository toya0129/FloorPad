using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveScript : MonoBehaviour {

	public LoadScript loadScript;

	private Vector3 now;

	public bool Jump;
	public static bool UpRightHand;
	public static Transform playerPosition;

	private int nowPlayer;

	public static bool readLoad;

	void Awake(){
		DontDestroyOnLoad (gameObject);
	}

	// Use this for initialization
	void Start () {
		loadScript = GameObject.Find ("SceneController").GetComponent<LoadScript> ();
		playerPosition = GetComponent<Transform> ();

		now = playerPosition.localPosition;

		Jump = false;
		UpRightHand = false;

		readLoad = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (loadScript.nowSceneName == "TitleScene") {
			if (System.Math.Abs(System.Math.Abs(playerPosition.localPosition.y)-System.Math.Abs(now.y)) >= 0.04f) {
				Jump = true;
			} else if(System.Math.Abs(System.Math.Abs(playerPosition.localPosition.y)-System.Math.Abs(now.y))<=0.001f){
				Jump = false;
			}

			if ((Jump == true) && (UpRightHand == true)) {
				loadScript.SelectSceneLoad ();
				UpRightHand = false;
			}
		} else if (loadScript.nowSceneName == "PlayerSelectScene") {
			if (readLoad == true) {
				readLoad = false;
				loadScript.setPlayerCount (CanvasScript.selectImage);
				loadScript.ReadSceneLoad ();
			}
		}else if (loadScript.nowSceneName == "GameMenu") {

		}

		now = playerPosition.localPosition;
	}
}
