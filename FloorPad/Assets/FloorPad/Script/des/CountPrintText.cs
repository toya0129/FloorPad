using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class CountPrintText : MonoBehaviour
{
	public static LoadScript loadScript;
	public PanelSlider[] panel;

	void Start()
	{
		StartCoroutine (DelayMethod ());
		loadScript = GameObject.Find ("SceneController").GetComponent<LoadScript>();
	}

	IEnumerator DelayMethod()
	{
		//20s_20s_10S__text切り替え時間4s
		yield return new WaitForSeconds (1f);
		PanelIn(0);
		//yield return new WaitForSeconds(20f);
		yield return new WaitForSeconds(5f);
		PanelOut(0);
		yield return new WaitForSeconds (1f);
		PanelIn(1);
		//yield return new WaitForSeconds(25f);
		yield return new WaitForSeconds(10f);
		PanelOut(1);
		yield return new WaitForSeconds (1f);
		PanelIn(2);
		//yield return new WaitForSeconds(15f);
		yield return new WaitForSeconds(10f);
		PanelOut(2);
		loadScript.PracSceneLoad ();
	}
		
	public void PanelIn(int num)
	{
		panel[num].SlideIn();
	}
	public void PanelOut(int num)
	{
		panel[num].SlideOut();
	}

}
