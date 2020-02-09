using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Redirectioner : MonoBehaviour
{
    


    public DirCompass dir = DirCompass.N;
    public VariablesManager vm;
    public RotateSelf rClick;
    public Transform spriteTF;
    public bool rotationable = true;

    private void Start()
    {
        if (vm == null)
            vm = FindObjectOfType<VariablesManager>();

        rClick = GetComponent<RotateSelf>();
        if (rClick == null)
        {
            rClick = gameObject.AddComponent<RotateSelf>();
        }


        if (spriteTF == null)
        {
            spriteTF = GetComponentInChildren<SpriteRenderer>().transform;
        }
        dir = rClick.RotateSprite(spriteTF,dir,false);
    }
    private void OnMouseUpAsButton()
    {
        if (rotationable)
        {
            dir = rClick.RotateSprite(spriteTF,dir);
        }
    }

}
