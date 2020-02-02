using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnActive : MonoBehaviour
{

    public UnityEvent events;

    private void Awake()
    {
        events.Invoke();
    }

}
