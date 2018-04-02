using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverScript : MonoBehaviour {
    public GameObject gameObjectReference;
    public bool leverActive = false;
    public GameObject NewPositionObj;
    public GameObject OldPositionObj;
    Vector3 beginPosOffset;
    Vector3 endPosOffset;
    LineRenderer waterLine;

	public GameObject activeSprite;
	public GameObject notActiveSprite;

	// Use this for initialization
	void Start () {
        /*if(gameObjectReference.gameObject.name == "WaterManager (10)")
        {
            waterLine = gameObjectReference.GetComponent<LineRenderer>();
            beginPosOffset = gameObjectReference.transform.position - waterLine.GetPosition(0);
            endPosOffset = gameObjectReference.transform.position - waterLine.GetPosition(1);
            
        } 
        */
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
           /* if (gameObjectReference.gameObject.name == "WaterManager (10)")
            {
                Vector3 newBeginPos = gameObjectReference.transform.position + beginPosOffset;
                Vector3 newEndPos = gameObjectReference.transform.position + endPosOffset;
                waterLine.SetPosition(0, newBeginPos);
                waterLine.SetPosition(1, newEndPos);
            }*/
            Debug.Log("moving up");
        }
        if(gameObjectReference.gameObject.tag == "buttonLog")
        {
            StartCoroutine("stopLOG");
        }
        
	}
    void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            
            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("pressing e");
                if (leverActive && OldPositionObj.transform.position != gameObjectReference.transform.position)
                {
                    Debug.Log("moving down");
                    leverActive = false;
					activeSprite.SetActive (false);
					notActiveSprite.SetActive (true);
                }
                else if(!leverActive && NewPositionObj.transform.position != gameObjectReference.transform.position)
                {
                    Debug.Log("moving up");
                    leverActive = true;
					notActiveSprite.SetActive (false);
					activeSprite.SetActive (true);
                }

               
            }
        }
    }
   /* void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "buttonLog")
        {
            this.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("PushedInButton");
            if (leverActive && OldPositionObj.transform.position.x != gameObjectReference.transform.position.x)
            {
                Debug.Log("moving down");
                leverActive = false;
            }
            else if (!leverActive && NewPositionObj.transform.position.x != gameObjectReference.transform.position.x)
            {
                
                leverActive = true;
            }
            Destroy(col.gameObject.GetComponent<BoxCollider2D>());
            col.gameObject.AddComponent<PolygonCollider2D>();
            Destroy(GameObject.Find("WaterWall (11)"));
            Destroy(GameObject.Find("WaterWall (12)"));
        } 
    }
    IEnumerator stopLOG()
    {
        yield return new WaitForSeconds(3f);
        gameObjectReference = null;
    }*/
}

