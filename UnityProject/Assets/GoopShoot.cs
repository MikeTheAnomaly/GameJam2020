using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoopShoot : MonoBehaviour
{
    public float shootForce;
    Rigidbody2D rb;

    private bool connected = false;
    // Start is called before the first frame update
    void OnEnable()
    {
        rb = this.GetComponent<Rigidbody2D>();
        rb.AddForce(transform.right * shootForce);
    }
    
    

    // Update is called once per frame
    void Update()
    {
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag != "Player" && !connected)
        {
            connected = true;
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
            transform.localScale = new Vector3(10, 10);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "blob")
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

    
}
