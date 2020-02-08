using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyWithLethal : MonoBehaviour
{
    [SerializeField]
    public LayerMask lethalLayers;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((lethalLayers.value & 1 << collision.gameObject.layer) != 0)
        {
            Debug.Log("Collided with lethal");
            Destroy(gameObject);
        }
    }
}
