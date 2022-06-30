using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DNDisabler : MonoBehaviour
{
    public DragNDrop DND;
    bool cant;

    private void Start()
    {
        DND = FindObjectOfType<DragNDrop>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer != 0)
        {
            DND.IsDrag = false;
        }
    }
}
