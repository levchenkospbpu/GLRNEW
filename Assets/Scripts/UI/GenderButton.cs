using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GenderButton : MonoBehaviour
{
    [SerializeField] private CharacterCreationPanel _characterCreationPanel;

    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(ShowGenderButtons);
        GetComponent<Button>().onClick.AddListener(HideItemsScrollViev);
    }

    private void ShowGenderButtons()
    {
        _characterCreationPanel.MaleButton.gameObject.SetActive(true);
        _characterCreationPanel.FemaleButton.gameObject.SetActive(true);
    }

    private void HideItemsScrollViev()
    {
        _characterCreationPanel.ItemsScrollView.gameObject.SetActive(false);
    }
}
