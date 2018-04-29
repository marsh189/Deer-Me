using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour {

	// Use this for initialization
	void Start () {
      
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player")
		{
            if(this.gameObject.tag == "Wendigo")
            {
                col.gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
            }
			col.gameObject.GetComponent<UnityStandardAssets._2D.PlatformerCharacter2D> ().isDead = true;
        }
    }
}
