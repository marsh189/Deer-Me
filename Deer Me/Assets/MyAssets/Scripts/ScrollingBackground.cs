using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBackground : MonoBehaviour {
    public bool scrolling, parallax;
    public Transform cameraTransform;
    private Transform[] layers;
    private float viewZone;
    private int leftIndex;
    private int rightIndex;
    public float backgroundSize;
    public float parallaxSpeed;
    private float lastCameraX;
    // Use this for initialization
    void Start () {
        viewZone = backgroundSize / 2;
        lastCameraX = cameraTransform.position.x;
        layers = new Transform[transform.childCount];
        for(int i = 0; i < transform.childCount; i++)
        {
            layers[i] = transform.GetChild(i);
        }
        leftIndex = 0;
        rightIndex = layers.Length - 1;
	}
	
	// Update is called once per frame
	void Update () {
        if (parallax)
        {
            float deltaX = cameraTransform.position.x - lastCameraX;
            transform.position += Vector3.right * (deltaX * parallaxSpeed);
        }
        lastCameraX = cameraTransform.position.x;
        if (scrolling)
        {
            if (cameraTransform.position.x < (layers[leftIndex].transform.position.x + viewZone))
            {
                ScrollLeft();
            }
            if (cameraTransform.position.x > (layers[rightIndex].transform.position.x - viewZone))
            {
                ScrollRight();
            }
        }
    }
    private void ScrollLeft()
    {
        float oldy = layers[leftIndex].position.y;
        float oldz = layers[leftIndex].position.z;
        layers[rightIndex].position = Vector3.right * (layers[leftIndex].position.x - backgroundSize);
        layers[rightIndex].position = new Vector3(1 * layers[rightIndex].position.x, oldy, oldz);
        leftIndex = rightIndex;
        rightIndex--;
        if(rightIndex < 0)
        {
            rightIndex = layers.Length - 1;
        }
    }
    private void ScrollRight()
    {
        float oldy = layers[leftIndex].position.y;
        float oldz = layers[leftIndex].position.z;
        layers[leftIndex].position = Vector3.right * (layers[rightIndex].position.x + backgroundSize);
        layers[leftIndex].position = new Vector3(1 * layers[leftIndex].position.x, oldy, oldz); 
        rightIndex = leftIndex;
        leftIndex++;
        if (leftIndex == layers.Length)
        {
            leftIndex = 0;
        }
    }
}
