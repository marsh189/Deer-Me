using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WendigoUnPause : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            GameObject.FindGameObjectWithTag("WendigoManager").GetComponent<WendigoManager>().Pause = false;
        }
    }
}
