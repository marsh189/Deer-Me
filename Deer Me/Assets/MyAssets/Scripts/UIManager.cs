using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour {
    public GameManager gm;

    public bool isPaused = false;

	// Use this for initialization
	void Start () {
		
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
}
