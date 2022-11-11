using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using VContainer;

public class HairColorItemButton : UIElement
{
    [Inject]
    private IActionCaller _actionCaller;
    [Inject]
    private Appearance _appearance;
    private int _id;

    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(ChangeHairColor);
        Initialize();
    }

    private void Initialize()
    {
        GetComponent<Image>().color = _appearance.CustomizationData.HairMaterials[_id].color;
    }

    private void ChangeHairColor()
    {
        _actionCaller.Raise(ActionType.ChangeHairColor, new DataProvider(_id));
    }

    public void SetID(int value)
    {
        _id = value;
    }
}
