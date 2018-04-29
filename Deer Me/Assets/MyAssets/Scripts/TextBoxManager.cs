﻿using System.Collections;
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
    public Animator boxAnim;
    public GameObject Player;
    // Use this for initialization
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        canRead = false;
        boxAnim = textBoxObj.GetComponent<Animator>();
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
                    StartCoroutine("closeBook");
                }
                else if(curr <= fileLength)
                {
                    Player.GetComponent<UnityStandardAssets._2D.PlatformerCharacter2D>().isReading = true;

                    if(curr == 0)
                    {
                        Debug.Log("Animation");
                        textBoxObj.SetActive(true);
                        boxAnim.SetBool("Reading", true);
                        //GameObject.Find("BookText").SetActive(true);
                    }
                    finishedReading = false;
                    //Time.timeScale = 0f;
                    
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

    IEnumerator closeBook()
    {
        finishedReading = true;
        //Time.timeScale = 1.0f;
        boxAnim.SetBool("Reading", false);
        curr = 0;
        //GameObject.Find("BookText").SetActive(false);
        yield return new WaitForSeconds(1f);
        textBoxObj.SetActive(false);
        Player.GetComponent<UnityStandardAssets._2D.PlatformerCharacter2D>().isReading = false;
    }
}
