using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class TextboxManager : MonoBehaviour
{
    public UnityEvent OnDoneReading;
    public GameObject textBox;

    public Text theText;

    public TextAsset textFile;
    public string[] textLines;

    public int currentLine;
    public int endAtLine;

    public CharacterController2D player;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<CharacterController2D>();
        if (textFile != null)
        {
            textLines = textFile.text.Split('\n');
            

        }

        if(endAtLine == 0)
        {
            endAtLine = textLines.Length - 1;
        }
    }
    void Update()
    {
        if (textLines.Length > currentLine)
        {
            theText.text = textLines[currentLine];
        }
        else
        {

            OnDoneReading.Invoke();
            this.gameObject.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            currentLine++;
        }
        
        if(currentLine > endAtLine)
        {
            textBox.SetActive(false);
        }
    }
}
