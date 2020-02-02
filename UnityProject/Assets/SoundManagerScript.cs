using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{
    public static AudioClip playerShootSound, walkSound, chompSound, clickSound;
    static AudioSource audioSrc;


    // Start is called before the first frame update
    void Start()
    {

        playerShootSound = Resources.Load<AudioClip>("Splat");
        walkSound = Resources.Load<AudioClip>("Walk");
        chompSound = Resources.Load<AudioClip>("Chomp");
        clickSound = Resources.Load<AudioClip>("Click");

        audioSrc = GetComponent<AudioSource>();


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void PlaySound (string clip)
    {
        switch (clip) {
            case "Walk":
                audioSrc.PlayOneShot(walkSound);
                break;
            case "Chomp":
                audioSrc.PlayOneShot(chompSound);
                break;
            case "Splat":
                audioSrc.PlayOneShot(playerShootSound);
                break;
            case "Click":
                audioSrc.PlayOneShot(clickSound);
                break;

        }


    }


}
