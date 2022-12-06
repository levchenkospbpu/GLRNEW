using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VContainer;

public class MapPanel : UIElement
{
    [Inject]
    public IActionCaller ActionCaller { get; private set; }
}
