﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WendigoManager : MonoBehaviour {
    float timer = 0.0f;
    public GameObject Player;
    bool wendigoSpawn = false;
	// Use this for initialization
	void Start () {
        timer = 0.0f;
        Player = GameObject.FindGameObjectWithTag("Player");
    }
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        Debug.Log(timer);
        if(timer > 5 && !wendigoSpawn)
        {
           
            SpawnWendigo();
            wendigoSpawn = true;
        }
	}

    public void SpawnWendigo()
    {
        
        GameObject Wendigo = (GameObject)Instantiate(Resources.Load("Wendigo"), new Vector3(Player.transform.position.x - 10, Player.transform.position.y, Player.transform.position.z), Quaternion.Euler(0, 0, 0));
    }
    public void ResetTimer()
    {
        timer = 0;
    }
}