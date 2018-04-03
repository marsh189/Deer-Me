using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayFootSteps : MonoBehaviour {

    AudioSource source;

	// Use this for initialization
	void Start () {
        source = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () 
    {
        while (GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Walking"))
        {
            source.Play();
        }
            
	}
}
