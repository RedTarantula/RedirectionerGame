using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{
    public bool locked = true;

    public void Start()
    {
        UpdateGate();
    }

    public void ToggleGate()
    {
        locked = !locked;
        UpdateGate();

    }

    public void UpdateGate()
    {
        if(locked)
        {
            GetComponentInChildren<SpriteRenderer>().color = Color.magenta;
            gameObject.layer = 9;
        }
        else
        {
            GetComponentInChildren<SpriteRenderer>().color = Color.grey;
            gameObject.layer = 12;
        }
    }

}
