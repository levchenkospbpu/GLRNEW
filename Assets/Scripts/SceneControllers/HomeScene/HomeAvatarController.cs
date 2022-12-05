using System.Collections.Generic;
using Customization;
using UI;
using UnityEngine;
using VContainer;

namespace SceneControllers.HomeScene
{
    public partial class HomeController
    {
        [Inject] private readonly CustomizationData _customizationData;

        private readonly List<GameObject> _items = new();

        private PlayerData _player;
        private CharacterCreationPanel _characterCreationPanel;

        private int _currentHairId;
        private int _currentHairColorID;
        private int _currentSkinColorID;
        private int _currentTopColorID;
        private int _currentBottomColorID;
        private int _currentShoesColorID;
        
        private void ShowAvatarPanel()
        {
            _player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerData>();
            
            _characterCreationPanel = _uiProvider.Show(typeof(CharacterCreationPanel), GameObject.FindGameObjectWithTag("MainCanvas").transform) as CharacterCreationPanel;

            if (_characterCreationPanel != null)
            {
                _characterCreationPanel.ApplyButton.onClick.AddListener(ApplyHandler);
                _characterCreationPanel.HairButton.onClick.AddListener(HairHandler);
                _characterCreationPanel.HairColorButton.onClick.AddListener(HairColorHandler);
                _characterCreationPanel.SkinColorButton.onClick.AddListener(SkinColorHandler);
                
                Initialize();
            }
        }

        private void Initialize()
        {
            _currentHairId = PlayerPrefs.GetInt(PlayerPrefsKeys.AppearanceHairID, 0);
            _currentHairColorID = PlayerPrefs.GetInt(PlayerPrefsKeys.AppearanceHairColorID, 0);
            _currentSkinColorID = PlayerPrefs.GetInt(PlayerPrefsKeys.AppearanceSkinColorID, 4);
            _currentTopColorID = PlayerPrefs.GetInt(PlayerPrefsKeys.AppearanceTopColorID, 1);
            _currentBottomColorID = PlayerPrefs.GetInt(PlayerPrefsKeys.AppearanceBottomColorID, 2);
            _currentShoesColorID = PlayerPrefs.GetInt(PlayerPrefsKeys.AppearanceShoesColorID, 1);
            
            HairHandler();
        }

        private void ApplyHandler()
        {
            PlayerPrefs.SetInt(PlayerPrefsKeys.AppearanceHairID, _currentHairId);
            PlayerPrefs.SetInt(PlayerPrefsKeys.AppearanceHairColorID, _currentHairColorID);
            PlayerPrefs.SetInt(PlayerPrefsKeys.AppearanceSkinColorID, _currentSkinColorID);
            PlayerPrefs.SetInt(PlayerPrefsKeys.AppearanceTopColorID, _currentTopColorID);
            PlayerPrefs.SetInt(PlayerPrefsKeys.AppearanceBottomColorID, _currentBottomColorID);
            PlayerPrefs.SetInt(PlayerPrefsKeys.AppearanceShoesColorID, _currentShoesColorID);
            
            NextAction(HomeActionType.MainPanel);
        }

        private void HairHandler()
        {
            ClearItems();
            
            for(var i = 0; i < _player.Hair.Length; i++)
            {
                var index = i;
                
                var obj = Object.Instantiate(_characterCreationPanel.HairItemButton, _characterCreationPanel.ScrollContent);
                var script = obj.GetComponent<HairItemButton>();
                script.Text.text = index.ToString();
                script.Button.onClick.AddListener(() =>
                {
                    if (index < 0 || index >= _player.Hair.Length) return;
                    _player.Hair[_currentHairId].gameObject.SetActive(false);
                    _player.Hair[index].gameObject.SetActive(true);
                    _currentHairId = index;
                });
            }
        }

        private void HairColorHandler()
        {
            ClearItems();
            for (var i = 0; i < _customizationData.HairMaterials.Length; i++)
            {
                var index = i;
                
                
            }
        }

        private void SkinColorHandler()
        {
            ClearItems();
            
            for (var i = 0; i < _customizationData.SkinMaterials.Length; i++)
            {
                var index = i;
                
                
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
    }
}