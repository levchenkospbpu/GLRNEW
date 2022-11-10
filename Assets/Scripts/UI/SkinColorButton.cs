using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkinColorButton : MonoBehaviour
{
    [SerializeField] private CharacterCreationPanel _characterCreationPanel;

    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(HideGenderButtons);
        GetComponent<Button>().onClick.AddListener(ShowItemsScrollViev);
        GetComponent<Button>().onClick.AddListener(LoadSkinColorItems);
    }

    private void HideGenderButtons()
    {
        _characterCreationPanel.MaleButton.gameObject.SetActive(false);
        _characterCreationPanel.FemaleButton.gameObject.SetActive(false);
    }

    private void ShowItemsScrollViev()
    {
        _characterCreationPanel.ItemsScrollView.gameObject.SetActive(true);
    }

    private void LoadSkinColorItems()
    {
        _characterCreationPanel.ItemsScrollView.LoadSkinColorItems();
    }
}
