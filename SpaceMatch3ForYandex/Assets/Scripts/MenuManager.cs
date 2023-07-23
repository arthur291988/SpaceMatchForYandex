using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [SerializeField]
    private SpriteAtlas charactersAtlas;
    [SerializeField]
    private Image _characterRenderer;

    [SerializeField]
    private TextMeshProUGUI characterText;

    [SerializeField]
    private TextMeshProUGUI levelWord;
    [SerializeField]
    private TextMeshProUGUI levelTitle;
    [SerializeField]
    private TextMeshProUGUI levelCount;

    [SerializeField]
    private TextMeshProUGUI StartWord;
    [SerializeField]
    private TextMeshProUGUI CharacterName;

    [SerializeField]
    private Button nextButton;
    [SerializeField]
    private Button prevButton;

    [SerializeField]
    private GameObject messageButton;
    [SerializeField]
    private GameObject startButton;
    [SerializeField]
    private GameObject discordButton;

    private bool assistantTextFinished;

    private bool alienIsTalking;
    private bool assistantIsTalking;

    [SerializeField]
    private Camera _camera;
    private float vertScreenSize;

    [SerializeField]
    private GameObject rateUsPanel;

    // Start is called before the first frame update
    void Start()
    {
        GameParams.currentLevel = GameParams.achievedLevel;

        vertScreenSize = _camera.orthographicSize * 2;
        //StartCoroutine(TypeText());

        levelWord.text = GameParams.getLevelWord();
        StartWord.text = GameParams.getStartWord();

        setLevelparameters();

        if (Random.Range(0,4)==3) showRateUsPanel();
    }

    private IEnumerator TypeAssistantText()
    {
        AudioManager.Instance.assistantVoiceFunc(true);
        characterText.text = "";

        assistantTextFinished = true;
        assistantIsTalking = true;
        foreach (char letter in GameParams.getAssistantTextList()[GameParams.currentLevel])
        {
            characterText.text += letter;
            yield return null;
        }
        stopAssistantTalking();


    }
    private IEnumerator TypeAlienText()
    {
        AudioManager.Instance.alienVoiceFunc(true);
        alienIsTalking = true;
        characterText.text = "";
        foreach (char letter in GameParams.getAlienTextList()[GameParams.currentLevel])
        {
            characterText.text += letter;
            yield return null;
        }
        stopAlienTalking();
    }

    private void stopAssistantTalking()
    { 
        //last level and last message from assistant TO DO FOR DEVELOP
        if (GameParams.achievedLevel == 7 && GameParams.achievedLevel == GameParams.currentLevel)
        {
            messageButton.SetActive(false);
            AudioManager.Instance.messageVoiceFunc(false);
            discordButton.SetActive(true);

            //AnalyticMain.instance.LogEvent("LastLevelAchieved");
        }
        else
        {
            messageButton.SetActive(true);
            AudioManager.Instance.messageVoiceFunc(true);
        }

        assistantIsTalking = false;
        AudioManager.Instance.assistantVoiceFunc(false);
    }

    private void stopAlienTalking()
    {
        alienIsTalking = false;
        AudioManager.Instance.alienVoiceFunc(false);
    }

    private void setLevelparameters()
    {
        CharacterName.text = GameParams.getCharacterName()[0];
        _characterRenderer.sprite = charactersAtlas.GetSprite("0");

        levelTitle.text = GameParams.getLevelName()[GameParams.currentLevel];
        levelCount.text = (GameParams.currentLevel+1).ToString();

        if (GameParams.currentLevel == GameParams.achievedLevel) nextButton.interactable = false;
        else if (!nextButton.interactable) nextButton.interactable = true;
        if (GameParams.currentLevel == 0) prevButton.interactable = false;
        else if (!prevButton.interactable) prevButton.interactable = true;

        AudioManager.Instance.alienVoiceFunc(false);
        AudioManager.Instance.assistantVoiceFunc(false);

        StopAllCoroutines();
        characterText.text = "";
        messageButton.SetActive(true);
        AudioManager.Instance.messageVoiceFunc(true);

        startButton.SetActive(false);
        discordButton.SetActive(false);
        assistantTextFinished = false;
        alienIsTalking = false;
        assistantIsTalking = false;
    }

    public void nextMessage() {
        if (assistantTextFinished)
        {
            messageButton.SetActive(false);
            startButton.SetActive(true);
            if (GameParams.currentLevel < 2)
            {
                CharacterName.text = GameParams.getCharacterName()[1];
                _characterRenderer.sprite = charactersAtlas.GetSprite("1");
            }
            else if (GameParams.currentLevel < 4)
            {
                CharacterName.text = GameParams.getCharacterName()[2];
                _characterRenderer.sprite = charactersAtlas.GetSprite("2");
            }
            else if (GameParams.currentLevel < 6)
            {
                CharacterName.text = GameParams.getCharacterName()[3];
                _characterRenderer.sprite = charactersAtlas.GetSprite("3");
            }
            else
            {
                CharacterName.text = GameParams.getCharacterName()[4];
                _characterRenderer.sprite = charactersAtlas.GetSprite("4");
            }

            StopAllCoroutines();
            AudioManager.Instance.assistantVoiceFunc(false);
            StartCoroutine(TypeAlienText());
        }
        else
        {
            messageButton.SetActive(false);
            StopAllCoroutines();
            AudioManager.Instance.assistantVoiceFunc(false);
            StartCoroutine(TypeAssistantText());
        }

        AudioManager.Instance.connectionVoice();
        AudioManager.Instance.messageVoiceFunc(false);
    } 

    public void switchTheLevel(bool next) {
        if (next)
        {
            if (GameParams.currentLevel < GameParams.achievedLevel)
            {
                GameParams.currentLevel++;
                setLevelparameters();
            }
        }
        else {
            if (GameParams.currentLevel >0)
            {
                GameParams.currentLevel--;
                setLevelparameters();
            }
        }
        AudioManager.Instance.connectionVoice();
    }

    

    public void GoToBattle() {

        AudioManager.Instance.connectionVoice();
        SceneSwitchManager.LoadBattleScene();

        
    }

    public void discordButtonPush()
    {
        Application.OpenURL("https://discord.gg/D9eDwR2W");

        AudioManager.Instance.connectionVoice();
    }

    public void rateUsButton()
    {
        Application.OpenURL("https://play.google.com/store/apps/details?id=com.ArtUR.SpaceMatch3");

        AudioManager.Instance.connectionVoice();
    }

    private void showRateUsPanel() {
        rateUsPanel.SetActive(true);
    }

    public void hideRateUsPanel()
    {
        rateUsPanel.SetActive(false);
        AudioManager.Instance.connectionVoice();
    }

    private void Update()
    {
        //touch process for Android platform
        if (assistantIsTalking || alienIsTalking)
        { 
            if (Input.touchCount == 1)
            {
                Touch _touch = Input.GetTouch(0);

                if (_touch.phase == TouchPhase.Began && _camera.ScreenToWorldPoint(new Vector3(_touch.position.x, _touch.position.y, 0)).y< vertScreenSize/2-2.5f)
                {
                    if (alienIsTalking)
                    {
                        StopAllCoroutines();
                        characterText.text = GameParams.getAlienTextList()[GameParams.currentLevel];
                        stopAlienTalking();
                    }
                    else if (assistantIsTalking)
                    {
                        StopAllCoroutines();
                        characterText.text = GameParams.getAssistantTextList()[GameParams.currentLevel];
                        stopAssistantTalking();

                    }
                    AudioManager.Instance.connectionVoice();
                }
            }
        }
        
    }

}
