using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateButton : MonoBehaviour
{
    public List<Gate> gates = new List<Gate>();
    public bool broken = false;

    public void BreakButton()
    {
        broken = false;
    }

    public void ToggleButton()
    {
        if(gates.Count <= 0)
        {
            Debug.LogError("No gates set for button");
            return;
        }

        if (!broken)
        {
            foreach (Gate g in gates)
            {
                g.ToggleGate();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            ToggleButton();
        }
        else if (collision.CompareTag("CannonBall"))
        {
            BreakButton();
        }
    }

}
