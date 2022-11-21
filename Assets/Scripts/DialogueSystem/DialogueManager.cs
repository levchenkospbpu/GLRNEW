using Ink.Parsed;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Story = Ink.Runtime.Story;
using Choice = Ink.Runtime.Choice;
using System;

public class DialogueManager : MonoBehaviour
{
    public event Action DialogueStarted;

    [Header("Dialogue UI")]
    [SerializeField] private TextMeshProUGUI _dialogueText;
    [SerializeField] private TextMeshProUGUI _npcNameText;

    [Header("Choices UI")]
    private GameObject[] _choices;
    private TextMeshProUGUI[] _choicesText;

    private Ink.Runtime.Story _currentStory;

    public bool DialogueIsPlaying { get; private set; }

    private void Start()
    {
        DialogueIsPlaying = false;
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
        HideChoices();
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
