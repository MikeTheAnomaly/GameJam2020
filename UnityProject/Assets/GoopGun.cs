using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoopGun : MonoBehaviour
{
    public GameObject GoopProjectile;
    public Transform FirePostion;

    public int numberToSpawn;
    Queue<GameObject> balls;
    // Start is called before the first frame update
    void Start()
    {
        balls = new Queue<GameObject>();
        for (int i = 0; i < numberToSpawn; i++)
        {
            GameObject ball = Instantiate(GoopProjectile);
            ball.SetActive(false);
            balls.Enqueue(ball);
        }
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Fire(bool fliped)
    {
        Quaternion roation;
        if (!fliped)
        {
            roation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z + 180);
        }
        else
        {
            roation = this.transform.rotation;
        }

        balls.Enqueue(respawn(balls.Dequeue(), FirePostion.position, roation));


    }

    private GameObject respawn(GameObject obj, Vector3 position, Quaternion roation)
    {
        obj.transform.position = position;
        obj.transform.rotation = roation;
        obj.SetActive(true);
        return obj;
        
    }
}
