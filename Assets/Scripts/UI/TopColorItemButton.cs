using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using VContainer;

public class TopColorItemButton : UIElement
{
    [Inject]
    private IActionCaller _actionCaller;
    [Inject]
    private Appearance _appearance;
    private int _id;

    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(ChangeTopColor);
        Initialize();
    }

    private void Initialize()
    {
        GetComponent<Image>().color = _appearance.CustomizationData.ClothesMaterials[_id].color;
    }

    private void ChangeTopColor()
    {
        _actionCaller.Raise(ActionType.ChangeTopColor, new DataProvider(_id));
    }

    public void SetID(int value)
    {
        _id = value;
    }
}
