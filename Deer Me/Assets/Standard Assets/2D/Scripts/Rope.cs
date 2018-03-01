using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets._2D;

public class Rope : MonoBehaviour {

	public GameObject[] parts;
	public bool letGo;
	public bool wait;


	// Update is called once per frame
	void Update () 
	{

		if (letGo) 
		{
			foreach (GameObject obj in parts) 
			{
				obj.GetComponent<BoxCollider2D> ().enabled = false;
			}
			wait = true;
		}
		else if (!letGo && wait) 
		{
			foreach (GameObject obj in parts) 
			{
				obj.GetComponent<BoxCollider2D> ().enabled = true;
			}
			wait = false;
		}
	}
}
