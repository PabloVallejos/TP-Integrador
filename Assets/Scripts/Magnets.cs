using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnets : MonoBehaviour
{
    public Transform tg;
    public string pole;
    public float speed;
    public bool mag;
    public bool rep;

    private void Start()
    {
        mag = false;
        rep = false;
    }

    void FixedUpdate()
    {
        if (mag == true && tg != null)
        {
            var step = speed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, tg.position, step);
        }
        if (rep == true && tg != null)
        {
            var step = -speed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, tg.position, step);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == pole || collision.gameObject.tag == "M")
        {
            mag = true;
            tg = collision.gameObject.transform;
            Debug.Log("Got em");
        }
        if (collision.gameObject.tag == gameObject.tag)
        {
            rep = true;
            tg = collision.gameObject.transform;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == pole)
        {
            mag = false;
        }
        if (collision.gameObject.tag == "M")
        {
            mag = false;
            gameObject.transform.SetParent(collision.gameObject.transform);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == pole || collision.gameObject.tag == "M")
        {
            mag = true;
            tg = collision.gameObject.transform;
            Debug.Log("Got em");
        }
        if (collision.gameObject.tag == "M")
        {
            mag = false;
            gameObject.transform.SetParent(null);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Pole" || collision.gameObject.tag == "M")
        {
            mag = false;
            tg = null;
        }
        if (collision.gameObject.tag == gameObject.tag)
        {
            rep = false;
            tg = null;
        }
    }
}
