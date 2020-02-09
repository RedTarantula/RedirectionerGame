using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetPushed : MonoBehaviour
{
    public LayerMask lethalLayers;
    public VariablesManager vm;
    public DirCompass dir;
    public Transform spriteTF;
    private void Awake()
    {
        vm = FindObjectOfType<VariablesManager>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            dir = collision.GetComponent<MoveForward>().dir;
            spriteTF.localRotation = Quaternion.Euler(0,0,(int)dir);
            V2Int newCratePos = vm.GetTargetCell(new V2Int((int)transform.position.x,(int)transform.position.y),dir);
            transform.position = new Vector2(newCratePos.x,newCratePos.y);
        }
        if ((lethalLayers.value & 1 << collision.gameObject.layer) != 0)
        {
            if (collision.CompareTag("Water"))
            {
                Destroy(collision.gameObject);
            }
            Destroy(gameObject);
        }

    }
}
