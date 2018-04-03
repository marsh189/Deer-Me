using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushingScript : MonoBehaviour {
    public GameObject Player;
    public Animator anim;
	// Use this for initialization
	void Start () {
        Player = GameObject.FindGameObjectWithTag("Player");
        anim = Player.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.name == "GrabZone")
        {
            anim.SetBool("Pushing", true);
            Player.GetComponent< UnityStandardAssets._2D.PlatformerCharacter2D>().HideTorch(false);
        }
       
    }
    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.name == "GrabZone")
        {
            anim.SetBool("Pushing", false);
            Player.GetComponent< UnityStandardAssets._2D.PlatformerCharacter2D>().HideTorch(true);
        }
    }
}
