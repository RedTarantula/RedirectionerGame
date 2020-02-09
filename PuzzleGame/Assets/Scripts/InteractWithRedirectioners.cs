using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractWithRedirectioners : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Redirectioner"))
        {
            Redirectioner rdr = collision.gameObject.GetComponent<Redirectioner>();
            MoveForward mf = GetComponent<MoveForward>();
            mf.dir = rdr.dir;
        }
    }
}
