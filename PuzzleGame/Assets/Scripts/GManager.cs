using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GManager : MonoBehaviour
{
    public enum StepsState {Paused,Playing,OneStep };

    public StepsState state = StepsState.Paused;
    public UnityEvent turnStep = new UnityEvent();
    public float actionTimer = 0f;
    public int stepsPerSecond = 2;
    public bool pausedSteps;

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

    public void PauseSteps()
    {
        state = StepsState.Paused;
    }
    public void RestartSteps()
    {
        actionTimer = 1f / stepsPerSecond;
        StartSteps();
    }
    public void StartSteps()
    {
        state = StepsState.Playing;
    }

    public void OneStep()
    {
        state = StepsState.OneStep;
    }

    private void Update()
    {
        if (state != StepsState.Paused)
        {
            if(state == StepsState.OneStep)
            {
                turnStep.Invoke();
                state = StepsState.Paused;
                return;
            }

            if (actionTimer <= 0)
            {
                actionTimer = 1f / stepsPerSecond;
                //Debug.Log("Invoking turn step event");
                turnStep.Invoke();
            }
            else
            {
                actionTimer -= Time.deltaTime;
            }
        }
    }
}
