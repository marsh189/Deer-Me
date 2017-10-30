//Michael Brutsch
//https://gamedevelopment.tutsplus.com/tutorials/creating-dynamic-2d-water-effects-in-unity--gamedev-14143
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour {
    float[] xpositions;
    float[] ypositions;
    float[] velocities;
    float[] accelerations;
    LineRenderer body;
    GameObject[] meshObjects;
    Mesh[] meshes;
    GameObject[] colliders;
    const float springcCons = 0.02f;
    const float damping = 0.04f;
    const float spread = 0.05f;
    const float z = -1f;
    float baseHeight;
    float Left;
    float Bottom;
    public GameObject splash;
    public Material mat;
    public GameObject waterMesh;
   

    // Use this for initialization
    void Start () {
        SpawnWater(-10, 20, 0, -3);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    void FixedUpdate()
    {
        for ( int i = 0; i < xpositions.Length; i++)
        {
            float force = springcCons * (ypositions[i] - baseHeight) + velocities[i] * damping;
            accelerations[i] = -force; //-force/mass for different masses for nodes
            ypositions[i] += velocities[i];
            velocities[i] += accelerations[i];
            body.SetPosition(i, new Vector3(xpositions[i], ypositions[i], z));

        }

        float[] leftDeltas = new float[xpositions.Length];
        float[] rightDeltas = new float[xpositions.Length];
        for(int j = 0; j < 8; j++)
        {
            for(int k = 0; k < xpositions.Length; k++)
            {
                if(k > 0)
                {
                    leftDeltas[k] = spread * (ypositions[k] - ypositions[k - 1]);
                    velocities[k - 1] += leftDeltas[k];
                }
                if(k < xpositions.Length - 1)
                {
                    rightDeltas[k] = spread * (ypositions[k] - ypositions[k + 1]);
                    velocities[k + 1] += rightDeltas[k];
                }
            }
        }

        for(int i = 0; i < xpositions.Length; i++)
        {
            if(i > 0)
            {
                ypositions[i - 1] += leftDeltas[i];
            }
            if(i < xpositions.Length - 1)
            {
                ypositions[i + 1] += rightDeltas[i];
            }
        }
        UpdateMeshes();
    }

    public void SpawnWater(float left, float width, float top, float bottom)
    {
        /*
        gameObject.AddComponent<BoxCollider2D>();
        gameObject.GetComponent<BoxCollider2D>().offset = new Vector2(left + width / 2, (top + bottom) / 2);
        gameObject.GetComponent<BoxCollider2D>().size = new Vector2(width, top - bottom);
        gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
        */
        int edgeCount = Mathf.RoundToInt(width) * 5;
        int nodeCount = edgeCount + 1;
        body.gameObject.AddComponent<LineRenderer>();
        body.material = mat;
        body.material.renderQueue = 1000;
        body.SetVertexCount(nodeCount);
        body.SetWidth(0.1f, 0.1f);
        xpositions = new float[nodeCount];
        ypositions = new float[nodeCount];
        velocities = new float[nodeCount];
        accelerations = new float[nodeCount];
        meshObjects = new GameObject[edgeCount];
        meshes = new Mesh[edgeCount];
        colliders = new GameObject[edgeCount];
        baseHeight = top;
        Bottom = bottom;
        Left = left;

        for (int i = 0; i < nodeCount; i++)
        {
            xpositions[i] = top;
            ypositions[i] = left + width * i / edgeCount;
            accelerations[i] = 0;
            velocities[i] = 0;
            body.SetPosition(i, new Vector3(xpositions[i], ypositions[i], z));
        }

        for (int i = 0; i < edgeCount; i++)
        {
            meshes[i] = new Mesh();
            Vector3[] vertices = new Vector3[4];
            vertices[0] = new Vector3(xpositions[i], ypositions[i], z);
            vertices[1] = new Vector3(xpositions[i + 1], ypositions[i + 1], z);
            vertices[2] = new Vector3(xpositions[i], Bottom, z);
            vertices[3] = new Vector3(xpositions[i + 1], Bottom, z);
            Vector2[] UVs = new Vector2[4];
            UVs[0] = new Vector2(0, 1);
            UVs[1] = new Vector2(1, 1);
            UVs[2] = new Vector2(0, 0);
            UVs[3] = new Vector2(1, 0);
            int[] triangles = new int[6] { 0, 1, 3, 3, 2, 0 };
            meshes[i].vertices = vertices;
            meshes[i].uv = UVs;
            meshes[i].triangles = triangles;
            meshObjects[i] = Instantiate(waterMesh, Vector3.zero, Quaternion.identity) as GameObject;
            meshObjects[i].GetComponent<MeshFilter>().mesh = meshes[i];
            meshObjects[i].transform.parent = transform;
            colliders[i] = new GameObject();
            colliders[i].name = "Trigger";
            colliders[i].AddComponent<BoxCollider2D>();
            colliders[i].transform.parent = transform;
            colliders[i].transform.position = new Vector3(left + width * (i + 0.5f) / edgeCount, top - 0.5f, 0);
            colliders[i].transform.localScale = new Vector3(width / edgeCount, 1, 1);
            colliders[i].GetComponent<BoxCollider2D>().isTrigger = true;
            colliders[i].AddComponent<WaterDetector>();
            
        }
    }

    void UpdateMeshes()
    {
        for (int i = 0; i < meshes.Length; i++)
        {
            Vector3[] vertices = new Vector3[4];
            vertices[0] = new Vector3(xpositions[i], ypositions[i], z);
            vertices[1] = new Vector3(xpositions[i + 1], ypositions[i + 1], z);
            vertices[2] = new Vector3(xpositions[i], Bottom, z);
            vertices[3] = new Vector3(xpositions[i + 1], Bottom, z);

            meshes[i].vertices = vertices;
        }
    }
    public void Splash(float xpos, float veloc)
    {
        if (xpos >= xpositions[0] && xpos <= xpositions[xpositions.Length - 1])
        {
            xpos -= xpositions[0];
            int index = Mathf.RoundToInt((xpositions.Length - 1) * (xpos / (xpositions[xpositions.Length - 1] - xpositions[0])));
            velocities[index] = veloc;
            float lifetime = 0.93f + Mathf.Abs(veloc) * 0.07f;
            splash.GetComponent<ParticleSystem>().startSpeed = 8 + 2 * Mathf.Pow(Mathf.Abs(veloc), 0.5f);
            splash.GetComponent<ParticleSystem>().startSpeed = 9 + 2 * Mathf.Pow(Mathf.Abs(veloc), 0.5f);
            splash.GetComponent<ParticleSystem>().startLifetime = lifetime;
            Vector3 position = new Vector3(xpositions[index], ypositions[index] - 0.35f, 5);
            Quaternion rotation = Quaternion.LookRotation(new Vector3(xpositions[Mathf.FloorToInt(xpositions.Length / 2)], baseHeight + 8, 5) - position);

            GameObject splish = Instantiate(splash, position, rotation) as GameObject;
            Destroy(splish, lifetime + 0.3f);
        }
    }

    void OnTriggerStay2D(Collider2D col)
    {
        //Floating code goes here
    }
}
