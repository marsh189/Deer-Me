using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour {
    public GameManager gm;
    public CheckpointManager cm;
    public bool isPaused = false;

	// Use this for initialization
	void Start () {
        cm = GameObject.FindGameObjectWithTag("CheckpointManager").GetComponent<CheckpointManager>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            gm.TogglePauseMenu();
        }
	}

    public void Resume()
    {
        gm.TogglePauseMenu();
    }
    public void Quit()
    {
        //Application.quit?? Or maybe go to a menu
    }
    public void Restart()
    {
        cm.RespawnToActiveCheckpoint();
    }
}
