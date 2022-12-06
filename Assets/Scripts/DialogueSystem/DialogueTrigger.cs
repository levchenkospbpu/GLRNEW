using UnityEngine;
using UnityEngine.UI;

public class DialogueTrigger : MonoBehaviour
{
    [Header("Ink JSON")]
    [SerializeField] private TextAsset _inkJSON;
    [SerializeField] private string _name;

    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(OnClick);
    }

    private void OpenDialogue()
    {
        StartCoroutine(DialogueManager.Instance.EnterDialogueMode(_inkJSON, _name));
    }

    private void OnClick()
    {
        if (DialogueManager.Instance.DialogueIsPlaying) return;
        OpenDialogue();
    }
}
