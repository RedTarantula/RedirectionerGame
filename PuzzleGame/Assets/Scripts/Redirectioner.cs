using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Redirectioner : MonoBehaviour
{

    public DirCompass dir = DirCompass.N;
    public VariablesManager vm;
    public RotateSelf rClick;
    public Text debugDirection;
    public Transform spriteTF;

    private void Start()
    {
        if (vm == null)
            vm = FindObjectOfType<VariablesManager>();

        if (rClick == null)
        {
            rClick = GetComponent<RotateSelf>();
            if (rClick == null)
            {
                rClick = gameObject.AddComponent<RotateSelf>();
            }
        }

        if(spriteTF == null)
        {
            spriteTF = GetComponentInChildren<SpriteRenderer>().transform;
        }

        transform.localRotation = Quaternion.Euler(0f,0f,(float)dir);
        debugDirection.text = dir.ToString();
    }
    private void OnMouseUpAsButton()
    {
        dir = rClick.RotateSprite(spriteTF,dir);
        debugDirection.text = dir.ToString();
    }
}
