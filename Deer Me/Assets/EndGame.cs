using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour {

    public float speed;
    public RawImage fadeImg;
    public bool startFade;
    private Color tempColor;
    public AudioListener audio;
    public string SceneName;

    public Text loadingText;
    bool loadScene;

	// Update is called once per frame
	void Update () 
    {
        if (startFade)
        {
            if (fadeImg.color.a < 1f)
            {
                tempColor.a += Time.deltaTime * speed;
                fadeImg.color = tempColor;
            }
            else
            {
                loadScene = true;

                // ...change the instruction text to read "Loading..."
                loadingText.text = "Loading...";

                // ...and start a coroutine that will load the desired scene.
                StartCoroutine(LoadNewScene(SceneName));
            }
        }
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            startFade = true;
            audio.enabled = false;
        }
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
