using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ActionBinder : IActionCaller, IActionRegister
{
    private readonly Dictionary<ActionType, Action<DataProvider>> _bindedActions = new Dictionary<ActionType, Action<DataProvider>>();

    public void Register(ActionType type, Action<DataProvider> action)
    {
        _bindedActions.Add(type, action);
    }

    public void Unregister(ActionType type, Action<DataProvider> action)
    {
        if (_bindedActions.ContainsKey(type))
        {
            _bindedActions[type] -= action;
        }
    }

    public void Raise(ActionType type, DataProvider dataProvider)
    {
        if (_bindedActions.ContainsKey(type))
        {
            _bindedActions[type]?.Invoke(dataProvider);
        }
    }
}

public enum ActionType
{
    LoadScene,
    SetChangeableSlotType,
    SetChangeableCharacterID,
    SetPartyCurrentIDs,
    SaveParty,
    ResetIDs
}
