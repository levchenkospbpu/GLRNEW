using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VContainer;

public class CharacterCreationPanel : UIElement
{
    [Inject]
    public UIProvider UIProvider { get; private set; }
    [Inject]
    public Appearance Appearance { get; private set; }

    public MaleButton MaleButton { get; private set; }
    public FemaleButton FemaleButton { get; private set; }
    public CharacterCreationItemsScrollView ItemsScrollView { get; private set; }

    private void Start()
    {
        //MaleButton = GetComponentInChildren<MaleButton>();
        //FemaleButton = GetComponentInChildren<FemaleButton>();
        ItemsScrollView = GetComponentInChildren<CharacterCreationItemsScrollView>();
        //ItemsScrollView.gameObject.SetActive(false);
    }
}
