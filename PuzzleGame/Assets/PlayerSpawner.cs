using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    public GameObject playerPref;

    public void Start()
    {
        SpawnPlayer();
    }

    public void SpawnPlayer()
    {
        PlayerCtrl p = Instantiate(playerPref).GetComponent<PlayerCtrl>();
        p.mf.active = false;
        p.ps = this;
    }
}
