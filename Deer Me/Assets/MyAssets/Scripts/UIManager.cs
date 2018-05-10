using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {
	public GameManager gm;
	public CheckpointManager cm;
	public bool isPaused = false;

    public GameObject controls;
    public GameObject pauseCanvas;

    bool loadScene;
    public Text loadingText;
	// Use this for initialization
	void Start () {
		cm = GameObject.FindGameObjectWithTag("CheckpointManager").GetComponent<CheckpointManager>();
        loadingText.text = "";
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape) && !GameObject.FindGameObjectWithTag("Player").GetComponent<UnityStandardAssets._2D.PlatformerCharacter2D>().isDead)
		{
			gm.TogglePauseMenu();
		}

        // If the new scene has started loading...
        if (loadScene == true) {

            // ...then pulse the transparency of the loading text to let the player know that the computer is still working.
            loadingText.color = new Color(loadingText.color.r, loadingText.color.g, loadingText.color.b, Mathf.PingPong(Time.time, 1));

        }
	}

	public void Resume()
	{
		gm.TogglePauseMenu();
	}
	public void Quit()
	{
		PlayerPrefs.SetString ("Level_Checkpoint", null);
		PlayerPrefs.SetFloat("Lighting", 1f);
		SceneManager.LoadScene ("MainMenu");
	}
	public void RestartCheckPoint()
	{
		gm.CloseDeathScreen();
		GameObject.FindGameObjectWithTag ("Player").GetComponent<UnityStandardAssets._2D.PlatformerCharacter2D> ().isDead = false;
		cm.SetActiveSpawnPoint();
		PlayerPrefs.SetFloat("Lighting", GameObject.Find("WorldLight").GetComponent<Light>().intensity);
        loadScene = true;

        // ...change the instruction text to read "Loading..."
        loadingText.text = "Loading...";

        // ...and start a coroutine that will load the desired scene.
        StartCoroutine(LoadNewScene(SceneManager.GetActiveScene().name));
	}

	public void Restart()
	{
		PlayerPrefs.SetString ("Level_Checkpoint", null);
		PlayerPrefs.SetFloat("Lighting", 1f);
        loadScene = true;

        // ...change the instruction text to read "Loading..."
        loadingText.text = "Loading...";

        // ...and start a coroutine that will load the desired scene.
        StartCoroutine(LoadNewScene(SceneManager.GetActiveScene().name));
	}

	void OnApplicationQuit()
	{
		PlayerPrefs.SetString ("Level_Checkpoint", null);
		PlayerPrefs.SetFloat("Lighting", 1f);
	}

    public void ControlsClicked()
    {
        pauseCanvas.SetActive(false);
        controls.SetActive(true);
    }

    public void BackFromControls()
    {
        pauseCanvas.SetActive(true);
        controls.SetActive(false);
    }

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
