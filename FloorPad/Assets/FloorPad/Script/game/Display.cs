using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Display : MonoBehaviour {

	public AudioSource audioData;
	public LineRenderer lr;
	private int count;
	private float[] spectrum = new float[1024];
	float j = 0.0f;
	public float y;

	// Use this for initialization
	void Start () {
			audioData = this.gameObject.GetComponent<AudioSource> ();
			count = 0;
	}
	
	// Update is called once per frame
	void Update () {

		audioData.GetSpectrumData (spectrum, 0, FFTWindow.Hamming);//高速フーリエ変換

		lr.SetVertexCount (120);

		j = 0.0f;

		for (int i = 0; i < 120; i++) {
			if (count > 1023) {
				count = 0;
			}

			lr.SetPosition (i, new Vector3 (-3.0f + j, spectrum [count] * 10 + y, 1));

			if (i % 3 == 0) {
				count++;
			}
			j += 0.05f;

		}
	}
}

