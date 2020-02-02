using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsIngnore : MonoBehaviour
{
    public int layer = 9;
    // Start is called before the first frame update
    void Start()
    {
        Physics2D.IgnoreLayerCollision(10, layer);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
