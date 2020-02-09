using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    public DirCompass startingDirection = DirCompass.N;
    public LayerMask lethalLayers;
    VariablesManager vm;
    public float playerSpeed = .1f;
    public MoveForward mf;
    public bool launched = false;
    public PlayerSpawner ps;
    public GManager gm;

    private void Awake()
    {
        mf = GetComponent<MoveForward>();
        if (GetComponent<MoveForward>() == null)
        {
            mf = gameObject.AddComponent<MoveForward>();
        }

        if (ps == null)
            ps = FindObjectOfType<PlayerSpawner>();
    }
    private void Start()
    {


        gm = FindObjectOfType<GManager>();
        vm = FindObjectOfType<VariablesManager>();
        mf.active = launched;
        mf.dir = startingDirection;
    }

    public void Launch()
    {
        mf.active = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Finishing Line"))
        {
            Debug.Log("Reached finishing line");
            mf.active = false;
        }
    }

    public void Die()
    {
        ps.SpawnPlayer();
        gm.PauseSteps();
        Destroy(gameObject);
    }
}
