using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Setstuff : MonoBehaviour
{
    public Sprite[] elem;
    public  TextAsset[] textelems;
    public  int elemCurrent = 0;
    public  int nextScene = 0;
    // Start is called before the first frame update
    void Start()
    {
        StaticStoryStuff.elem = this.elem;
        StaticStoryStuff.textelems = this.textelems;
        StaticStoryStuff.elemCurrent = this.elemCurrent;
        StaticStoryStuff.nextScene = this.elemCurrent;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
