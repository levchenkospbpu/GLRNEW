using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IActionRegister
{
    public void Register(ActionType type, Action action);
    public void Unregister(ActionType type, Action action);
}
