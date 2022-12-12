using System.Collections;
using System.Collections.Generic;
using UI.Canvas;
using UI;
using UnityEngine;
using Common.MVP;
using System;
using Object = UnityEngine.Object;
using static UnityEditor.Progress;
using UnityEngine.UI;

public class CharacterInfoPresenter : BasePresenter<CharacterInfoView, CharacterInfoModel>
{
    protected override GameObject Prefab { get; }
    protected override Transform Parent { get; }

    public Action OnChooseButton;
    public Action<int> OnCharacterHandler;

    private readonly List<GameObject> _items = new();

    public CharacterInfoPresenter(UiCanvasData uiCanvasData, UIProviderConfig uiProviderConfig) : base(uiCanvasData, uiProviderConfig)
    {
        Prefab = uiProviderConfig.CharacterInfoPanel;
        Parent = uiCanvasData.Screens;
    }

    protected override void OnEnable()
    {
        View.ChooseButton.onClick.AddListener(() => OnChooseButton?.Invoke());

        LoadCharacterButtons();
    }

    private void LoadCharacterButtons()
    {
        ClearItems();

        for (int i = 0; i < Model.Characters.Length; i++)
        {
            var index = i;

            var obj = Object.Instantiate(View.CharacterItemPrefab, View.ScrollContent);
            obj.GetComponent<Image>().sprite = Model.Characters[i].Icon;
            obj.GetComponent<Button>().onClick.AddListener(() => OnCharacterHandler?.Invoke(index));

            _items.Add(obj);
        }
    }

    private void ClearItems()
    {
        foreach (var item in _items)
        {
            Object.Destroy(item);
        }
        _items.Clear();
    }

    protected override void OnDisable()
    {
        OnChooseButton = null;
    }
}
