using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Melanchall.DryWetMidi.Core;
using Melanchall.DryWetMidi.Interaction;
using System.IO;
using UnityEngine.Networking;
using System;

public class SongManager : MonoBehaviour
{
    public static SongManager Instance;
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

    [field: SerializeField] public AudioSource AudioSource { get; private set; }
    public MidiFile MidiFile { get; private set; }
    [field: SerializeField] public float NoteTime { get; private set; }

    [field: SerializeField] public Lane[] LaneStarts { get; private set; }
    [field: SerializeField] public float SongDelayInSeconds { get; private set; }
    [field: SerializeField] public double MarginOfError { get; private set; }
    [field: SerializeField] public int InputDelayInMilliseconds { get; private set; }

    private string fileLocation;

    void Start()
    {
        Initialize();
    }

    private void Initialize()
    {
        AudioSource = FindObjectOfType<AudioSource>();
        if (Application.streamingAssetsPath.StartsWith("http://") || Application.streamingAssetsPath.StartsWith("https://"))
        {
            StartCoroutine(ReadFromWebsite());
        }
        else
        {
            ReadFromFile();
        }
    }

    private IEnumerator ReadFromWebsite()
    {
        using (UnityWebRequest www = UnityWebRequest.Get(Application.streamingAssetsPath + "/" + fileLocation))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.LogError(www.error);
            }
            else
            {
                byte[] results = www.downloadHandler.data;
                using (var stream = new MemoryStream(results))
                {
                    MidiFile = MidiFile.Read(stream);
                    GetDataFromMidi();
                }
            }
        }
    }

    private void ReadFromFile()
    {
        MidiFile = MidiFile.Read(Application.streamingAssetsPath + "/" + AudioSource.clip.name + ".mid");
        GetDataFromMidi();
    }

    public void GetDataFromMidi()
    {
        var notes = MidiFile.GetNotes();
        var array = new Melanchall.DryWetMidi.Interaction.Note[notes.Count];
        notes.CopyTo(array, 0);

        foreach (var lane in LaneStarts) lane.SetTimeStamps(array);

        Invoke(nameof(StartSong), SongDelayInSeconds);
    }

    public void StartSong()
    {
        AudioSource.Play();
    }

    public double GetAudioSourceTime()
    {
        return (double)AudioSource.timeSamples / AudioSource.clip.frequency;
    }

    public void Stop()
    {
        foreach (Lane lane in LaneStarts)
        {
            Destroy(lane.gameObject);
        }
    }
}
