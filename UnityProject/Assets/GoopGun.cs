using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoopGun : MonoBehaviour
{
    public GameObject GoopProjectile;
    public Transform FirePostion;
    // Start is called before the first frame update
    void Start()
    {
        
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
        Instantiate(GoopProjectile, FirePostion.position, roation);
    }
}
