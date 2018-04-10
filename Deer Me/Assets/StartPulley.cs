using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPulley : MonoBehaviour {


    void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player" || col.gameObject.tag == "Box")
        {
            GetComponentInParent<Pulley>().onPlatform = true;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player" || col.gameObject.tag == "Box")
        {
            GetComponentInParent<Pulley>().onPlatform = false;
        }
    }
}
