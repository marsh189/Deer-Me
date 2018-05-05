using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorUnlock : MonoBehaviour {

    public bool lever1;
    public bool lever2;
    public bool lever3;
    public bool lever4;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(lever1 && lever2 && lever3 && lever4)
        {
            Destroy(this.gameObject);
        }
	}
    
    }
