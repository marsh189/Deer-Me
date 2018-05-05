using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour {
    public enum Status { Inactive, Active };
    public Status state;
    public CheckpointManager cm;
    public float time;
    public bool visited;
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
            if (!visited)
            {
                cm.UpdateCheckpoints(this.gameObject, time);
                visited = true;
            }
            else
            {
                cm.UpdateCheckpoints(this.gameObject, 0);
            }
            
        }
    }
    
}
