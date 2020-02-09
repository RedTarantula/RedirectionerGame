using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GManager : MonoBehaviour
{
    public UnityEvent turnStep = new UnityEvent();
    public float actionTimer = 0f;
    public int stepsPerSecond = 2;


    private void Start()
    {
        
        MoveForward[] mfd = FindObjectsOfType<MoveForward>();
        foreach (MoveForward m in mfd)
        {
            turnStep.AddListener(m.TurnStep);
        }
        Cannon[] cn = FindObjectsOfType<Cannon>();
        foreach (Cannon c in cn)
        {
            turnStep.AddListener(c.TurnStep);
        }

    }

    public void AddToStepsEvent(UnityAction function)
    {
        turnStep.AddListener(function);
    }

    private void Update()
    {
        if(actionTimer <= 0)
        {
            actionTimer = 1f/stepsPerSecond;
            //Debug.Log("Invoking turn step event");
            turnStep.Invoke();
        }
        else
        {
            actionTimer -= Time.deltaTime;
        }
    }
}
