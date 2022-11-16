using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using VContainer;

public class ShoesColorItemButton : UIElement
{
    [Inject]
    private IActionCaller _actionCaller;
    [Inject]
    private Appearance _appearance;
    private int _id;

    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(ChangeShoesColor);
        Initialize();
    }

    private void Initialize()
    {
        GetComponent<Image>().color = _appearance.CustomizationData.ClothesMaterials[_id].color;
    }

    private void ChangeShoesColor()
    {
        _actionCaller.Raise(ActionType.ChangeShoesColor, new DataProvider(_id));
    }

    public void SetID(int value)
    {
        _id = value;
    }
}
