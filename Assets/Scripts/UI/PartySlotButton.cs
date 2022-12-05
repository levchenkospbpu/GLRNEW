using Audio;
using UnityEngine;
using UnityEngine.UI;

public class PartySlotButton : MonoBehaviour
{
    [SerializeField] private PartyPanel _partyPanel;
    [field: SerializeField] public CharacterSlotType CharacterSlotType { get; private set; }

    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(SetChangeableInfo);
        GetComponent<Button>().onClick.AddListener(ShowCharacterInfo);
        GetComponent<Button>().onClick.AddListener(LoadCharacterButtons);
        GetComponent<Button>().onClick.AddListener(HideOtherObjects);
        GetComponent<Button>().onClick.AddListener(StopSong);
    }

    public void Initialize()
    {
        switch (CharacterSlotType)
        {
            case CharacterSlotType.Bass:
                if (_partyPanel.Party.TempBassID != -1)
                {
                    GetComponent<Image>().sprite = _partyPanel.Party.CharactersData.Characters[_partyPanel.Party.TempBassID].Banner;
                }
                else
                {
                    GetComponent<Image>().sprite = null;
                }
                break;
            case CharacterSlotType.Drums:
                if (_partyPanel.Party.TempDrumsID != -1)
                {
                    GetComponent<Image>().sprite = _partyPanel.Party.CharactersData.Characters[_partyPanel.Party.TempDrumsID].Banner;
                }
                else
                {
                    GetComponent<Image>().sprite = null;
                }
                break;
            default:
                break;
        }
    }

    private void SetChangeableInfo()
    {
        _partyPanel.ActionCaller.Raise(ActionType.SetChangeableSlotType, new DataProvider(CharacterSlotType));
        _partyPanel.ActionCaller.Raise(ActionType.SetChangeableCharacterID, new DataProvider(CharacterSlotType));
    }

    private void ShowCharacterInfo()
    {
        _partyPanel.ShowCharacterInfo();
    }

    private void HideOtherObjects()
    {
        _partyPanel.HideObjects();
    }

    private void LoadCharacterButtons()
    {
        _partyPanel.LoadCharacterButtons();
    }

    private void StopSong()
    {
        AudioManager.Instance.Stop();
    }
}

public enum CharacterSlotType
{
    Bass,
    Drums,
    Guitar
}
