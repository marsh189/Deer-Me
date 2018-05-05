using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LowerPlatform : MonoBehaviour {


    //1= side that player is on
    //2= side player is moving

    public bool onPlatform;
    public GameObject plat;
    public GameObject rope;

    //where platform ends
    public Transform end;

    public float speed = 0.5f;

    //scale the rope ends
    public Vector3 finalScale;
    Vector3 temp =  new Vector3(1,1,1);
    public AudioClip pulleySound;

    // Update is called once per frame
    void Update () 
    {
        if (onPlatform)
        {
            GetComponent<AudioSource>().PlayOneShot(pulleySound);
            MoveToEnd();
        }
    }

    void MoveToEnd()
    {
        if (plat.transform.position != end.position)
        {
            plat.transform.position = Vector3.MoveTowards(plat.transform.position, end.position, Time.deltaTime);
        }
            
        if (temp.y != finalScale.y)
        {
            temp = Vector3.MoveTowards(temp, finalScale, speed * Time.deltaTime);
            rope.transform.localScale = temp;      

        }

    }
}