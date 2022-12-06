using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UI;
using UnityEngine;
using VContainer;

public class ScoreManager : MonoBehaviour
{
    #region Singleton
    public static ScoreManager Instance { get; private set; }
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    #endregion

    [Inject]
    private Party _party;
    [Inject]
    private UIProvider _uiProvider;

    [SerializeField] private int _enemyDamage;
    private int _playerDamage;
    [field: SerializeField] public int StartEnemyHP { get; private set; }
    public int StartPlayerHP { get; private set; }

    public int EnemyHP { get; private set; }
    public int PlayerHP { get; private set; }

    public int Misses { get; private set; }
    public int Hits { get; private set; }
    public int HighestCombo { get; private set; }
    public int Combo { get; private set; }

    private void Start()
    {
        Initialize();
    }

    private void Initialize()
    {
        if (_party.CurrentBassID != -1)
        {
            StartPlayerHP += _party.CharactersData.Characters[_party.CurrentBassID].HP;
            _playerDamage += _party.CharactersData.Characters[_party.CurrentBassID].Atk;
        }
        if (_party.CurrentDrumsID != -1)
        {
            StartPlayerHP += _party.CharactersData.Characters[_party.CurrentDrumsID].HP;
            _playerDamage += _party.CharactersData.Characters[_party.CurrentDrumsID].Atk;
        }
        EnemyHP = StartEnemyHP;
        PlayerHP = StartPlayerHP;
    }

    public void Hit()
    {
        EnemyHP -= _playerDamage + Combo / 10;
        Hits++;
        Combo++;
        if (Combo > HighestCombo)
        {
            HighestCombo = Combo;
        }
        if (EnemyHP <= 0)
        {
            AudioManager.Instance.Stop();
            SongManager.Instance.Stop();
            _uiProvider.Instantiate(typeof(RhythmGameResultPanel), GameObject.FindGameObjectWithTag("MainCanvas").transform);
        }
    }

    public void Miss()
    {
        PlayerHP -= _enemyDamage;
        Misses++;
        Combo = 0;
        if (PlayerHP <= 0)
        {
            AudioManager.Instance.Stop();
            SongManager.Instance.Stop();
            _uiProvider.Instantiate(typeof(RhythmGameResultPanel), GameObject.FindGameObjectWithTag("MainCanvas").transform);
        }
    }
}
