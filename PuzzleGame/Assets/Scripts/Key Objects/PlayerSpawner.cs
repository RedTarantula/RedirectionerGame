using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSpawner : MonoBehaviour
{
    public GameObject playerPref;
    public DirCompass startingDir = DirCompass.N;
    public Button launchButton;

    public void Start()
    {
        SpawnPlayer();
    }

    public void SpawnPlayer()
    {
        PlayerCtrl p = Instantiate(playerPref).GetComponent<PlayerCtrl>();
        p.transform.position = transform.position;
        p.launched = false;
        p.ps = this;
        p.mf.dir = startingDir;
        launchButton.onClick.RemoveAllListeners();
        launchButton.onClick.AddListener(p.Launch);
    }
}
