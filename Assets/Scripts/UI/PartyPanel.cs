using System;
using System.Collections.Generic;
using UnityEngine;
using VContainer;

public class PartyPanel : UIElement
{
    [Inject]
    public UIProvider UIProvider { get; protected set; }
    [Inject]
    public IActionCaller ActionCaller { get; protected set; }
    [Inject]
    public Party Party { get; protected set; }
    [field: SerializeField] public GameObject CharacterInfoPanel { get; private set; }
    [field: SerializeField] public PartySlotButton[] PartySlotButtons { get; private set; }
    [field: SerializeField] public List<GameObject> ObjectsToHideWhenChanging { get; private set; }
    [field: SerializeField] public CharacterInfoScrollView CharacterInfoScrollView { get; private set; }
    [field: SerializeField] public SongsPanel SongsPanel { get; private set; }
    private Type _prevPanelType;

    private void Start()
    {
        UpdatePartySlotsUI();
        SongsPanel = UIProvider.Instantiate(typeof(SongsPanel), transform) as SongsPanel;
        ObjectsToHideWhenChanging.Add(SongsPanel.gameObject);
        LoadSongs();
    }

    public void UpdatePartySlotsUI()
    {
        foreach (PartySlotButton partySlotButton in PartySlotButtons)
        {
            partySlotButton.Initialize();
        }
    }

    public void LoadSongs()
    {
        SongsPanel.LoadSongButtons();
    }

    public void HideObjects()
    {
        foreach (GameObject obj in ObjectsToHideWhenChanging)
        {
            obj.SetActive(false);
        }
    }

    public void ShowObjects()
    {
        foreach (GameObject obj in ObjectsToHideWhenChanging)
        {
            obj.SetActive(true);
        }
        UpdatePartySlotsUI();
        LoadSongs();
    }

    public void HideCharacterInfo()
    {
        CharacterInfoPanel.SetActive(false);
    }

    public void ShowCharacterInfo()
    {
        CharacterInfoPanel.SetActive(true);
    }

    public void LoadCharacterButtons()
    {
        CharacterInfoScrollView.LoadCharacterButtons();
    }

    public void SetPrevPanelType(Type type)
    {
        _prevPanelType = type;
    }

    public Type GetPrevPanelType()
    {
        return _prevPanelType;
    }
}
