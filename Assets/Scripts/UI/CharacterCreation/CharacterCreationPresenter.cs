using System;
using System.Collections.Generic;
using Common.MVP;
using UnityEngine;
using Object = UnityEngine.Object;

namespace UI.CharacterCreation
{
    public class CharacterCreationPresenter : BasePresenter<CharacterCreationView, CharacterCreationModel>
    {
        public Action OnApplyHandler;
        public Action<int> OnHairHandler;
        public Action<int> OnHairColorHandler;
        public Action<int> OnSkinColorHandler;
        
        private readonly List<GameObject> _items = new();

        public CharacterCreationPresenter(GameObject prefab, Transform parent) : base(prefab, parent)
        {
            
        }

        protected override void OnEnable()
        {
            View.ApplyButton.onClick.AddListener(() => OnApplyHandler?.Invoke());
            View.HairButton.onClick.AddListener(HairHandler);
            View.HairColorButton.onClick.AddListener(HairColorHandler);
            View.SkinColorButton.onClick.AddListener(SkinColorHandler);
            
            HairHandler();
        }

        private void HairHandler()
        {
            ClearItems();
            
            for (int i = 0; i < Model.Hairs.Length; i++)
            {
                var index = i;

                var obj = Object.Instantiate(View.HairItemButton, View.ScrollContent);
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

                var obj = Object.Instantiate(View.SkinColorItemButton, View.ScrollContent);
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

                var obj = Object.Instantiate(View.HairColorItemButton, View.ScrollContent);
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