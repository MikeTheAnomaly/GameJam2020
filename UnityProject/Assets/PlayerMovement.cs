using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController2D CC;
    public float speed;
    public bool canMove = true;
    public GoopGun gun;
    public Controllable controller;
    public Transform arm;
    private bool inputX;
    public bool inputA;
    private Vector3 joy;

    Animator am;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        if(CC == null)
        {
            this.GetComponent<CharacterController2D>();
        }
        am = this.GetComponent<Animator>();
        rb = this.GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        am.SetFloat("speed", rb.velocity.x);
        joy = controller.Joystick1();
        inputX = controller.InputX();
        inputA = controller.InputA();
        //Debug.Log(Input.GetAxis("Mouse Y"));
        //arm.rotation =Quaternion.Euler(0, 0,Input.GetAxis("Mouse Y"));

        Vector3 mouse = Input.mousePosition;
        Vector3 screenPoint = Camera.main.WorldToScreenPoint(this.transform.position);
        Vector3 worldPoint = Camera.main.ScreenToWorldPoint(mouse);
        Vector2 offset = new Vector2(mouse.x - screenPoint.x, mouse.y - screenPoint.y);
        float angle = Mathf.Atan2(offset.y, Mathf.Abs(offset.x)) * Mathf.Rad2Deg;
        //Debug.Log(angle);
        if (!CC.m_FacingRight)
        {
            angle *= -1;
            
        }
        angle = Mathf.Clamp(angle, -90, 90);
        arm.transform.rotation = Quaternion.Euler(0, 0,angle);

        if( worldPoint.x < transform.position.x && CC.m_FacingRight)
        {
            CC.Flip();
        }

        if (worldPoint.x > transform.position.x && !CC.m_FacingRight)
        {
            CC.Flip();
        }

        if (inputX)
        {
            gun.Fire(CC.m_FacingRight);
        }

        if (controller.InputB())
        {
            gun.FireBounce(CC.m_FacingRight);
        }
    }

    private void FixedUpdate()
    {
        if (canMove)
        {
            CC.Move(joy.x *  speed * Time.fixedDeltaTime, inputX, controller.InputA());
        }
    }
}
