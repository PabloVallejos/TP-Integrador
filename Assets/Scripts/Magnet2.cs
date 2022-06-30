using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnet2 : MonoBehaviour
{
    public Transform tg;
    public string pole;
    public float speed;
    public bool mag;

    private void Start()
    {
        mag = false;
    }

    void FixedUpdate()
    {
        if (mag == true && tg != null)
        {
            var step = speed * Time.deltaTime;
            tg.position = Vector2.MoveTowards(tg.position, transform.position, step);
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
            tg.transform.SetParent(this.gameObject.transform);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == pole || collision.gameObject.tag == "M")
        {
            mag = true;
            tg.transform.SetParent(null);
            Debug.Log("Got em");
        }
        if (collision.gameObject.tag == "M")
        {
            mag = false;
            tg.transform.SetParent(null);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Pole" || collision.gameObject.tag == "M")
        {
            mag = false;
            tg = null;
        }
    }
}
