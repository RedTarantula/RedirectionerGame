using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    public DirCompass dir = DirCompass.N;
    VariablesManager vm;
    public float playerSpeed = .1f;
    MoveForward mf;
    public bool launched = false;
    private void Start()
    {
        mf = GetComponent<MoveForward>();
        if(GetComponent<MoveForward>() == null)
        {
            mf = gameObject.AddComponent<MoveForward>();
        }
        vm = FindObjectOfType<VariablesManager>();
        NewDirection();
        mf.active = launched;
    }

    public void Launch()
    {
        mf.active = true;
    }

    private void NewDirection()
    {
        transform.localRotation = Quaternion.Euler(0f,0f,(float)dir);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Redirectioner"))
        {
            Redirectioner rdr = collision.gameObject.GetComponent<Redirectioner>();
            dir = rdr.dir;
            NewDirection();
        }
        else if (collision.gameObject.CompareTag("Finishing Line"))
        {
            Debug.Log("Reached finishing line");
        }
    }
}
