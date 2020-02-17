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
        launchButton = GameObject.Find("LaunchPlayer").GetComponent<Button>();
        SpawnPlayer();
    }

    public void SpawnPlayer()
    {
        GameObject go = Instantiate(playerPref);
        PlayerCtrl p = go.GetComponent<PlayerCtrl>();
        p.transform.position = transform.position;
        p.launched = false;
        p.ps = this;
        p.mf.dir = startingDir;
        go.transform.SetParent(transform);
        launchButton.onClick.RemoveAllListeners();
        launchButton.onClick.AddListener(p.Launch);
    }
}
