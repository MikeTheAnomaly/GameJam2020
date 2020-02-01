﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController2D CC;
    public float speed;
    public bool canMove = true;

    public Controllable controller;
    public Transform arm;
    private bool inputX;
    public bool inputA;
    private Vector3 joy;
    // Start is called before the first frame update
    void Start()
    {
        if(CC == null)
        {
            this.GetComponent<CharacterController2D>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        joy = controller.Joystick1();
        inputX = controller.InputX();
        inputA = controller.InputA();
        Debug.Log(Input.GetAxis("Mouse Y"));
        //arm.rotation =Quaternion.Euler(0, 0,Input.GetAxis("Mouse Y"));

        Vector3 mouse = Input.mousePosition;
        Vector3 screenPoint = Camera.main.WorldToScreenPoint(transform.localPosition);
        Vector2 offset = new Vector2(mouse.x - screenPoint.x, mouse.y - screenPoint.y);
        float angle = Mathf.Atan2(offset.y, .25f) * Mathf.Rad2Deg; ;
        if (!CC.m_FacingRight)
        {
            angle *= -1;
        }
        arm.transform.rotation = Quaternion.Euler(0, 0,Mathf.Clamp(angle,-80,90));
    }

    private void FixedUpdate()
    {
        if (canMove)
        {
            CC.Move(joy.x *  speed * Time.fixedDeltaTime, inputX, controller.InputA());
        }
    }
}