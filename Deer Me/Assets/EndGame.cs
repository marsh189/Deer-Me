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
                SceneManager.LoadScene("Credits");
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
}
