using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using VContainer;

public class SkinColorItemButton : UIElement
{
    [Inject]
    private IActionCaller _actionCaller;
    [Inject]
    private Appearance _appearance;
    private int _id;

    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(ChangeSkinColor);
        Initialize();
    }

    private void Initialize()
    {
        GetComponent<Image>().color = _appearance.CustomizationData.SkinMaterials[_id].color;
    }

    private void ChangeSkinColor()
    {
        _actionCaller.Raise(ActionType.ChangeSkinColor, new DataProvider(_id));
    }

    public void SetID(int value)
    {
        _id = value;
    }
}
