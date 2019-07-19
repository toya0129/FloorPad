using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Overlays : MonoBehaviour {

	public LoadScript loadScript;
	private int actPlayer;

	public Transform[] overlayR;
	public Transform[] overlayL;

	public Transform[,] sphere;
	public Transform[,] PlayerHand;

	private Vector3[,] overlay = new Vector3[4,2];
	private Vector3[,] newPosition = new Vector3[4, 2];
	private Vector3[,] newScale = new Vector3[4, 2];

	// Use this for initialization
	void Start () {
		loadScript = GameObject.Find ("SceneController").GetComponent<LoadScript>();
		actPlayer = loadScript.getPlayerCount ();

		sphere = new Transform[actPlayer, 2];
		PlayerHand = new Transform[actPlayer, 2];

		for (int i = 0; i < actPlayer; i++) {
			sphere [i, 0] = overlayR [i];
		}
		for (int i = 0; i < actPlayer; i++) {
			sphere [i, 1] = overlayL [i];
		}
			
		PlayerHand [0, 0] = GameObject.FindGameObjectWithTag ("Hand01R").transform;
		PlayerHand [0, 1] = GameObject.FindGameObjectWithTag ("Hand01L").transform;
		PlayerHand [1, 0] = GameObject.FindGameObjectWithTag ("Hand02R").transform;
		PlayerHand [1, 1] = GameObject.FindGameObjectWithTag ("Hand02L").transform;

		if (actPlayer > 2) {
			PlayerHand [2, 0] = GameObject.FindGameObjectWithTag ("Hand03R").transform;
			PlayerHand [2, 1] = GameObject.FindGameObjectWithTag ("Hand03L").transform;

			if (actPlayer > 3) {
				PlayerHand [3, 0] = GameObject.FindGameObjectWithTag ("Hand04R").transform;
				PlayerHand [3, 1] = GameObject.FindGameObjectWithTag ("Hand04L").transform;
			}
		}

		for (int i = 0; i < actPlayer; i++) {
			for (int j = 0; j < 2; j++) {
				overlay [i, j] = PlayerHand [i, j].position;
			}
		}

	}
	
	// Update is called once per frame
	void Update () {
		for (int i = 0; i < actPlayer; i++) {
			for (int j = 0; j < 2; j++) {
				newPosition [i, j].x = PlayerHand [i, j].position.x - overlay [i, j].x;
				newPosition [i, j].y = PlayerHand [i, j].position.y - overlay [i, j].y;
				sphere [i, j].localPosition += newPosition [i, j];
				newScale [i, j].x = PlayerHand [i, j].position.z - overlay [i, j].z;
				newScale [i, j].y = PlayerHand [i, j].position.z - overlay [i, j].z;
				newScale [i, j].z = PlayerHand [i, j].position.z - overlay [i, j].z;
				sphere [i, j].localScale -= (newScale [i, j] / 5.0f);
			}
		}

		for (int i = 0; i < actPlayer; i++) {
			for (int j = 0; j < 2; j++) {
				overlay [i, j] = PlayerHand [i, j].position;
			}
		}
	}
}
