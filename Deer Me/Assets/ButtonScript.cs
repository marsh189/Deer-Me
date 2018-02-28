using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour {
    public GameObject gameObjectReference;
    public bool buttonActive = false;
    public GameObject NewPositionObj;
    public GameObject OldPositionObj;
    // Use this for initialization
    void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        if (!buttonActive && OldPositionObj.transform.position != gameObjectReference.transform.position)
        {
            gameObjectReference.transform.position = Vector3.MoveTowards(gameObjectReference.transform.position, OldPositionObj.transform.position, Time.deltaTime * 2);
        }

        if (buttonActive && NewPositionObj.transform.position != gameObjectReference.transform.position)
        {
            gameObjectReference.transform.position = Vector3.MoveTowards(gameObjectReference.transform.position, NewPositionObj.transform.position, Time.deltaTime * 2);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Box")
        {
            buttonActive = true;
        }
    }
}
