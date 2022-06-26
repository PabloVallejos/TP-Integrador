using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnableButton : MonoBehaviour
{
    public Button boton;
    public Switch[] s;
    private bool done;

    private void Start()
    {
        boton.enabled = false;
        boton.image.enabled = false;
    }

    private void Update()
    {
        for(int i = 0; i < s.Length; i++)
        {
            if(s[i].on == false) 
            { 
                done = false;
            }
            else { done = true; }
        }
        if (done == true)
        {
            boton.enabled = true;
            boton.image.enabled = true;
        }
    }
}
