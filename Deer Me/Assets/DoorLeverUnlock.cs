using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorLeverUnlock : MonoBehaviour {
    public int leverNum;
    public bool leverActive;
    public GameObject door;
    public GameObject activeSprite;
    public GameObject notActiveSprite;
    // Use this for initialization
    void Start () {
        door = GameObject.FindGameObjectWithTag("FinalDoor");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {

            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("pressing e");
                if (leverActive)
                {

                    Debug.Log("moving down");
                    leverActive = false;
                    activeSprite.SetActive(false);
                    notActiveSprite.SetActive(true);
                    switch (leverNum)
                    {
                        case 1:
                            door.GetComponent<DoorUnlock>().lever1 = true;
                            break;
                        case 2:
                            door.GetComponent<DoorUnlock>().lever2 = false;
                            break;
                        case 3:
                            door.GetComponent<DoorUnlock>().lever3 = true;
                            break;
                        case 4:
                            door.GetComponent<DoorUnlock>().lever4 = true;
                            break;
                    }
                }
                else if (!leverActive)
                {
                    Debug.Log("moving up");
                    leverActive = true;
                    notActiveSprite.SetActive(false);
                    activeSprite.SetActive(true);
                    switch (leverNum)
                    {
                        case 1:
                            door.GetComponent<DoorUnlock>().lever1 = false;
                            break;
                        case 2:
                            door.GetComponent<DoorUnlock>().lever2 = true;
                            break;
                        case 3:
                            door.GetComponent<DoorUnlock>().lever3 = false;
                            break;
                        case 4:
                            door.GetComponent<DoorUnlock>().lever4 = false;
                            break;
                    }
                }


            }
        }
        }
   }
