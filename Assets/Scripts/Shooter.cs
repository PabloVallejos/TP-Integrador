using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public Rigidbody2D bull;
    public Transform muzzle;
    public float Stimer;
    private float timer;

    private void Start()
    {
        timer = Stimer;
    }

    private void FixedUpdate()
    {
        timer--;
        if (timer <= 0) 
        {
            Instantiate(bull, muzzle.position, gameObject.transform.rotation);
            timer = Stimer;
        }
    }
}
