using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    public DirCompass dir;
    public VariablesManager vm;
    public bool active = true;
    private void Awake()
    {
        vm = FindObjectOfType<VariablesManager>();
    }

    public void TurnStep()
    {
        if (active)
        {
            V2Int tg = vm.GetTargetCell(dir);
            transform.position = new Vector2(tg.x,tg.y);
        }
    }
}
