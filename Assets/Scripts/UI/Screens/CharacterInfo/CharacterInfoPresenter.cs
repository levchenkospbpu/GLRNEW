using System;
using System.Collections.Generic;
using Common.MVP;
using Data;
using UI.Canvas;
using UnityEngine;
using UnityEngine.UI;
using Object = UnityEngine.Object;

namespace UI.Screens.CharacterInfo
{
    public class CharacterInfoPresenter : BasePresenter<CharacterInfoView, CharacterInfoModel>
    {
        protected override GameObject Prefab { get; }
        protected override Transform Parent { get; }

        public Action<PartySlotType, int> OnChooseButton;
        private Action<int> OnCharacterButton;

        private readonly List<GameObject> _items = new();
        private int _chosenCharacter;

        public CharacterInfoPresenter(UiCanvasData uiCanvasData, UIProviderConfig uiProviderConfig) : base(uiCanvasData, uiProviderConfig)
        {
            Prefab = uiProviderConfig.CharacterInfoPanel;
            Parent = uiCanvasData.Screens;
        }

        protected override void OnEnable()
        {
            View.ChooseButton.onClick.AddListener(() => OnChooseButton?.Invoke(Model.ChangableSlot, _chosenCharacter));

            OnCharacterButton += SetChosenCharacter;

            LoadCharacterButtons();
        }

        private void LoadCharacterButtons()
        {
            ClearItems();

            for (int i = 0; i < Model.Characters.Length; i++)
            {
                var index = i;

                var obj = Object.Instantiate(View.CharacterItemPrefab, View.ScrollContent);
                obj.GetComponent<Image>().sprite = Model.Characters[i].Icon;
                obj.GetComponent<Button>().onClick.AddListener(() => OnCharacterButton?.Invoke(index));
                _items.Add(obj);
            }
        }
        private void SetChosenCharacter(int id)
        {
            _chosenCharacter = id;
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
            OnChooseButton = null;
            OnCharacterButton = null;
        }
    }
}
