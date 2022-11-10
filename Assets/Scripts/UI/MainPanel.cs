using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VContainer;

public class MainPanel : UIElement
{
    [Inject]
    public UIProvider UIProvider { get; private set; }
}
