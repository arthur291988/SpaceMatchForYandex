using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Advertisements;
using System.Runtime.InteropServices;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;


    [HideInInspector]
    public GameObject ObjectPulled;
    [HideInInspector]
    public List<GameObject> ObjectPulledList;

    private const float xStep = 2.2f;
    private const int maxShipsOnOneLine = 5;


    private bool fightIsOn;
    private bool movesFrozen;
    [SerializeField]
    private GameObject coverBoard;

    [NonSerialized]
    public List<Shot> shotsOnScene;

    private const float firstRowYValueEnemyFleet = 11;
    private const float secondRowYValueEnemyFleet = 8.45f;
    private const float firstRowYValuePlayerFleet = 0;
    private const float secondRowYValuePlayerFleet = 2.55f;
    private const float destroyerXGap = 0.5f;
    //private const float destroyerYGap = 0.35f;

    //[NonSerialized]
    //public float turnTimeUp;
    //[NonSerialized]
    //public float turnTimeDown;
    //[NonSerialized]
    //public float turnTimeMax;

    //private bool timerIsOn;

    //public GameObject timerObj;
    //public Image UpTimerImg;
    //public Image DownTimerImg;

    [SerializeField]
    private GameObject alarmPanel;
    [SerializeField]
    private GameObject defeatButton;
    [SerializeField]
    private GameObject victoryButton;
    [SerializeField]
    private TextMeshProUGUI victoryButtonText;
    [SerializeField]
    private TextMeshProUGUI defeatButtonText;

    [NonSerialized]
    public bool noShieldsMode;
    [SerializeField]
    private TextMeshProUGUI shieldOffTxt;
    [SerializeField]
    private GameObject shieldOffGO;

    [SerializeField]
    private GameObject noInternetPanel;
    //private bool adsTimerIsOn;
    private bool adsReadyToShow;

    private const float adsTimer = 80;


    private void Awake()
    {
        instance = this;
        noShieldsMode = false;
    }


    // Start is called before the first frame update
    void Start()
    {
        shotsOnScene = new List<Shot>();
        CommonData.Instance.setGameLevelAndHardness(GameParams.currentLevel);
        instantiateEnemyFleet();
        instantiatePlayerFleet();
        PlayerFleetManager.instance.startSettings();
        EnemyFleetManager.instance.startSettings();
        fightIsOn = false;
        movesFrozen = false;

        BackgroundManager.Instance.setBackground();
        BackgroundManager.Instance.pullAsteroidsOnStart();
        victoryButtonText.text = GameParams.getVictoryWord();
        defeatButtonText.text = GameParams.getDefeatWord();
        //turnTimeMax = 7;

        //turnTimeUp = 7;
        //turnTimeDown = 0;
        //setTheTimer();
        GameParams.ResetAdsTimer();
        //checkTheInternet();
        GameParams.gameWin = false;
    }


    [DllImport("__Internal")]
    private static extern void ShowAds();


    //this is called from yandex plugin my.jslib after interstitial ad was shown
    public void afterAdsShown()
    {
        if (!GameParams.getAdsBought())
        {
            if (UnityEngine.Random.Range(0, 4) == 3) ShopWhileBattle.instance.showLimitedOffer();
        }
    }


    //DESCTOP FUNCTION
    public float getScreenVerticalBorders() {
        float Xborder = 0;
        Xborder = xStep * (maxShipsOnOneLine/2 + 1);
        return Xborder;
    }

    //private void OnApplicationFocus(bool focus)
    //{
    //    //checkTheInternet();
    //    GameParams.SetAdsTimer(60);

    //    //if (!Advertisement.isInitialized)
    //    //{
    //    //    AdsInitializer.Instance.InitializeAds();
    //    //    GameParams.SetAdsTimer(60);
    //    //}
    //}

    //public void checkTheInternet() {
    //    StartCoroutine(checkInternetConnection((isConnected) => {
    //        if (isConnected)
    //        {
    //            if (noInternetPanel.activeInHierarchy) noInternetPanel.SetActive(false);
    //            //if (!GameParams.getAdsBought())setAdsTimer(true);
    //        }
    //        else
    //        {
    //            noInternetPanel.SetActive(true);
    //            //setAdsTimer(false);
    //        }
    //    }));
    //}

    //IEnumerator checkInternetConnection(Action<bool> action)
    //{
    //    WWW www = new WWW("http://google.com");
    //    yield return www;
    //    if (www.error != null)
    //    {
    //        action(false);
    //    }
    //    else
    //    {
    //        action(true);
    //    }

    //}

    //public void setAdsTimer(bool on) => adsTimerIsOn= on;



    //private void setTheTimer() {
    //    turnTimeUp = turnTimeMax;
    //    UpTimerImg.fillAmount = turnTimeUp;
    //    turnTimeDown = 0;
    //    DownTimerImg.fillAmount = turnTimeDown;
    //    if (!timerObj.activeInHierarchy) timerObj.SetActive(true);
    //    timerIsOn = true;
    //}

    //private void updateTimerUI ()
    //{
    //    UpTimerImg.fillAmount = turnTimeUp/ turnTimeMax;
    //    DownTimerImg.fillAmount = turnTimeDown / turnTimeMax;
    //}

    //public void stopTheTimer()
    //{
    //    timerIsOn = false;
    //    timerObj.SetActive(false);
    //    Invoke("startTimerIfNoAttack", 1);
    //}

    //private void startTimerIfNoAttack()
    //{
    //    if (!fightIsOn && !GridManager.Instance.tilesAreMoving) setTheTimer();
    //}



    //iterate through types of ships on first cycle and their counts on second level of cycle
    //forst level of cycle iterates downwards because stronger ships put on scene first 
    private void instantiateEnemyFleet()
    {
        int totalShipsCount = 0;
        float xStepLocal = 0;
        float yStepLocal = firstRowYValueEnemyFleet;
        GameObject shipObject;
        GameObject shipObject2;
        for (int i = CommonData.Instance.getEnemyFleetByLevel(CommonData.Instance.getGameLevel()).Count - 1; i >= 0; i--)
        {
            for (int j = 0; j < CommonData.Instance.getEnemyFleetByLevel(CommonData.Instance.getGameLevel())[i]; j++)
            {
                shipObject = pullEnemyShip(i);

                if (totalShipsCount == 0) shipObject.transform.position = new Vector2(xStepLocal, yStepLocal);
                //switch to second row of fleet
                else if (totalShipsCount == maxShipsOnOneLine)
                {
                    yStepLocal = secondRowYValueEnemyFleet;
                    xStepLocal = 0;
                    shipObject.transform.position = new Vector2(xStepLocal, yStepLocal);
                }
                if (yStepLocal != secondRowYValueEnemyFleet)
                {
                    if (totalShipsCount % 2 == 0)
                    {
                        shipObject.transform.position = new Vector2(-xStepLocal, yStepLocal);
                    }
                    else
                    {
                        xStepLocal += xStep;
                        shipObject.transform.position = new Vector2(xStepLocal, yStepLocal);
                    }
                }
                else
                {
                    if (totalShipsCount % 2 == 0)
                    {
                        xStepLocal += xStep;
                        shipObject.transform.position = new Vector2(xStepLocal, yStepLocal);
                    }
                    else
                    {
                        shipObject.transform.position = new Vector2(-xStepLocal, yStepLocal);
                    }
                }
                Ship ship = shipObject.GetComponent<Ship>();
                shipObject.SetActive(true);
                if (i != 0)
                {
                    ship.StartSettings(); //if ship is destroyer then its position is defined later while adding second destroyer
                    ship.activatePowerShiledOnStart();
                }

                //if ship is detroyer there necessery to put extra one in one placement
                if (i == 0)
                {
                    shipObject2 = pullEnemyShip(i);
                    float basePointX = shipObject.transform.position.x;
                    shipObject.transform.position = new Vector2(basePointX + destroyerXGap, yStepLocal);
                    shipObject2.transform.position = new Vector2(basePointX - destroyerXGap, yStepLocal);

                    Ship ship2 = shipObject2.GetComponent<Ship>();
                    shipObject2.SetActive(true);
                    ship.StartSettings(); //if ship is destroyer then its position is defined here
                    ship.activatePowerShiledOnStart();
                    ship2.StartSettings();
                    ship2.activatePowerShiledOnStart();
                }


                

                totalShipsCount++;
            }
        }
    }
    private void instantiatePlayerFleet()
    {
        int totalShipsCount = 0;
        float xStepLocal = 0;
        float yStepLocal = firstRowYValuePlayerFleet;
        GameObject shipObject;
        GameObject shipObject2;
        for (int i = CommonData.Instance.getPlayerFleetByLevel(CommonData.Instance.getGameLevel()).Count - 1; i >= 0; i--)
        {
            for (int j = 0; j < CommonData.Instance.getPlayerFleetByLevel(CommonData.Instance.getGameLevel())[i]; j++)
            {

                shipObject = pullPlayerShip(i);

                if (totalShipsCount == 0) shipObject.transform.position = new Vector2(xStepLocal, yStepLocal);
                //switch to second row of fleet
                else if (totalShipsCount ==5)
                {
                    yStepLocal = secondRowYValuePlayerFleet;
                    xStepLocal = 0;
                    shipObject.transform.position = new Vector2(xStepLocal, yStepLocal);
                }
                if (yStepLocal != secondRowYValuePlayerFleet)
                {
                    if (totalShipsCount % 2 == 0)
                    {
                        shipObject.transform.position = new Vector2(-xStepLocal, yStepLocal);
                    }
                    else
                    {
                        xStepLocal += xStep;
                        shipObject.transform.position = new Vector2(xStepLocal, yStepLocal);
                    }
                }
                else {
                    if (totalShipsCount % 2 == 0)
                    {
                        xStepLocal += xStep;
                        shipObject.transform.position = new Vector2(xStepLocal, yStepLocal);
                    }
                    else
                    {
                        shipObject.transform.position = new Vector2(-xStepLocal, yStepLocal);
                    }
                }

                Ship ship = shipObject.GetComponent<Ship>();
                shipObject.SetActive(true);
                if (i != 0)
                {
                    ship.StartSettings(); //if ship is destroyer then its position is defined later while adding second destroyer
                    ship.activatePowerShiledOnStart(); //power shield activated later with second one
                }

                //if ship is detroyer there necessery to put extra one in one placement
                if (i == 0)
                {
                    shipObject2 = pullPlayerShip(i);
                    float basePointX = shipObject.transform.position.x;
                    shipObject.transform.position = new Vector2(basePointX + destroyerXGap, yStepLocal);
                    shipObject2.transform.position = new Vector2(basePointX - destroyerXGap, yStepLocal);

                    Ship ship2 = shipObject2.GetComponent<Ship>();
                    shipObject2.SetActive(true);
                    ship.StartSettings(); //if ship is destroyer then its position is defined here
                    ship.activatePowerShiledOnStart();
                    ship2.StartSettings();
                    ship2.activatePowerShiledOnStart();
                }

                totalShipsCount++;
            }
        }
    }

    private GameObject pullEnemyShip(int index) {
        ObjectPulledList = ObjectPuller.current.GetEnemyShipPullList(index);
        ObjectPulled = ObjectPuller.current.GetGameObjectFromPull(ObjectPulledList);
        ObjectPulled.transform.rotation = Quaternion.Euler(0, 0, 180);
        return ObjectPulled;
    }
    private GameObject pullPlayerShip(int index)
    {
        ObjectPulledList = ObjectPuller.current.GetPlayerShipPullList(index);
        ObjectPulled = ObjectPuller.current.GetGameObjectFromPull(ObjectPulledList);
        
        return ObjectPulled;
    }

    public bool getFightIsOn() {
        return fightIsOn;
    }
    public bool getMovesFrozen()
    {
        return movesFrozen;
    }

    //sets fight on and determine if game is over
    public void setFightOn(bool state)
    {
        fightIsOn = state;
        if (!state)
        {
            //chek if game finished
            if (EnemyFleetManager.instance.enemyFleet.Count != 0 && PlayerFleetManager.instance.playerFleet.Count != 0)
            {
                coverBoard.SetActive(state);
                if (!noShieldsMode && (EnemyFleetManager.instance.enemyFleet.Count <= 4 || PlayerFleetManager.instance.playerFleet.Count <= 4))
                {
                    noShieldsMode = true;
                    shieldOffTxt.text = GameParams.getShieldOffWord();
                    shieldOffGO.SetActive(true);
                    AudioManager.Instance.alarmSoundPlay(true);
                    StartCoroutine(shieldsOffMessageTurnOff());

                    //AnalyticMain.instance.LogEvent("ShieldsOffMessage");
                }
                else if (adsReadyToShow)
                {
                    if (!GameParams.getAdsBought())
                    {
                        ShowAds();
                        adsReadyToShow = false;
                    }
                }

            }
            else
            {
                if (!coverBoard.activeInHierarchy) coverBoard.SetActive(true);
                if (EnemyFleetManager.instance.enemyFleet.Count == 0)
                {
                    endGameProcess(true); //victory
                }
                else endGameProcess(false); //defeat
            }
        }
        else
        {
            coverBoard.SetActive(state);
        }
        //if (!fightIsOn) setTheTimer();
    }


    private void endGameProcess(bool victory) {
        if (victory)
        {
            victoryButton.SetActive(true);
            if (GameParams.currentLevel == GameParams.achievedLevel)
            {
                GameParams.achievedLevel++;
                SaveAndLoad.instance.playerData.achievedLevel = GameParams.achievedLevel;
            }
            SaveAndLoad.instance.saveData();
            GameParams.gameWin = true;
        }
        else
        {
            alarmPanel.SetActive(true);
            defeatButton.SetActive(true);
        }


        AudioManager.Instance.endGameSoundPlay(victory);
    }

    private IEnumerator shieldsOffMessageTurnOff() {
        yield return new WaitForSeconds(2.5f);
        shieldOffGO.SetActive(false);
        AudioManager.Instance.alarmSoundPlay(false);
    }


    public void addShot(Shot shot)
    {
        shotsOnScene.Add(shot);
        if (!fightIsOn) setFightOn(true);
    }
    public void removeShot(Shot shot)
    {
        shotsOnScene.Remove(shot);
        if (shotsOnScene.Count < 1 && checkAllShipsIfActionIsFinished())
            setFightOn(false);
    }

    public bool checkAllShipsIfActionIsFinished()
    {
        bool isFinished = true;
        foreach (Ship ship in PlayerFleetManager.instance.playerFleet)
        {
            if (ship.actionsAreOn)
            {
                isFinished = false;
                break;
            }
        }
        if (isFinished)
        {
            foreach (Ship ship in EnemyFleetManager.instance.enemyFleet)
            {
                if (ship.actionsAreOn)
                {
                    isFinished = false;
                    break;
                }
            }
        }

        return isFinished;
    }


    public void goToMenu()
    {
        SceneSwitchManager.LoadMenuScene();
    }


    // Update is called once per frame
    //void Update()
    //{
    //    if (!fightIsOn && timerIsOn) {
    //        turnTimeUp-=0.02f;
    //        turnTimeDown += 0.02f;
    //        updateTimerUI();
    //        if (turnTimeUp <= 0) {
    //            stopTheTimer();
    //            GridManager.Instance.CPUAttackProcess();
    //        } 
    //    }
    //}


    private void Update()
    {
        if (!GameParams.getAdsBought())
        {
            GameParams.AdsTimer(Time.deltaTime);
            if (GameParams.getAdsTimer() >= adsTimer)
            {
                GameParams.ResetAdsTimer();
                adsReadyToShow = true;
            }
            //Debug.Log(GameParams.getAdsTimer());
        }
    }
}
