using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldSpaceCanvasTrigger : MonoBehaviour
{
    [SerializeField] private GameObject _canvas;
    private Animation _canvasAnimation;

    private void Start()
    {
        _canvasAnimation = _canvas.GetComponent<Animation>();
        DialogueManager.Instance.DialogueStarted += DialogueManager_OnDialogueStarted;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Player") return;
        _canvas.SetActive(true);
        var state = _canvasAnimation.PlayQueued("WorldSpaceCanvasOpen", QueueMode.PlayNow, PlayMode.StopSameLayer);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag != "Player") return;
        StartCoroutine(CloseCanvas());
    }

    private IEnumerator CloseCanvas()
    {
        var state = _canvasAnimation.PlayQueued("WorldSpaceCanvasClose", QueueMode.PlayNow, PlayMode.StopSameLayer);
        yield return new WaitForSeconds(state.length);
        _canvas.gameObject.SetActive(false);
    }

    private void DialogueManager_OnDialogueStarted()
    {
        StartCoroutine(CloseCanvas());
    }
}
