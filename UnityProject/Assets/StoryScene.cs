using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryScene : MonoBehaviour
{
    public Sprite[] elem;
    public TextAsset[] textelems;
    public static int elemCurrent = 0;
    public static int nextScene = 0;

    private SpriteRenderer sr;
    // Start is called before the first frame update
    void Start()
    {
        sr = this.GetComponent<SpriteRenderer>();
        sr.sprite = StaticStoryStuff.elem[StaticStoryStuff.elemCurrent];

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public static int getNextScene()
    {
        return nextScene;
    }
}
