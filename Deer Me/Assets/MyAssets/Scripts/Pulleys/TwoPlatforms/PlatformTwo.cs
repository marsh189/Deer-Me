using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformTwo : MonoBehaviour {


    void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player" || col.gameObject.tag == "Box")
        {
            GetComponentInParent<PlatformPulley>().onPlatform_2 = true;
            if (!GetComponentInParent<AudioSource>().isPlaying)
            {
                GetComponentInParent<AudioSource>().Play();
            }
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player" || col.gameObject.tag == "Box")
        {
            GetComponentInParent<PlatformPulley>().onPlatform_2 = false;
            GetComponentInParent<AudioSource>().Stop();
        }
    }
}
