using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using VContainer;

public class BottomColorItemButton : UIElement
{
    [Inject]
    private IActionCaller _actionCaller;
    [Inject]
    private Appearance _appearance;
    private int _id;

    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(ChangeBottomColor);
        Initialize();
    }

    private void Initialize()
    {
        GetComponent<Image>().color = _appearance.CustomizationData.ClothesMaterials[_id].color;
    }

    private void ChangeBottomColor()
    {
        _actionCaller.Raise(ActionType.ChangeBottomColor, new DataProvider(_id));
    }

    public void SetID(int value)
    {
        _id = value;
    }
}
