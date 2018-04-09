using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverFix : MonoBehaviour {
    GameObject lever;
	// Use this for initialization
	void Start () {
        lever = GameObject.Find("Lever (2)");

	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnTriggerStay2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.X))
            {
                lever.GetComponent<LeverScript>().leverActive = false;
            }
        }
    }
}
