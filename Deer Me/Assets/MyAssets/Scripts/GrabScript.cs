using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabScript : MonoBehaviour {
    public Transform player;
    private Rigidbody2D rBody;
    private bool grabbed;
    public GameObject grabObj;
	// Use this for initialization
	void Start () {
        grabbed = false;
	}
	
	// Update is called once per frame
	void Update () {
      
    }
    void OnTriggerStay2D(Collider2D col)
    {
        if(col.gameObject.tag == "Grabbable")
        {
            if (Input.GetButtonDown("Grab") && grabbed)
            {
                Debug.Log("trying to drop");
                grabObj.transform.parent = null;
                rBody = grabObj.GetComponent<Rigidbody2D>();
                rBody.isKinematic = false;
                grabbed = false;
            }
            else if (Input.GetButtonDown("Grab") && !grabbed)
            {
                grabObj = col.gameObject;
                grabObj.transform.parent = this.transform;
                rBody = grabObj.GetComponent<Rigidbody2D>();
                rBody.isKinematic = true;
                grabbed = true;
            }

            if (grabbed)
            {
                if (Input.GetKey(KeyCode.D))
                {
                    //col.transform.Translate(Vector3.right * 7 * Time.deltaTime);
                }
            }
     

        }
    }
}
