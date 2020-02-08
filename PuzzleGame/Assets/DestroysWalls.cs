using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroysWalls : MonoBehaviour
{
    public LayerMask destroyableLayers;
    public bool destroySelf;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((destroyableLayers.value & 1 << collision.gameObject.layer) != 0)
        {
            if (collision.gameObject.CompareTag("Weak Wall"))
            {
                Debug.Log("Collided with weak wall");
                Destroy(collision.gameObject);
                if (destroySelf)
                    Destroy(gameObject);
            }
        }
    }
}
