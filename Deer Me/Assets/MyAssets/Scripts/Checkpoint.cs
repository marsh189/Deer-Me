using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour {
    public enum Status { Inactive, Active };
    public Status state;
    public CheckpointManager cm;
    public float time;
	// Use this for initialization
	void Start () {
        cm = GameObject.FindGameObjectWithTag("CheckpointManager").GetComponent<CheckpointManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            cm.UpdateCheckpoints(this.gameObject, time);
        }
    }
    
}
