using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cannon : MonoBehaviour
{
    public DirCompass dir = DirCompass.N;
    public GameObject bulletPref;
    public VariablesManager vm;
    public int waitSteps = 2;
    public int startSteps = 0;
    public int currentWait = 0;
    public bool rotationable = false;
    public Text waitText;

    private void Start()
    {
        vm = FindObjectOfType<VariablesManager>();
        currentWait = startSteps;
    }

    public void TurnStep()
    {
        if(currentWait == 0)
        {
            ShootCannon();
            currentWait = waitSteps;
        }
        else
        {
            currentWait--;
        }
        waitText.text = currentWait.ToString();
    }

    void ShootCannon()
    {
        GameObject go = Instantiate(bulletPref);
        V2Int tPos = vm.GetTargetCell(dir);
        go.transform.position = new Vector2(tPos.x,tPos.y);
        go.GetComponent<MoveForward>().dir = dir;
    }
}
