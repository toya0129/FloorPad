using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveController : MonoBehaviour {

	public List<GameObject> player;
	private List<Vector3> nowTransform;

	private LoadScript loadScript;
	public DrumMusicController drumMusicController; 
	private int actPlayer;

	// Use this for initialization
	void Start () {
		loadScript = GameObject.Find ("SceneController").GetComponent<LoadScript>();
		actPlayer = loadScript.getPlayerCount ();

		player = new List<GameObject>();
		nowTransform = new List<Vector3> ();

		player.Add (GameObject.Find ("player1"));
		nowTransform.Add (player [0].transform.localPosition);

		player.Add (GameObject.Find ("player2"));
		nowTransform.Add (player [1].transform.localPosition);

		if (actPlayer > 2) {
			player.Add (GameObject.Find ("player3"));
			nowTransform.Add (player [2].transform.localPosition);
			if (actPlayer > 3) {
				player.Add (GameObject.Find ("player4"));
				nowTransform.Add (player [3].transform.localPosition);
			}
		}

	}
	
	// Update is called once per frame
	void Update () {
		for (int i = 0; i < actPlayer; i++) {
			if (System.Math.Abs(System.Math.Abs(player[i].transform.localPosition.y)-System.Math.Abs(nowTransform[i].y)) >= 0.04f) {
				drumMusicController.PlayerJump [i] = true;
			} else if(System.Math.Abs(System.Math.Abs(player[i].transform.localPosition.y)-System.Math.Abs(nowTransform[i].y)) <= 0.001f){
				drumMusicController.PlayerJump [i] = false;
			}
		}

		for (int i = 0; i < actPlayer; i++) {
			if ((player [i].transform.localPosition.z > -0.3f) && (player [i].transform.localPosition.z < 0.3f)) {
				drumMusicController.key [i] = 0;
			} else if ((player [i].transform.localPosition.z > 0.3f) && (player [i].transform.localPosition.z < 0.9f)) {
				drumMusicController.key [i] = 1;
			} else if ((player [i].transform.localPosition.z > 0.9f) && (player [i].transform.localPosition.z < 1.5f)) {
				drumMusicController.key [i] = 2;
			} else if ((player [i].transform.localPosition.z > -0.9f) && (player [i].transform.localPosition.z < -0.3f)) {
				drumMusicController.key [i] = 3;
			} else if ((player [i].transform.localPosition.z > -1.5f) && (player [i].transform.localPosition.z < -0.9f)) {
				drumMusicController.key [i] = 4;
			}
		}

		for (int i = 0; i < actPlayer; i++) {
			nowTransform [i] = player [i].transform.localPosition;
		}
	}

}
