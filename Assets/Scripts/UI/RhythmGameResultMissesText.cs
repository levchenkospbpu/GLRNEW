using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RhythmGameResultMissesText : MonoBehaviour
{
    private void Start()
    {
        GetComponent<TextMeshProUGUI>().text = "Misses: " + ScoreManager.Instance.Misses.ToString();
    }
}
