using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class CreditSceneManager : MonoBehaviour {

	// Update is called once per frame
	void Update () 
    {

        if (GetComponent<VideoPlayer>().frame >= (long) GetComponent<VideoPlayer>().frameCount || Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("MainMenu");
        }
	}
}
