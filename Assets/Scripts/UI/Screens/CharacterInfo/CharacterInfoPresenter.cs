using System.Collections;
using System.Collections.Generic;
using UI.Canvas;
using UI;
using UnityEngine;
using Common.MVP;
using System;

public class CharacterInfoPresenter : BasePresenter<CharacterInfoView, CharacterInfoModel>
{
    protected override GameObject Prefab { get; }
    protected override Transform Parent { get; }

    public Action OnChooseButton;

    public CharacterInfoPresenter(UiCanvasData uiCanvasData, UIProviderConfig uiProviderConfig) : base(uiCanvasData, uiProviderConfig)
    {
        Prefab = uiProviderConfig.PartyPanel;
        Parent = uiCanvasData.Screens;
    }

    protected override void OnEnable()
    {
        View.ChooseButton.onClick.AddListener(() => OnChooseButton?.Invoke());
    }

    protected override void OnDisable()
    {
        OnChooseButton = null;
    }
}
