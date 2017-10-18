using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : PhysicsObject
{
    public float jumpTakeOffSpeed = 7;
    public float maxSpeed = 7;
    Vector2 move;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    protected override void ComputeVelocity()
    {
        
        Vector2 move = Vector2.zero;

        move.x = Input.GetAxis("Horizontal");
        if (Input.GetButtonDown("Jump") && grounded)
        {
            velocity.y = jumpTakeOffSpeed;
        }
        else if (Input.GetButtonUp("Jump"))
        {
            if (velocity.y > 0)
            {
                velocity.y = velocity.y * 0.5f;
            }
        }
        targetVelocity = move * maxSpeed;

    }

    void OnTriggerStay2D(Collider2D col)
    {
        if(col.gameObject.tag == "Grabbable")
        {
            if (Input.GetButtonDown("Grab"))
            {
                Debug.Log("HERE");
                col.transform.parent = this.transform;
                print("Grabbing");
            }
        }
    }
    
}