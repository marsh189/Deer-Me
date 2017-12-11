using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour {
    CheckpointManager cm;
	// Use this for initialization
	void Start () {
        cm = GameObject.FindGameObjectWithTag("CheckpointManager").GetComponent<CheckpointManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            cm.RespawnToActiveCheckpoint();
        }
    }
}
