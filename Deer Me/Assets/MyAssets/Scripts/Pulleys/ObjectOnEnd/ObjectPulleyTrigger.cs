using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPulleyTrigger : MonoBehaviour {

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player" || col.gameObject.tag == "Box")
        {
            GetComponentInParent<ObjectPulley>().onPlatform_1 = true;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player" || col.gameObject.tag == "Box")
        {
            GetComponentInParent<ObjectPulley>().onPlatform_1 = false;
        }
    }
}
