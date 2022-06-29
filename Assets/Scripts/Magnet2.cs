using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnet2 : MonoBehaviour
{
    public Transform tg;
    public FrictionJoint2D joint;
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
            joint.connectedBody = collision.gameObject.GetComponent<Rigidbody2D>();
        }
        if (collision.gameObject.tag == "M")
        {
            mag = false;
            joint.connectedBody = collision.gameObject.GetComponent<Rigidbody2D>();
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == pole || collision.gameObject.tag == "M")
        {
            mag = true;
            joint.connectedBody = null;
            Debug.Log("Got em");
        }
        if (collision.gameObject.tag == "M")
        {
            mag = false;
            joint.connectedBody = null;
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
