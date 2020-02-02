using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour
{
    public Vector2 force;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();   
    }

    // Update is called once per frame
    void Update()
    {
        rb.AddForce(new Vector2(force.x * Time.deltaTime, force.y * Time.deltaTime));
    }
}
