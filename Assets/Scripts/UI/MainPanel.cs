using System.Collections;
using System.Collections.Generic;
using UI;
using UnityEngine;
using VContainer;

public class MainPanel : UIElement
{
    [Inject]
    public UIProvider UIProvider { get; private set; }
}
