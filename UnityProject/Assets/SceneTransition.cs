﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    public int numNeeded = 1;
    private int numcurrent;

    public int sceneToLoad;

    public void AddToNeeded()
    {
        numcurrent++;
    }

    // Update is called once per frame
    void Update()
    {
        if(numcurrent == numNeeded)
        {
            SceneManager.LoadScene(sceneToLoad);
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