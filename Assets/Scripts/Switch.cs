using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    public string pole;
    public bool on = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == pole)
        {
            collision.gameObject.transform.position = gameObject.transform.position;
            collision.gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
            //collision.GetComponent<Magnets>().enabled = false;
            on = true;
        }
    }
}
