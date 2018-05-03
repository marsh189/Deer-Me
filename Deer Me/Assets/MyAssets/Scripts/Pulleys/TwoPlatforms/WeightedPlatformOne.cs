using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeightedPlatformOne : MonoBehaviour {

    public float massNeeded;
    public float currMass;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player" || col.gameObject.tag == "Box")
        {
            currMass += col.gameObject.GetComponent<Rigidbody2D>().mass;

            if (currMass == massNeeded)
            {
                GetComponentInParent<PlatformPulley>().onPlatform_1 = true;
            }
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player" || col.gameObject.tag == "Box")
        {
            currMass -= col.gameObject.GetComponent<Rigidbody2D>().mass;
            if (currMass != massNeeded)
            {
                GetComponentInParent<PlatformPulley>().onPlatform_1 = false;
            }
        }
    }
}
