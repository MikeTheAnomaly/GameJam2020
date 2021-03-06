﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoopShoot : MonoBehaviour
{
    public float shootForce;
    Rigidbody2D rb;

    public float sizeIncrease = 10;
    private bool connected = false;
    private bool wait = true;

    public bool gettingremoved = false;
    public GoopShoot connectedTo;
    public GoopShoot alsoConnectedTo;

    public Collider2D colliderOfObj;

    // Start is called before the first frame update
    void OnEnable()
    {
        
        colliderOfObj.enabled = true;
        alsoConnectedTo = null;
        connectedTo = null;
        gettingremoved = false;
        wait = true;
        rb = this.GetComponent<Rigidbody2D>();
        rb.AddForce(transform.right * shootForce);
    }
    
    

    // Update is called once per frame
    void Update()
    {

        if(connected && transform.localScale.x <= sizeIncrease)
        {
            transform.localScale = transform.localScale + new Vector3(10 * Time.deltaTime,10 * Time.deltaTime,0);
            wait = false;
        }

        if(connectedTo != null)
        {
            if (connectedTo.gettingremoved)
            {
                RemoveBlob();
            }
        }
        else if(alsoConnectedTo != null)
        {
            //RemoveBlob();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (( collision.gameObject.tag != "blobbounce" && collision.gameObject.tag != "Player") && !connected)
        {
            SoundManagerScript.PlaySound("splat");

            connected = true;
            rb.isKinematic = true;
            rb.velocity = Vector3.zero;
            rb.angularVelocity = 0;
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
            //transform.localScale = new Vector3(10, 10);

            if (collision.gameObject.tag == "blob" && transform.localScale.x <= sizeIncrease)
            {
                wait = true;
                
                transform.localScale = new Vector3(.8f * sizeIncrease, .8f * sizeIncrease, 0);
                if (connectedTo == null)
                {
                    connectedTo = collision.gameObject.GetComponent<GoopShoot>();
                    if(connectedTo.alsoConnectedTo == null)
                    {
                        connectedTo.alsoConnectedTo = this;
                    }
                }
               
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "blob" && !wait)
        {

            if (collision.gameObject.GetComponent<GoopShoot>().gettingremoved)
            {
                this.gettingremoved = true;
                RemoveBlob();
            }
        }
    }

    public void RemoveBlob()
    {
        colliderOfObj.enabled = false;
        gettingremoved = true;
        rb.isKinematic = false;
        rb.constraints = RigidbodyConstraints2D.None;
        StartCoroutine("Fade");
    }

    IEnumerator Fade()
    {
        yield return new WaitForSeconds(1f);
        InstantRemove();
    }

    public void InstantRemove()
    {
        if (alsoConnectedTo)
        {
            alsoConnectedTo.RemoveBlob();
        }
        alsoConnectedTo = null;
        connectedTo = null;
        gettingremoved = true;
        rb.isKinematic = false;
        rb.constraints = RigidbodyConstraints2D.None;
        connected = false;
        transform.localScale = new Vector2(1, 1);
        this.gameObject.SetActive(false);
    }

    
}
