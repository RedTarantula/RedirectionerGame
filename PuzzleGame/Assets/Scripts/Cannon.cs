using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cannon : MonoBehaviour
{
    public DirCompass dir = DirCompass.N;
    public GameObject bulletPref;
    public VariablesManager vm;
    public RotateSelf rs;
    public GManager gm;
    public int waitSteps = 2;
    public int startSteps = 0;
    public int currentWait = 0;
    public bool rotationable = false;
    public Text waitText;
    public Transform spriteTF;

    private void Start()
    {
        vm = FindObjectOfType<VariablesManager>();
        gm = FindObjectOfType<GManager>();
        rs = GetComponent<RotateSelf>();
        rs.RotateSprite(spriteTF,dir,false);
        currentWait = 1;
    }

    public void TurnStep()
    {
        if (currentWait == 0)
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

        V2Int currentPos = new V2Int((int)transform.position.x,(int)transform.position.y);
        V2Int tg = vm.GetTargetCell(currentPos,dir);

        go.transform.position = new Vector2(tg.x,tg.y);
        MoveForward gomf = go.GetComponent<MoveForward>();
        gomf.dir = dir;
        gomf.active = true;
        gm.AddToStepsEvent(gomf.TurnStep);
    }

    private void OnMouseUpAsButton()
    {
        if(rotationable)
        {
            rs = GetComponent<RotateSelf>();
            if (rs == null)
                rs = gameObject.AddComponent<RotateSelf>();

            dir = rs.RotateSprite(spriteTF,dir);
        }
    }
}
