using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    enum CrateInteract { Die, Destroy, Push }

    public DirCompass dir;
    public VariablesManager vm;
    public bool active = true;
    public bool destroysCrates = false;
    public Transform spriteTF;
    [SerializeField]
    public V2Int tg;
    [SerializeField]
    public V2Int currentPos;
    public bool pushNext=false;
    private void Awake()
    {
        vm = FindObjectOfType<VariablesManager>();
    }

    public void TurnStep()
    {
        if (active)
        {
            spriteTF.localRotation = Quaternion.Euler(0f,0f,(float)dir);
            currentPos = new V2Int((int)transform.position.x,(int)transform.position.y);
            tg = vm.GetTargetCell(currentPos,dir);
            transform.position = new Vector2(tg.x,tg.y);

        }
    }
}
