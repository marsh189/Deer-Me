using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckpointManager : MonoBehaviour {
    public GameObject[] checkpoints;
    public GameObject Player;
	// Use this for initialization
	void Start () {
        checkpoints = GameObject.FindGameObjectsWithTag("Checkpoint");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void UpdateCheckpoints(GameObject current)
    {
        foreach(GameObject checkpoint in checkpoints)
        {
            if(checkpoint.GetComponent<Checkpoint>().state != Checkpoint.Status.Inactive)
            {
                checkpoint.GetComponent<Checkpoint>().state = Checkpoint.Status.Inactive;
            }
        }
        current.GetComponent<Checkpoint>().state = Checkpoint.Status.Active;
    }
    public void SetActiveSpawnPoint()
    {
        foreach (GameObject checkpoint in checkpoints)
        {
            if (checkpoint.GetComponent<Checkpoint>().state == Checkpoint.Status.Active)
            {
				PlayerPrefs.SetString ("Level_Checkpoint", checkpoint.name);
            }
        }
    }
}
