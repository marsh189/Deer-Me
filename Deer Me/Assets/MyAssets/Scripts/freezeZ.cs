using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class freezeZ : MonoBehaviour {

	// Use this for initialization
	void Start () {
            this.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
