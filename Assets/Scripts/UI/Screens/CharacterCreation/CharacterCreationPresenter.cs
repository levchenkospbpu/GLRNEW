using System;
using System.Collections.Generic;
using Common.MVP;
using UI.Canvas;
using UnityEngine;
using Object = UnityEngine.Object;

namespace UI.Screens.CharacterCreation
{
    public class CharacterCreationPresenter : BasePresenter<CharacterCreationView, CharacterCreationModel>
    {
        protected override GameObject Prefab { get; }
        protected override Transform Parent { get; }
        
        public Action OnApplyHandler;
        public Action<int> OnHairHandler;
        public Action<int> OnHairColorHandler;
        public Action<int> OnSkinColorHandler;
        
        private readonly List<GameObject> _items = new();
        
        public CharacterCreationPresenter(UiCanvasData uiCanvasData, UIProviderConfig uiProviderConfig) : base(uiCanvasData, uiProviderConfig)
        {
            Prefab = uiProviderConfig.CharacterCreation;
            Parent = uiCanvasData.Screens;
        }

        protected override void OnEnable()
        {
            View.ApplyButton.onClick.AddListener(() => OnApplyHandler?.Invoke());
            View.HairButton.onClick.AddListener(HairHandler);
            View.HairColorButton.onClick.AddListener(HairColorHandler);
            View.SkinColorButton.onClick.AddListener(SkinColorHandler);
            
            HairHandler();
        }

        protected override void OnDisable()
        {
            OnApplyHandler = null;
            OnHairHandler = null;
            OnHairColorHandler = null;
            OnSkinColorHandler = null;
        }

        private void HairHandler()
        {
            ClearItems();
            
            for (int i = 0; i < Model.Hairs.Length; i++)
            {
                var index = i;

                var obj = Object.Instantiate(View.HairItemPrefab, View.ScrollContent);
                var script = obj.GetComponent<HairItemButton>();
                script.Text.text = index.ToString();
                script.Button.onClick.AddListener(() => OnHairHandler?.Invoke(index));

                _items.Add(obj);
            }
        }

        private void SkinColorHandler()
        {
            ClearItems();

            for (int i = 0; i < Model.SkinMaterials.Length; i++)
            {
                var index = i;

                var obj = Object.Instantiate(View.SkinColorItemPrefab, View.ScrollContent);
                var script = obj.GetComponent<SkinColorItemButton>();
                script.Image.color = Model.SkinMaterials[index].color;
                script.Button.onClick.AddListener(() => OnSkinColorHandler?.Invoke(index));
                
                _items.Add(obj);
            }
        }

        private void HairColorHandler()
        {
            ClearItems();
            
            for (var i = 0; i < Model.HairMaterials.Length; i++)
            {
                var index = i;

                var obj = Object.Instantiate(View.HairColorItemPrefab, View.ScrollContent);
                var script = obj.GetComponent<HairColorItemButton>();
                script.Image.color = Model.HairMaterials[index].color;
                script.Button.onClick.AddListener(() => OnHairColorHandler?.Invoke(index));
                
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
    }
}