using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RhythmGameComboText : MonoBehaviour
{
    private TextMeshProUGUI text;

    private void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
        text.text = string.Empty;
    }

    private void Update()
    {
        if (ScoreManager.Instance.Combo == 0)
        {
            text.text = string.Empty;
        }
        else
        {
            text.text = ScoreManager.Instance.Combo.ToString() + "x";
        }
    }
}
