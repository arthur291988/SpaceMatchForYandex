using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.U2D;

public class StoryManager : MonoBehaviour
{
    [SerializeField]
    private AudioSource backgroundMusic;
    [SerializeField]
    private SpriteAtlas pictureAtlas;
    [SerializeField]
    private SpriteRenderer pictureRenderer;
    [SerializeField]
    private TextMeshProUGUI storyText;
    private int atlassPictureNumber;
    private bool storyTextFinished;
    [SerializeField]
    private GameObject startButton;
    [SerializeField]
    private TextMeshProUGUI startButtonText;

    // Start is called before the first frame update
    void Start()
    {
        if (GameParams.storyWatched) {
            SceneSwitchManager.LoadMenuScene();
        }
        else setStartOfStory();

        startButtonText.text = GameParams.getStartWord();
    }

    private void setStartOfStory()
    {
        //AnalyticMain.instance.LogEvent("Story_Started");
        atlassPictureNumber = 0;
        pictureRenderer.sprite = pictureAtlas.GetSprite(atlassPictureNumber.ToString());
        backgroundMusic.Play();
        storyText.text = "";
        StartCoroutine(TypeStoryText(1));
    }

    private void nextPicture()
    {
        if (atlassPictureNumber < 6)
        {
            atlassPictureNumber++;
            pictureRenderer.sprite = pictureAtlas.GetSprite(atlassPictureNumber.ToString());
            StopAllCoroutines();
            storyText.text = "";
            StartCoroutine(TypeStoryText(0));
        }
    }

    private IEnumerator TypeStoryText(float seconds)
    {
        storyText.text = "";
        yield return new WaitForSeconds(seconds);
        AudioManager.Instance.assistantVoiceFunc(true);
        storyTextFinished = false;
        foreach (char letter in GameParams.getStoryTextList()[atlassPictureNumber])
        {
            storyText.text += letter;
            yield return null;
        }
        storyTextFinished = true;
        AudioManager.Instance.assistantVoiceFunc(false);
        if (atlassPictureNumber == 6) startButton.SetActive(true);

    }

    private void fillTheText()
    {
        StopAllCoroutines();
        storyText.text = GameParams.getStoryTextList()[atlassPictureNumber];
        storyTextFinished = true;
        AudioManager.Instance.assistantVoiceFunc(false);
        if (atlassPictureNumber == 6) startButton.SetActive(true);
    }

    public void goToMenu() {
        GameParams.storyWatched = true;
        SaveAndLoad.instance.playerData.storyWatched = true;
        SaveAndLoad.instance.saveData();
        AudioManager.Instance.connectionVoice();
        SceneSwitchManager.LoadMenuScene();
        //AnalyticMain.instance.LogEvent("Story_Finished");
    }


    private void Update()
    {
        //touch process for Android platform
        if (storyTextFinished)
        {

            //DESCTOP PLATFORM
            if (Input.GetMouseButtonDown(0))
            {
                nextPicture();
            }




            //MOBILE PLATFORM
            //if (Input.touchCount == 1)
            //{
            //    Touch _touch = Input.GetTouch(0);
            //    if (_touch.phase == TouchPhase.Began)
            //    {
            //        nextPicture();
            //    }
            //}
        }
        else
        {

            //DESCTOP PLATFORM
            if (Input.GetMouseButtonDown(0))
            {
                fillTheText();
            }


            //MOBILE PLATFORM
            //if (Input.touchCount == 1)
            //{
            //    Touch _touch = Input.GetTouch(0);
            //    if (_touch.phase == TouchPhase.Began)
            //    {
            //        fillTheText();
            //    }
            //}
        }
    }
}
