using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodSounds : MonoBehaviour {

    public List<AudioClip> sounds = new List<AudioClip>();
    public bool isFloating;
    AudioSource source;

    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.layer == 4)
        {
            isFloating = true;
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {

        if (col.gameObject.tag == "Player")
        {
            if (isFloating)
            {
                foreach (AudioClip s in sounds)
                {
                    if (s.name == "SFX_LAND_FLOATING_LOG")
                    {
                        source.PlayOneShot(s);
                    }
                }
            }
            else
            {
                foreach (AudioClip s in sounds)
                {
                    if (s.name == "SFX_LAND_WOOD")
                    {
                        source.PlayOneShot(s);
                    }
                }
            }
        }
    }

    void OnCollisionExit2D(Collision2D col)
    {

        if (col.gameObject.tag == "Player" && Input.GetKey(KeyCode.Space))
        {
            if (isFloating)
            {
                foreach (AudioClip s in sounds)
                {
                    if (s.name == "SFX_JUMP_FLOATING_LOG")
                    {
                        source.PlayOneShot(s);
                    }
                }
            }
            else
            {
                foreach (AudioClip s in sounds)
                {
                    if (s.name == "SFX_JUMP_WOOD")
                    {
                        source.PlayOneShot(s);
                    }
                }
            }
        }
    }
}
