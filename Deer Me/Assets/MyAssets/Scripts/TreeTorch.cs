using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeTorch : MonoBehaviour {

    public bool hasTorch;
    public GameObject torch;
	
	// Update is called once per frame
	void Update () 
    {
        if (torch.activeInHierarchy)
        {
            hasTorch = true;
        }
        else
        {
            hasTorch = false;
        }
	}
}
