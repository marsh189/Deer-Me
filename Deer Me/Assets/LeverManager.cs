using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverManager : MonoBehaviour {
    public GameObject[] Levers;
	// Use this for initialization
	void Start () {
        Levers = GameObject.FindGameObjectsWithTag("Lever");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void UpdateLevers(GameObject current)
    {
        foreach(GameObject lever in Levers)
        {
            if(lever.GetComponent<LeverScript>().enabled != false)
            {
                lever.GetComponent<LeverScript>().enabled = false;
            }
          
        }
        current.GetComponent<LeverScript>().enabled = true;
    }
}
