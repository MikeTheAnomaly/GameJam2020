using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoopShoot : MonoBehaviour
{
    public float shootForce;
    Rigidbody2D rb;

    public float sizeIncrease = 10;
    private bool connected = false;
    private bool wait = false;
    // Start is called before the first frame update
    void OnEnable()
    {
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
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (( collision.gameObject.tag != "blobbounce" && collision.gameObject.tag != "Player") && !connected)
        {
            connected = true;
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
            //transform.localScale = new Vector3(10, 10);

            if (collision.gameObject.tag == "blob" && transform.localScale.x <= sizeIncrease)
            {
                wait = true;
                transform.localScale = new Vector3(.8f * sizeIncrease, .8f * sizeIncrease, 0);
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "blob" && !wait)
        {
            
            RemoveBlob();   
        }
    }

    public void RemoveBlob()
    {
        rb.constraints = RigidbodyConstraints2D.None;
        StartCoroutine("Fade");
    }

    IEnumerator Fade()
    {
        yield return new WaitForSeconds(1f);
        connected = false;
        transform.localScale = new Vector2(1, 1);
        this.gameObject.SetActive(false);
    }

    public void InstantRemove()
    {
        rb.constraints = RigidbodyConstraints2D.None;
        connected = false;
        transform.localScale = new Vector2(1, 1);
        this.gameObject.SetActive(false);
    }

    
}
