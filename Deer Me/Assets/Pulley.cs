using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pulley : MonoBehaviour {

    public bool onPlatform;
    public GameObject plat_1;
    public GameObject plat_2;

    public Transform end_1;
    public Transform end_2;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (onPlatform)
        {
            if (plat_1.transform.position != end_1.position && plat_2.transform.position != end_2.position)
            {
                plat_1.transform.position = Vector3.MoveTowards(plat_1.transform.position, end_1.position, Time.deltaTime);
                plat_2.transform.position = Vector3.MoveTowards(plat_2.transform.position, end_2.position, Time.deltaTime);
            }
        }
	}
}
