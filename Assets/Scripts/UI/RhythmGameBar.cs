using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RhythmGameBar : MonoBehaviour
{
    private Image _image;

    private void Start()
    {
        _image = GetComponent<Image>();
    }

    private void Update()
    {
        float filledPart = ScoreManager.Instance.PlayerHP;
        float maxValue = ScoreManager.Instance.EnemyHP + ScoreManager.Instance.PlayerHP;
        _image.fillAmount = filledPart / maxValue;
    }
}
