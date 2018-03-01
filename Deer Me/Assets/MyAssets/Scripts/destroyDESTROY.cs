using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyDESTROY : MonoBehaviour {
    public GameObject refer;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        

    }
    void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.X))
            {
                Destroy(refer);
            }
        }
    }
}
