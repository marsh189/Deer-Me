using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterDetector : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.GetComponent<Rigidbody2D>() != null)
        {
            transform.parent.GetComponent<Water>().Splash(transform.position.x, col.GetComponent<Rigidbody2D>().velocity.y * col.GetComponent<Rigidbody2D>().mass / 40f);
        }
    }
}
