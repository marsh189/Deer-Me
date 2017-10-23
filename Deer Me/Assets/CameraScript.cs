using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    private Vector2 velocity;

    public float smoothY;
    public float smoothX;

    public GameObject Player;
    
    void Start ()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }
    void FixedUpdate()
    {
        float posX = Mathf.SmoothDamp(transform.position.x, Player.transform.position.x, ref velocity.x, smoothX);
        float posY = Mathf.SmoothDamp(transform.position.y, Player.transform.position.y, ref velocity.x, smoothY);

        transform.position = new Vector3(posX, posY, transform.position.z);
    }
}