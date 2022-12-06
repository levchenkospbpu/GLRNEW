using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RhythmGameResultText : MonoBehaviour
{
    private void Start()
    {
        if (ScoreManager.Instance.EnemyHP <= 0)
        {
            GetComponent<TextMeshProUGUI>().text = "Win";
        }
        else
        {
            GetComponent<TextMeshProUGUI>().text = "Lose";
        }
    }
}
