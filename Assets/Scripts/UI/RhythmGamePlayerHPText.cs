using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RhythmGamePlayerHPText : MonoBehaviour
{
    private TextMeshProUGUI text;

    private void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        text.text = ScoreManager.Instance.PlayerHP.ToString();
    }
}
