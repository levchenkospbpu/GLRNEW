using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VContainer;

public class CustomizationPanel : UIElement
{
    [Inject]
    public UIProvider UIProvider { get; private set; }
    [Inject]
    public Appearance Appearance { get; private set; }
    [Inject]
    public IActionCaller ActionCaller { get; private set; }

    public CustomizationItemsScrollView ItemsScrollView { get; private set; }
    public CancelCustomizationPanel CancelCustomizationPanel { get; private set; }

    public int StartHairID { get; private set; }
    public int StartHairColorID { get; private set; }
    public int StartSkinColorID { get; private set; }
    public int StartTopColorID { get; private set; }
    public int StartBottomColorID { get; private set; }
    public int StartShoesColorID { get; private set; }

    private void Start()
    {
        // StartHairID = Appearance.CurrentHairID;
        // StartHairColorID = Appearance.CurrentHairColorID;
        // StartSkinColorID = Appearance.CurrentSkinColorID;
        // StartTopColorID = Appearance.CurrentTopColorID;
        // StartBottomColorID = Appearance.CurrentBottomColorID;
        // StartShoesColorID = Appearance.CurrentShoesColorID;
        ItemsScrollView = GetComponentInChildren<CustomizationItemsScrollView>();
        CancelCustomizationPanel = GetComponentInChildren<CancelCustomizationPanel>();
        CancelCustomizationPanel.gameObject.SetActive(false);
    }
}
