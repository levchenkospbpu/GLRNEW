using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VContainer.Unity;

[CreateAssetMenu(fileName = "NewUIProviderConfig", menuName = "Data/UIProviderConfig")]
public class UIProviderConfig : ScriptableObject
{
    [field: SerializeField] public List<UIElement> UIPrefabs { get; private set; }
}
