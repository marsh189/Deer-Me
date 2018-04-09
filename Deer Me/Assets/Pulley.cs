using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pulley : MonoBehaviour {


    //1= side that player is on
    //2= side player is moving

    public bool onPlatform;

    //platforms
    public GameObject plat_1;
    public GameObject plat_2;

    //ropes attached to platforms
    public GameObject rope_1;
    public GameObject rope_2;

    public Transform start_1;
    public Transform start_2;

    //where platforms end
    public Transform end_1;
    public Transform end_2;

    public float speed = 0.5f;


    //scale the role ends
    public Vector3 finalScale_1;
    public Vector3 finalScale_2;


    Vector3 temp_1 =  new Vector3(1,1,1);
    Vector3 temp_2 =  new Vector3(1,1,1);

	
	// Update is called once per frame
	void Update () 
    {
        if (onPlatform)
        {
            //check if platform has made it to final position
            if (plat_1.transform.position != end_1.position)
            {
                plat_1.transform.position = Vector3.MoveTowards(plat_1.transform.position, end_1.position, Time.deltaTime);
            }

            if (plat_2.transform.position != end_2.position)
            {
                plat_2.transform.position = Vector3.MoveTowards(plat_2.transform.position, end_2.position, Time.deltaTime);
            }
                
            if (temp_1.y != finalScale_1.y)
            {
                temp_1 = Vector3.MoveTowards(temp_1, finalScale_1, speed * Time.deltaTime);
                rope_1.transform.localScale = temp_1;      

            }

            if (temp_2.y != finalScale_2.y)
            {
                temp_2 = Vector3.MoveTowards(temp_2, finalScale_2, speed * Time.deltaTime);
                rope_2.transform.localScale = temp_2;      

            }
        }
        else
        {
            //check if platform has made it to final position
            if (plat_1.transform.position != start_1.position)
            {
                plat_1.transform.position = Vector3.MoveTowards(plat_1.transform.position, start_1.position, Time.deltaTime);
            }

            if (plat_2.transform.position != start_2.position)
            {
                plat_2.transform.position = Vector3.MoveTowards(plat_2.transform.position, start_2.position, Time.deltaTime);
            }

            if (temp_1.y != 1f)
            {
                temp_1 = Vector3.MoveTowards(temp_1, Vector3.one, speed * Time.deltaTime);
                rope_1.transform.localScale = temp_1;      

            }

            if (temp_2.y != 1f)
            {
                temp_2 = Vector3.MoveTowards(temp_2, Vector3.one, speed * Time.deltaTime);
                rope_2.transform.localScale = temp_2;      

            }
        }
	}
}
