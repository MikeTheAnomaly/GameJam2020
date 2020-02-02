using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Locked : MonoBehaviour
{

    public bool CanTalk = false;
    private bool hasTalked = false;
    private bool readyToOpen = false;
    public Collider2D block;
    private Animator am;
    // Start is called before the first frame update
    void Start()
    {
        am = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void open()
    {
        block.enabled = false;
        readyToOpen = true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "player")
        {
            
            if (!readyToOpen &&  CanTalk && !hasTalked)
            {
                hasTalked = true;
                am.SetBool("Talking", true);
            }

            if (readyToOpen)
            {
                hasTalked = true;
                am.SetBool("Open", true);
            }
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        
    }
}
