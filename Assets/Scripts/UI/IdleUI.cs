using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleUI :UIState {
    [SerializeField]
    private string stateName="idle";
	// Use this for initialization
	
    public override void Enter(UIState from)
    {
        //TODO activate idle UI
        this.gameObject.SetActive(true);
    }

    public override void Exit(UIState to)
    {
        //TODO deactivate idle UI
        this.gameObject.SetActive(false);
    }

    public override string GetName()
    {
        return stateName;
    }

    public void GoToMenuUI()
    {
        _UIManager.SwitchState("menu");
    }
}
