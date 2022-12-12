using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using Common.MVP;
using UI.Canvas;
using UnityEngine;
using UnityEngine.UI;
using Object = UnityEngine.Object;

namespace UI.Screens.CustomizationPanel
{
    public class HomeCustomizationPanelPresenter : BasePresenter<HomeCustomizationPanelView, HomeCustomizationPanelModel>
    {
        protected override GameObject Prefab { get; }
        protected override Transform Parent { get; }
        
        public Action OnApplyButton;
        public Action OnCancelButton;
        public Action<int> OnHairButton;
        public Action<int> OnHairColorButton;
        public Action<int> OnTopColorButton;
        public Action<int> OnBottomColorButton;
        public Action<int> OnShoesColorButton;
        
        private readonly List<GameObject> _items = new();

        public HomeCustomizationPanelPresenter(UiCanvasData uiCanvasData, UIProviderConfig uiProviderConfig) : base(uiCanvasData, uiProviderConfig)
        {
            Prefab = uiProviderConfig.HomeCustomizationPanel;
            Parent = uiCanvasData.Screens;
        }

        protected override void OnEnable()
        {
            View.ApplyButton.onClick.AddListener(() => OnApplyButton?.Invoke());
            View.CancelButton.onClick.AddListener(() => OnCancelButton?.Invoke());
            View.HairButton.onClick.AddListener(HairHandler);
            View.HairColorButton.onClick.AddListener(HairColorHandler);
            View.TopColorButton.onClick.AddListener(TopColorHandler);
            View.BottomColorButton.onClick.AddListener(BottomColorHandler);
            View.ShoesColorButton.onClick.AddListener(ShoesColorHandler);
        }

        private void HairHandler()
        {
            ClearItems();
            
            for (int i = 0; i < Model.Hairs.Length; i++)
            {
                var index = i;

                var obj = Object.Instantiate(View.HairItemPrefab, View.ScrollContent);
                obj.GetComponent<Image>().color = new Color(1, 1, 1);
                obj.GetComponent<Button>().onClick.AddListener(() => OnHairButton?.Invoke(index));

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
                obj.GetComponent<Image>().color = Model.HairMaterials[index].color;
                obj.GetComponent<Button>().onClick.AddListener(() => OnHairColorButton?.Invoke(index));
                
                _items.Add(obj);
            }
        }
        
        private void TopColorHandler()
        {
            ClearItems();
            
            for (int i = 0; i < Model.ClothesMaterials.Length; i++)
            {
                var index = i;
                
                var obj = Object.Instantiate(View.TopColorItemPrefab, View.ScrollContent);
                obj.GetComponent<Image>().color = Model.ClothesMaterials[index].color;
                obj.GetComponent<Button>().onClick.AddListener(() => OnTopColorButton?.Invoke(index));
                
                _items.Add(obj);
            }
        }
        
        private void BottomColorHandler()
        {
            ClearItems();
            
            for (int i = 0; i < Model.ClothesMaterials.Length; i++)
            {
                var index = i;

                var obj = Object.Instantiate(View.BottomColorItemPrefab, View.ScrollContent);
                obj.GetComponent<Image>().color = Model.ClothesMaterials[index].color;
                obj.GetComponent<Button>().onClick.AddListener(() => OnBottomColorButton?.Invoke(index));
                
                _items.Add(obj);
            }
        }
        
        private void ShoesColorHandler()
        { 
            ClearItems();
        
            for (int i = 0; i < Model.ClothesMaterials.Length; i++)
            {
                var index = i;

                var obj = Object.Instantiate(View.ShoesColorItemPrefab, View.ScrollContent);
                obj.GetComponent<Image>().color = Model.ClothesMaterials[index].color;
                obj.GetComponent<Button>().onClick.AddListener(() => OnShoesColorButton?.Invoke(index));
                
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
            OnApplyButton = null;
            OnCancelButton = null;
            OnHairButton = null;
            OnHairColorButton = null;
            OnTopColorButton = null;
            OnBottomColorButton = null;
            OnShoesColorButton = null;
        }
    }
}