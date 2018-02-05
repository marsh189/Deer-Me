using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//https://vilbeyli.github.io/Unity3D-How-to-Make-a-Pause-Menu/
public class GameManager : MonoBehaviour {
    public UIManager UI;
    public GameObject pauseScreen;
	public GameObject deathScreen;
	public RawImage deathBG;

	// Use this for initialization
	void Start () {
        pauseScreen.SetActive(false);
		deathScreen.SetActive (false);
		Color temp = Color.black;
		temp.a = 0f;
		deathBG.color = temp;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void TogglePauseMenu()
    {
        if (UI.isPaused)
        {
            pauseScreen.SetActive(false);
            UI.isPaused = false;
            Time.timeScale = 1.0f;
        }
        else
        {
            pauseScreen.SetActive(true);
            UI.isPaused = true;
            Time.timeScale = 0f;
        }
    }
	public void CloseDeathScreen()
	{
		deathScreen.SetActive(false);
		Color temp = Color.black;
		temp.a = 0f;
		deathBG.color = temp;
		Time.timeScale = 1.0f;
	}
}
