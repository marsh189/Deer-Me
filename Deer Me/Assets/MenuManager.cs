using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {

	public GameObject mainCanvas;
	public GameObject levelSelectCanvas;
	public GameObject aboutCanvas;

	void Start()
	{
		mainCanvas.SetActive (true);
		levelSelectCanvas.SetActive (false);
		aboutCanvas.SetActive (false);
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
		SceneManager.LoadScene (levelName);
	}

	public void About()
	{
		if (mainCanvas.activeInHierarchy) 
		{
			mainCanvas.SetActive (false);
			aboutCanvas.SetActive (true);
		} 
		else 
		{
			mainCanvas.SetActive (true);
			aboutCanvas.SetActive (false);
		}
	}

	public void Quit()
	{
		Application.Quit ();
	}
}
