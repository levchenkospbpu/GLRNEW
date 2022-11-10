using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IActionCaller
{
    public void Raise(ActionType type, DataProvider dataProvider);
}
