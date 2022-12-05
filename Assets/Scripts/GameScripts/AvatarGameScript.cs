using System.Collections.Generic;
using Customization;
using SceneControllers;
using UI;
using UnityEngine;
using VContainer;

namespace GameScripts
{
    public class AvatarGameScript : GameScriptBase
    {
        [Inject] private readonly ISceneController _sceneController;
        [Inject] private readonly CustomizationData _customizationData;
        [Inject] private readonly UIProvider _uiProvider;

        private readonly List<GameObject> _items = new();

        private PlayerData _player;
        private CharacterCreationPanel _characterCreationPanel;

        private int _currentHairId;
        private int _currentHairColorID;
        private int _currentSkinColorID;
        private int _currentTopColorID;
        private int _currentBottomColorID;
        private int _currentShoesColorID;
        
        public override void OnStart()
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
            
            _sceneController.StartGameScript(typeof(MainPanelGameScript));
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
                
                _items.Add(obj);
            }
        }

        private void HairColorHandler()
        {
            ClearItems();
            for (var i = 0; i < _customizationData.HairMaterials.Length; i++)
            {
                var index = i;

                var obj = Object.Instantiate(_characterCreationPanel.HairColorItemButton, _characterCreationPanel.ScrollContent);
                var script = obj.GetComponent<HairColorItemButton>();
                script.Image.color = _customizationData.HairMaterials[index].color;
                script.Button.onClick.AddListener(() =>
                {
                    foreach (var hair in _player.Hair)
                    {
                        hair.material = _customizationData.HairMaterials[index];
                    }
                    _currentHairColorID = index;
                });
                
                _items.Add(obj);
            }
        }

        private void SkinColorHandler()
        {
            ClearItems();
            
            for (var i = 0; i < _customizationData.SkinMaterials.Length; i++)
            {
                var index = i;

                var obj = Object.Instantiate(_characterCreationPanel.SkinColorItemButton, _characterCreationPanel.ScrollContent);
                var script = obj.GetComponent<SkinColorItemButton>();
                script.Image.color = _customizationData.SkinMaterials[index].color;
                script.Button.onClick.AddListener(() =>
                {
                    var bodyMaterials = _player.Body.materials;
                    bodyMaterials[0] = _customizationData.SkinMaterials[index];
                    _player.Body.materials = bodyMaterials;

                    var faceMaterials = _player.Face.materials;
                    faceMaterials[3] = _customizationData.SkinMaterials[index];
                    _player.Face.materials = faceMaterials;
                    
                    _currentSkinColorID = index;
                });
                
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

        public override void OnDestroy()
        {
            
        }
    }
}