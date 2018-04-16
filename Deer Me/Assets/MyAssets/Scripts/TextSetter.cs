using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextSetter : MonoBehaviour {
    public TextAsset file;
    public TextBoxManager tbm;
	// Use this for initialization
	void Start () {
        tbm = GameObject.FindGameObjectWithTag("TextBoxManager").GetComponent<TextBoxManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            tbm.setText(file);
            Debug.Log("Player is colliding");
            tbm.canRead = true;
        }
    }
    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            tbm.canRead = false;
            Debug.Log("Can't read no more");
        }
    }
}
