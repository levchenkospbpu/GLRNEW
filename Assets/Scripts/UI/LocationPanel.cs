using Audio;
using System.Collections;
using System.Collections.Generic;
using UI;
using UnityEngine;
using VContainer;

public class LocationPanel : UIElement
{
    [Inject]
    public UIProvider UIProvider { get; private set; }
    [Inject]
    public IActionCaller ActionCaller { get; private set; }
}