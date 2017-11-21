using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverScript : MonoBehaviour {
    public GameObject gameObjectReference;
    public bool leverActive = false;
    public GameObject NewPositionObj;
    public GameObject OldPositionObj;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (!leverActive && OldPositionObj.transform.position != gameObjectReference.transform.position)
        {
            gameObjectReference.transform.position = Vector3.MoveTowards(gameObjectReference.transform.position, OldPositionObj.transform.position, Time.deltaTime * 2);
        }
        
        if (leverActive && NewPositionObj.transform.position != gameObjectReference.transform.position)
        {
            gameObjectReference.transform.position = Vector3.MoveTowards(gameObjectReference.transform.position, NewPositionObj.transform.position, Time.deltaTime * 2);          
        }
	}
    void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            Debug.Log("Colliding");
            if (Input.GetKeyDown(KeyCode.X))
            {
                Debug.Log("pressing x");
                if (leverActive && OldPositionObj.transform.position != gameObjectReference.transform.position)
                {
                    Debug.Log("moving down");
                    leverActive = false;
                }
                else if(!leverActive && NewPositionObj.transform.position != gameObjectReference.transform.position)
                {
                    Debug.Log("moving up");
                    leverActive = true;
                }
               
            }
        }
    }
}
