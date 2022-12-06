using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DialogueChoice : MonoBehaviour
{
    [SerializeField] private int _id;

    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(MakeChoice);
        GetComponent<Button>().onClick.AddListener(UnselectSelf);
    }

    private void MakeChoice()
    {
        DialogueManager.Instance.MakeChoice(_id);
    }

    private void UnselectSelf()
    {
        EventSystem.current.GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(null);
    }
}
