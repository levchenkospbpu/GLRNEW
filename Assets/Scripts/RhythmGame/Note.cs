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

        
        if (t > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            GetComponent<RectTransform>().offsetMin = new Vector2(0, Mathf.Lerp(Screen.height, 0, t));
            GetComponent<RectTransform>().offsetMax = new Vector2(0, -Mathf.Lerp(-Screen.height, 0, t));
            GetComponent<Image>().enabled = true;
        }
    }
}
