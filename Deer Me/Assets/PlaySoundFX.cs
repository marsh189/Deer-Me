using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundFX : MonoBehaviour {

    public AudioClip clip;

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {

            if (Input.GetKeyDown(KeyCode.E))
            {

                GetComponent<AudioSource>().PlayOneShot(clip);
            }
        }
    }
}
