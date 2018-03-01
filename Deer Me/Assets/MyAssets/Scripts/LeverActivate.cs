using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverActivate : MonoBehaviour {
    public LeverManager lm;
	// Use this for initialization
	void Start () {
        lm = GameObject.FindGameObjectWithTag("LeverManager").GetComponent<LeverManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            lm.UpdateLevers(this.gameObject);
        }
    }
}
