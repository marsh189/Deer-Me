﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour {

	public GameObject mainCanvas;
	public GameObject levelSelectCanvas;
    public bool loadScene = false;
    public Text loadingText;

	void Start()
	{
		mainCanvas.SetActive (true);
        levelSelectCanvas.SetActive(false);
        loadingText.text = "";
	}

    void Update()
    {
        // If the new scene has started loading...
        if (loadScene == true) {

            // ...then pulse the transparency of the loading text to let the player know that the computer is still working.
            loadingText.color = new Color(loadingText.color.r, loadingText.color.g, loadingText.color.b, Mathf.PingPong(Time.time, 1));

        }
    }

	public void LevelSelect()
	{
		if (mainCanvas.activeInHierarchy) 
		{
			mainCanvas.SetActive (false);
			levelSelectCanvas.SetActive (true);
		} 
		else 
		{
			mainCanvas.SetActive (true);
			levelSelectCanvas.SetActive (false);
		}
	}

	public void StartLevel(string levelName)
	{
        // ...set the loadScene boolean to true to prevent loading a new scene more than once...
        loadScene = true;

        // ...change the instruction text to read "Loading..."
        loadingText.text = "Loading...";

        // ...and start a coroutine that will load the desired scene.
        StartCoroutine(LoadNewScene(levelName));
	}
        
	public void Quit()
	{
		Application.Quit ();
	}

    // The coroutine runs on its own at the same time as Update() and takes an integer indicating which scene to load.
    IEnumerator LoadNewScene(string name) {

        // This line waits for 3 seconds before executing the next line in the coroutine.
        // This line is only necessary for this demo. The scenes are so simple that they load too fast to read the "Loading..." text.
        yield return new WaitForSeconds(3);

        // Start an asynchronous operation to load the scene that was passed to the LoadNewScene coroutine.
        AsyncOperation async = SceneManager.LoadSceneAsync(name);

        // While the asynchronous operation to load the new scene is not yet complete, continue waiting until it's done.
        while (!async.isDone) {
            yield return null;
        }

    }
}
