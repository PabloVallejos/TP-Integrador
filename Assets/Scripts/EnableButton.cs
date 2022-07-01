using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnableButton : MonoBehaviour
{
    public Button boton;
    public DragNDrop DND;
    public Switch[] s;
    private bool done;

    private void Start()
    {
        boton.enabled = false;
        boton.image.enabled = false;
        DND = FindObjectOfType<DragNDrop>();
    }

    private void FixedUpdate()
    {
        for(int i = 0; i < s.Length; i++)
        {
            if(s[i].on == false) 
            { 
                done = false;
            }
            else 
            { 
                if (s[i].on == true)
                {
                    done = true;
                }
            }
        }
        if (done == true)
        {
            boton.enabled = true;
            boton.image.enabled = true;
            DND.enabled = false;
        }
        if (done == false)
        {
            boton.enabled = false;
            boton.image.enabled = false;
            DND.enabled = true;
        }
    }
}
