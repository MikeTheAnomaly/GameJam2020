using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Movement : MonoBehaviour
{
    public LayerMask enemyMask;
    public float speed = 1;
    Rigidbody2D myBody;
    Transform myTrans;
    float myWidth;
    Animator am;

    public bool sidways;

    bool chomp = false;


    //public Transform GroundCheck;
    public bool isGrounded;
    public bool isBlocked;
    // Start is called before the first frame update
    void Start()
    {
        am = this.GetComponent<Animator>();
        myTrans = this.transform;
        myBody = this.GetComponent<Rigidbody2D>();
        myWidth = this.GetComponentInParent<SpriteRenderer>().bounds.extents.x;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        am.SetBool("chompy", chomp);
        chomp = false;
        //check to see if there's ground in front of it before moving forward
        if (!sidways)
        {
            Vector2 lineCastPos = myTrans.position - myTrans.right * myWidth;
            Debug.DrawLine(lineCastPos, lineCastPos + Vector2.down + new Vector2(0, -5));
            isGrounded = Physics2D.Linecast(lineCastPos, lineCastPos + Vector2.down + new Vector2(0, -5), enemyMask);


            isBlocked = Physics2D.Linecast(lineCastPos, lineCastPos - extentionMethods.toVector2(myTrans.right), enemyMask);
            Debug.DrawLine(lineCastPos, lineCastPos - extentionMethods.toVector2(myTrans.right) * .02f);
            isBlocked = Physics2D.Linecast(lineCastPos, lineCastPos - extentionMethods.toVector2(myTrans.right) * .02f, enemyMask);
        }
        else
        {
            isGrounded = true;
        }
        if (!isGrounded && myBody.velocity.y == 0)
        {
            Vector3 currRot = myTrans.eulerAngles;
            currRot.y += 180;
            myTrans.eulerAngles = currRot;
        }
        if (!sidways)
        {
            //Always move forward
            Vector2 myVel = myBody.velocity;
            myVel.x = -myTrans.right.x * speed;
            myBody.velocity = myVel;
        }
        else
        {
            Vector2 myVel = myBody.velocity;
            myVel.y = -myTrans.right.x * speed;
            myBody.velocity = myVel;
        }
        am.SetFloat("Speed", myBody.velocity.x);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "blob" || collision.gameObject.tag == "blobbounce")
        {
            SoundManagerScript.PlaySound("Chomp");
            chomp = true;
            collision.gameObject.GetComponent<GoopShoot>().RemoveBlob();
        }
        else
        {
            if (!sidways)
            {
                Vector3 currRot = myTrans.eulerAngles;
                currRot.y += 180;
                myTrans.eulerAngles = currRot;
            }
        }
    }
}
