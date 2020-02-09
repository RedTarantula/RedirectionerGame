using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DestroyWithLethal : MonoBehaviour
{
    [SerializeField]
    public LayerMask lethalLayers;
    public UnityEvent OnPlayerDestroy = new UnityEvent();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((lethalLayers.value & 1 << collision.gameObject.layer) != 0)
        {
            //Debug.Log("Collided with lethal");
            if(gameObject.CompareTag("Player"))
            {
                OnPlayerDestroy.Invoke();
                return;
            }
            Destroy(gameObject);
        }
    }
}
