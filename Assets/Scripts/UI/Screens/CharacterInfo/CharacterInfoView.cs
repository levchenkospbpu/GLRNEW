using Common.MVP;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterInfoView : BaseView
{
    [field: Header("Buttons")]
    [field: SerializeField] public Button ChooseButton { private set; get; }
}
