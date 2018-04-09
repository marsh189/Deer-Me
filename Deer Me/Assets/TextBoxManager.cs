using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextBoxManager : MonoBehaviour {
    public TextAsset file;
    public string[] line;
    public Text TextBoxText;
    public GameManager textBoxObj;
    public int curr = 0;
    public int fileLength;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
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
    public void readText()
    {
        textBoxObj.enabled = true;
        while(curr < fileLength)
        {
            TextBoxText.text = line[curr];
            if (Input.GetKeyDown(KeyCode.E))
            {
                curr += 1;
            }
        }
        textBoxObj.enabled = false;
    }
}
