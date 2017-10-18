using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHelp : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnCollision2D(Collision2D col)
    {
        Debug.Log(col.gameObject.tag);
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log(col.tag);
    }
}
