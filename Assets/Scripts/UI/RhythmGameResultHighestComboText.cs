using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RhythmGameResultHighestComboText : MonoBehaviour
{
    private void Start()
    {
        GetComponent<TextMeshProUGUI>().text = "Highest combo: " + ScoreManager.Instance.HighestCombo.ToString();
    }
}
