using System;
using System.Collections.Generic;
using Common.MVP;
using UnityEngine;
using Object = UnityEngine.Object;

namespace UI.Screens.CustomizationPanel
{
    public class HomeCustomizationPanelPresenter : BasePresenter<HomeCustomizationPanelView, HomeCustomizationPanelModel>
    {
        public Action OnApplyButton;
        public Action OnCancelButton;
        public Action<int> OnHairButton;
        public Action<int> OnHairColorButton;
        public Action<int> OnTopColorButton;
        public Action<int> OnBottomColorButton;
        public Action<int> OnShoesColorButton;
        
        private readonly List<GameObject> _items = new();

        public HomeCustomizationPanelPresenter(GameObject prefab, Transform parent) : base(prefab, parent)
        {
            
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
                var script = obj.GetComponent<HairItemButton>();
                script.Text.text = index.ToString();
                script.Button.onClick.AddListener(() => OnHairButton?.Invoke(index));

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
                script.Button.onClick.AddListener(() => OnHairColorButton?.Invoke(index));
                
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
                var script = obj.GetComponent<TopColorItemButton>();
                script.Image.color = Model.ClothesMaterials[index].color;
                script.Button.onClick.AddListener(() => OnTopColorButton?.Invoke(index));
                
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
                var script = obj.GetComponent<BottomColorItemButton>();
                script.Image.color = Model.ClothesMaterials[index].color;
                script.Button.onClick.AddListener(() => OnBottomColorButton?.Invoke(index));
                
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
                var script = obj.GetComponent<ShoesColorItemButton>();
                script.Image.color = Model.ClothesMaterials[index].color;
                script.Button.onClick.AddListener(() => OnShoesColorButton?.Invoke(index));
                
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