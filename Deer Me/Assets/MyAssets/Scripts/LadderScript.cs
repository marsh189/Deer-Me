using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets._2D;

public class LadderScript : MonoBehaviour {
 
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            
			col.gameObject.GetComponent<UnityStandardAssets._2D.PlatformerCharacter2D>().climbing = true;
            col.gameObject.GetComponent<UnityStandardAssets._2D.PlatformerCharacter2D>().HideTorch(false);
			col.gameObject.GetComponent<Animator> ().SetBool ("isClimbing", true);
        }
    }
    
    void OnTriggerExit2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player")
        {
			col.gameObject.GetComponent<UnityStandardAssets._2D.PlatformerCharacter2D>().climbing = false;
            col.gameObject.GetComponent<UnityStandardAssets._2D.PlatformerCharacter2D>().HideTorch(true);
			col.gameObject.GetComponent<Animator> ().SetBool ("isClimbing", false);
        }
    }
}
