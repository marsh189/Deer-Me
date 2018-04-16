using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextBoxManager : MonoBehaviour {
    public TextAsset file;
    public string[] line;
    public Text TextBoxText;
    public GameObject textBoxObj;
    public int curr = 0;
    public int fileLength;
    public bool canRead;
    public bool finishedReading;
    // Use this for initialization
    void Start()
    {
        canRead = false;
        bool finishedReading = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(canRead == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if(curr > fileLength)
                {
                    finishedReading = true;
                    Time.timeScale = 1.0f;
                    textBoxObj.SetActive(false);
                }
                if(curr <= fileLength)
                {
                    finishedReading = false;
                    Time.timeScale = 0f;
                    textBoxObj.SetActive(true);
                    Debug.Log("TextActive");
                    Debug.Log("Line: " + curr);
                    TextBoxText.text = line[curr];
                    curr += 1;
                }
                
            }
        }
    }

    public void setText(TextAsset filename)
    {
        file = filename;
        curr = 0;
        if (file != null)
        {
            line = file.text.Split('\n');
        }
        fileLength = line.Length - 1;
    }   
}
