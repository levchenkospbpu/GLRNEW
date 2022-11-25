using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Note : MonoBehaviour
{
    double timeInstantiated;
    public float assignedTime;
    void Start()
    {
        timeInstantiated = SongManager.Instance.GetAudioSourceTime();
    }

    // Update is called once per frame
    void Update()
    {
        double timeSinceInstantiated = SongManager.Instance.GetAudioSourceTime() - timeInstantiated;
        float t = (float)(timeSinceInstantiated / (SongManager.Instance.NoteTime));


        GetComponent<RectTransform>().offsetMin = new Vector2(0, Screen.height * (1 - t));
        GetComponent<RectTransform>().offsetMax = new Vector2(0, Screen.height * (1 - t));
    }
}
