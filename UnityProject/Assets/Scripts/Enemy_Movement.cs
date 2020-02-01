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

    // Start is called before the first frame update
    void Start()
    {
        myTrans = this.transform;
        myBody = this.GetComponent<Rigidbody2D>();
        myWidth = this.GetComponentInParent<SpriteRenderer>().bounds.extents.x;
    }

    // Update is called once per frame
    void Update()
    {
        //check to see if there's ground in front of it before moving forward
        Vector2 lineCastPos = myTrans.position - myTrans.right * myWidth;
        Debug.DrawLine(lineCastPos, lineCastPos + Vector2.down);
        bool isGrounded = Physics2D.Linecast(lineCastPos, lineCastPos + Vector2.down, enemyMask);
        Debug.DrawLine(lineCastPos, lineCastPos - myTrans.right.toVector2() *.02f);
        bool isBlocked = Physics2D.Linecast(lineCastPos, lineCastPos - myTrans.right.toVector2() *.02f, enemyMask);
        
        if(!isGrounded || isBlocked)
        {
            Vector3 currRot = myTrans.eulerAngles;
            currRot.y += 180;
            myTrans.eulerAngles = currRot;
        }

        //Always move forward
        Vector2 myVel = myBody.velocity;
        myVel.x = -myTrans.right.x * speed;
        myBody.velocity = myVel;
    }
}
