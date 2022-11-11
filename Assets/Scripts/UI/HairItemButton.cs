using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using VContainer;

public class HairItemButton : UIElement
{
    [Inject]
    private IActionCaller _actionCaller;
    private int _id;

    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(ChangeHair);
        Initialize();
    }

    private void Initialize()
    {
        GetComponentInChildren<TextMeshProUGUI>().text = _id.ToString();
    }

    private void ChangeHair()
    {
        _actionCaller.Raise(ActionType.ChangeHair, new DataProvider(_id));
    }

    public void SetID(int value)
    {
        _id = value;
    }
}
