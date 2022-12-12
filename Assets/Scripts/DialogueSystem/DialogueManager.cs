using Ink.Parsed;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Story = Ink.Runtime.Story;
using Choice = Ink.Runtime.Choice;
using System;
using UI;
using VContainer;
using VContainer.Unity;

public class DialogueManager : MonoBehaviour
{
    #region Sigleton
    public static DialogueManager Instance { get; private set; }
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

    public event Action DialogueStarted;

    [Header("Dialogue UI")]
    private TextMeshProUGUI _dialogueText;
    private TextMeshProUGUI _npcNameText;

    [Header("Choices UI")]
    private GameObject[] _choices;
    private TextMeshProUGUI[] _choicesText;

    private Ink.Runtime.Story _currentStory;

    [Inject]
    //private UIProvider _uiProvider;

    public bool DialogueIsPlaying { get; private set; }

    private void Start()
    {
        DialogueIsPlaying = false;
    }

    private void Initialize()
    {
        _dialogueText = FindObjectOfType<DialogueText>().gameObject.GetComponent<TextMeshProUGUI>();
        _npcNameText = FindObjectOfType<DialogueNPCNameText>().gameObject.GetComponent<TextMeshProUGUI>();
        var choices = FindObjectsOfType<DialogueChoice>();
        _choices = new GameObject[choices.Length];
        for (int i = 0; i < _choices.Length; i++)
        {
            _choices[i] = choices[i].gameObject;
        }
        _choicesText = new TextMeshProUGUI[_choices.Length];
        for (int i = 0; i < _choices.Length; i++)
        {
            _choicesText[i] = _choices[i].GetComponentInChildren<TextMeshProUGUI>();
        }
        HideChoices();
    }

    private void Update()
    {
        if (!DialogueIsPlaying)
        {
            return;
        }
        else
        {
            if (Input.GetMouseButtonDown(0) && _currentStory.currentChoices.Count == 0)
            {
                ContinueStory();
            }
        }
    }

    public IEnumerator EnterDialogueMode(TextAsset inkJSON, string name)
    {
        //_uiProvider.Show(typeof(DialoguePanel), GameObject.FindGameObjectWithTag("MainCanvas").transform);
        Initialize();
        _currentStory = new Story(inkJSON.text);
        DialogueStarted?.Invoke();

        yield return new WaitForSeconds(0);

        _npcNameText.text = name;
        DialogueIsPlaying = true;
        ContinueStory();
    }

    private IEnumerator ExitDialogueMode()
    {
        yield return new WaitForSeconds(0.2f);

        DialogueIsPlaying = false;
        _dialogueText.text = string.Empty;
        _npcNameText.text = string.Empty;
        //_uiProvider.Show(typeof(LocationPanel), GameObject.FindGameObjectWithTag("MainCanvas").transform);
    }

    private void ContinueStory()
    {
        if (_currentStory.canContinue)
        {
            _dialogueText.text = _currentStory.Continue();
            HideChoices();
            DisplayChoices(); 
        }
        else
        {
            StartCoroutine(ExitDialogueMode());
        }
    }

    private void DisplayChoices()
    {
        List<Choice> currentChoices = _currentStory.currentChoices;
        if (currentChoices.Count > _choices.Length)
        {
            Debug.LogError("More choices were given than the UI can support. Number of choices given: " + currentChoices.Count);
        }
        int index = 0;
        foreach(Choice choice in currentChoices)
        {
            _choices[index].gameObject.SetActive(true);
            _choicesText[index].text = choice.text;
            index++;
        }
        for (int i = index; i < _choices.Length; i++)
        {
            _choices[index].gameObject.SetActive(false);
        }
    }

    public void HideChoices()
    {
        for (int i = 0; i < _choices.Length; i++)
        {
            _choices[i].SetActive(false);
            _choicesText[i].text = string.Empty;
        }
    }

    public void MakeChoice(int choiceIndex)
    {
        _currentStory.ChooseChoiceIndex(choiceIndex);
        ContinueStory();
    }
}
