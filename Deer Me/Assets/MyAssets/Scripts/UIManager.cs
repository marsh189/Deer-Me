using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
		if (Input.GetKeyDown(KeyCode.Escape) && !GameObject.FindGameObjectWithTag("Player").GetComponent<UnityStandardAssets._2D.PlatformerCharacter2D>().isDead)
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
		SceneManager.LoadScene (SceneManager.GetActiveScene().name);
	}

	public void Restart()
	{
		PlayerPrefs.SetString ("Level_Checkpoint", null);
		PlayerPrefs.SetFloat("Lighting", 1f);
		SceneManager.LoadScene (SceneManager.GetActiveScene().name);
	}

	void OnApplicationQuit()
	{
		PlayerPrefs.SetString ("Level_Checkpoint", null);
		PlayerPrefs.SetFloat("Lighting", 1f);
	}
}
