using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasScript : MonoBehaviour {

	public GameObject[] selectObject;
	Image[] image = new Image[3]; 
	public static int selectImage;
	public static bool setColor;

	// Use this for initialization
	void Start () {
		selectImage = 0;
		for (int i = 0; i < 3; i++) {
			image[i] = selectObject[i].GetComponent<Image> ();
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (setColor == true) {
			setSelectColor ();
		}

	}

	void setSelectColor(){
		for (int i = 0; i < 3; i++) {
			image [i].color = new Color (255.0f, 255.0f, 255.0f);
		}

		switch (selectImage) {
		case 1:
			image [0].color = new Color (0, 0, 255.0f);
			break;
		case 2:
			image [1].color = new Color (0, 255.0f, 0);
			break;
		case 3:
			image [2].color = new Color (255.0f, 255.0f, 0);
			break;
		}
		setColor = false;
	}
		
}
