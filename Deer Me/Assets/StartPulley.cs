using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPulley : MonoBehaviour {


    void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            GetComponentInParent<Pulley>().onPlatform = true;
        }
    }
}
