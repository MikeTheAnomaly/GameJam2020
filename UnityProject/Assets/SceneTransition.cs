using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    public int numNeeded = 1;
    private int numcurrent;

    public int sceneToLoad;
    public bool StoryScene = false;
    public bool setStoryStuff = false;
    public int setStory = 0;
    public int setStoryScene = 0;

    

    public void AddToNeeded()
    {
        numcurrent++;
    }


    private void Start()
    {
        if (setStoryStuff)
        {
            StaticStoryStuff.elemCurrent = setStory;
            StaticStoryStuff.nextScene = setStoryScene;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if(numcurrent == numNeeded)
        {
            if (!StoryScene)
            {
                SceneManager.LoadScene(sceneToLoad);
            }
            else
            {
                SceneManager.LoadScene(StaticStoryStuff.nextScene);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}
