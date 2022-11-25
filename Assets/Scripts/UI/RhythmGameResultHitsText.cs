using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RhythmGameResultHitsText : MonoBehaviour
{
    private void Start()
    {
        GetComponent<TextMeshProUGUI>().text = "Hits: " + ScoreManager.Instance.Hits.ToString();
    }
}
