using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class MenuUI:UIState
{
    [SerializeField]
    private string stateName;

    public override void Enter(UIState from)
    {
        //TODO activate menu UI
        this.gameObject.SetActive(true);
    }

    public override void Exit(UIState to)
    {
        //TODO deactivate menu UI
        this.gameObject.SetActive(false);
    }

    public override string GetName()
    {
        return stateName;
    }

    public void GoToIdleUI()
    {
        _UIManager.SwitchState("idle");
    }

}

