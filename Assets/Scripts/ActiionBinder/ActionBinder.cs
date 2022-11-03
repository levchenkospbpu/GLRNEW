using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ActionBinder : IActionCaller, IActionRegister
{
    private readonly Dictionary<ActionType, Action> _bindedActions = new Dictionary<ActionType, Action>();

    public void Register(ActionType type, Action action)
    {
        _bindedActions.Add(type, action);
    }

    public void Unregister(ActionType type, Action action)
    {
        if (_bindedActions.ContainsKey(type))
        {
            _bindedActions[type] -= action;
        }
    }

    public void Raise(ActionType type)
    {
        if (_bindedActions.ContainsKey(type))
        {
            _bindedActions[type]?.Invoke();
        }
    }
}

public enum ActionType
{

}
