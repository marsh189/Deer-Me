using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeMenuSound : MonoBehaviour {

	public AudioSource[] sources;
	public float[] volumes;
    public float speed;

	// Use this for initialization
	void Awake () 
	{
		for (int i = 0; i < sources.Length; i++) {
			sources [i].volume = 0;
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		for (int i = 0; i < sources.Length; i++) {
			if (sources [i].volume < volumes [i]) {
                sources [i].volume += Time.deltaTime * speed;
			}
		}
	}
}
