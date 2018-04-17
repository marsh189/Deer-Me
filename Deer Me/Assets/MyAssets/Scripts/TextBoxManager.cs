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
    public Animator boxAnim;
    // Use this for initialization
    void Start()
    {
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
                    if(curr == 0)
                    {
                        Debug.Log("Animation");
                        textBoxObj.SetActive(true);
                        boxAnim.SetBool("Reading", true);
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
        yield return new WaitForSeconds(1f);
        textBoxObj.SetActive(false);
    }
}
