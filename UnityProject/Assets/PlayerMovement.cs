using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController2D CC;
    public float speed;
    public bool canMove = true;

    public Controllable controller;

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
    }

    private void FixedUpdate()
    {
        if (canMove)
        {
            CC.Move(joy.x *  speed * Time.fixedDeltaTime, inputX, controller.InputA());
        }
    }
}
