using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScript : MonoBehaviour {

	//private AsyncOperation gameScene = null;
	public GameObject controller;
	private int playerCount;

	public string nowSceneName;

	public bool[] soundLoad;

	public bool toSele = false;
	public bool toRead = false;
	private bool sele = false;
	private bool read = false;

	void Awake(){
		DontDestroyOnLoad (gameObject);
	}

	void Start(){
		playerCount = 0;
		getNowScene ();

		for (int i = 0; i < 4; i++) {
			soundLoad [i] = false;
		}
		soundLoad [0] = true;
		soundLoad [1] = true;

		//gameScene = Application.LoadLevelAsync ("GameScene04");
		//gameScene.allowSceneActivation = false;
	}

	void Update(){
//		Debug.Log ("プレイ人数 = " + playerCount);

		if (toSele == true) {
			toSele = false;
			Destroy (GameObject.Find ("player1"));
			Destroy (GameObject.Find ("player2"));
			Destroy (GameObject.Find ("player3"));
			Destroy (GameObject.Find ("player4"));
			playerCount = 0;
			SelectSceneLoad ();
		} else if (toRead == true) {
			toRead = false;
			Destroy (GameObject.Find ("player1"));
			Destroy (GameObject.Find ("player2"));
			Destroy (GameObject.Find ("player3"));
			Destroy (GameObject.Find ("player4"));
			ReadSceneLoad ();
		}
	}

	//プレイ人数選択シーンに移行
	public void SelectSceneLoad(){
		if (sele == false) {
			sele = true;
//			soundLoad [1] = true;
			soundLoad [2] = true;
			soundLoad [3] = true;
		}
		SceneManager.LoadScene ("PlayerSelectScene");
		Invoke ("getNowScene", 1.0f);
	}

	//プレイヤ読み込みシーンに移行
	public void ReadSceneLoad(){
		if (read == false) {
			read = true;
			//soundLoad [1] = true;
//			soundLoad [3] = true;
		}
		SceneManager.LoadScene ("PlayerReadScene");
		Invoke ("getNowScene", 1.0f);
		KinectManager.refreshTrigger = true;
	}

	//説明シーンに移行
	public void desSceneLoad(){
/*		if (playerCount > 4) {
			soundLoad [2] = true;
		}*/
		SceneManager.LoadScene ("DesScene");
		Invoke ("getNowScene", 1.0f);
	}

	//チュートリアルシーン読み込み
	public void PracSceneLoad(){
/*		if (playerCount > 5) {
			soundLoad [3] = true;
		}*/
		SceneManager.LoadScene ("PracScene");
		Invoke ("getNowScene", 1.0f);
	}
		
	//ゲームシーンに移行
	public void GameSceneLoad(){
		SceneManager.LoadScene ("GameScene04");
		Invoke ("getNowScene", 1.0f);
	}

	//メニューシーンに移行
	public void GameMenuLoad(){
		SceneManager.LoadScene ("GameMenu");
		Invoke ("getNowScene", 1.0f);
	}

	//タイトルシーンに移行
	public void TitleSceneLoad(){
		SceneManager.LoadScene("TitleScene");
		Destroy(this.gameObject);
	}

	//現在のシーン名取得
	public void getNowScene(){
		nowSceneName = SceneManager.GetActiveScene ().name;
	}

	//プレイヤー人数
	public int getPlayerCount(){
		return playerCount;
	}

	//プレイヤー人数設定
	public void setPlayerCount(int now){
		playerCount = now + 1;
	}
}