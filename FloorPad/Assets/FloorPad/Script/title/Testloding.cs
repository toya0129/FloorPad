using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Testloding : MonoBehaviour {
	private AsyncOperation _async;
	[SerializeField] private Text text;
	void Start()
	{
		StartCoroutine (Load());
	}
	IEnumerator Load () {       
		yield return new WaitForSeconds(1);       
		//非同期でロード開始
		_async = SceneManager.LoadSceneAsync("GameScene04");        //シーン移動を許可するかどうか       

		while (true) {
			text.text = "NowLoading"; 
			yield return new WaitForSeconds (0.5f);
			text.text = "NowLoading."; 
			yield return new WaitForSeconds (0.5f);
			text.text = "NowLoading.."; 
			yield return new WaitForSeconds (0.5f);
			text.text = "NowLoading..."; 
			yield return new WaitForSeconds (0.5f);
			text.text = "NowLoading...."; 
			yield return new WaitForSeconds (0.5f);
		}
		}
}
