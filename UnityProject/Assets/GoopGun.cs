using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoopGun : MonoBehaviour
{
    public GameObject GoopProjectile;
    public GameObject GoopBounceProjectile;
    public Transform FirePostion;

    public int ballNumToSpawn;
    public int ballBounceNum;
    Queue<GameObject> balls;
    Queue<GameObject> ballsbounce;
    // Start is called before the first frame update
    void Start()
    {
        balls = new Queue<GameObject>();
        for (int i = 0; i < ballNumToSpawn; i++)
        {
            GameObject ball = Instantiate(GoopProjectile);
            ball.SetActive(false);
            balls.Enqueue(ball);
        }

        ballsbounce = new Queue<GameObject>();
        for (int i = 0; i < ballBounceNum; i++)
        {
            GameObject ball = Instantiate(GoopBounceProjectile);
            ball.SetActive(false);
            ballsbounce.Enqueue(ball);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Fire(bool fliped)
    {
        SoundManagerScript.PlaySound("Splat");
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

    public void FireBounce(bool fliped)
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
        
        ballsbounce.Enqueue(respawn(ballsbounce.Dequeue(), FirePostion.position, roation));
    }

    private GameObject respawn(GameObject obj, Vector3 position, Quaternion roation)
    {
        obj.GetComponent<GoopShoot>().InstantRemove();
        obj.transform.position = position;
        obj.transform.rotation = roation;
        obj.SetActive(true);
        return obj;
        
    }
}
