using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakingWood : MonoBehaviour {


	void Update()
	{
		if (GetComponent<Animator> ().GetCurrentAnimatorStateInfo (0).IsTag ("Playing")) 
		{
			Debug.Log ("HERE");
			//do nothing
		} 
		else 
		{
			Debug.Log ("DESTROY");
			Destroy (this.gameObject);
		}
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.tag == "BreaksWood") 
		{
			GetComponent<Animator> ().SetBool ("isBreaking", true);
		}

	}
}
