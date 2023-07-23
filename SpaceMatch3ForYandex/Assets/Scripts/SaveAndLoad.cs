using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveAndLoad : MonoBehaviour
{
    public static SaveAndLoad instance;


    private string fileName = "SaveData"; //file for save game data
    private string fileNamePref = "PrefData"; //file for save game data
    private string fileNameStoryWatched = "StoryWatchedData"; //file for save game data
    private string fileNamePurchase = "PurchaseData"; //file for save game data

    private void Awake()
    {
        instance = this;
        //get Saved achieved location and sub location
        if (File.Exists(Application.persistentDataPath + "/" + fileName + ".art"))
        {
            LoadSavedDataFromFile();
            //GameParams.achievedLevel = 7;
        }
        else
        {
            GameParams.achievedLevel = 0;
        }


        //load saved prefs 
        if (File.Exists(Application.persistentDataPath + "/" + fileNamePref + ".art"))
        {
            LoadPrefsFromFile();
        }
        else
        {
            GameParams.language = 1;
        }
        
        //load saved firstLoad 
        if (File.Exists(Application.persistentDataPath + "/" + fileNameStoryWatched + ".art"))
        {
            LoadStoryWatchedFromFile();
        }
        else
        {
            GameParams.storyWatched = false;
        }
        //load saved firstLoad 
        if (File.Exists(Application.persistentDataPath + "/" + fileNamePurchase + ".art"))
        {
            LoadPurchaseFromFile();
        }
    }

    //crypting method for saved data
    string Crypt(string text)
    {
        string result = string.Empty;
        foreach (char j in text)
        {
            // ((int) j ^ 29) - применение XOR к номеру символа
            // (char)((int) j ^ 29) - получаем символ из измененного номера
            // „исло, которым мы XORим можете поставить любое. Ёксперементируйте.
            result += (char)(j ^ 29);
        }
        return result;
    }

    //this method is used to read save data from special file with key value approach
    private string getSavedValue(string[] line, string pattern)
    {
        string result = "";
        foreach (string key in line)
        {
            if (key.Trim() != string.Empty)
            {
                string value = key;
                value = Crypt(key);

                if (pattern == value.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)[0])
                {
                    result = value.Remove(0, value.IndexOf(' ') + 1);
                }
            }
        }
        return result;
    }

    //saving preferences of player
    public void saveGameData()
    {
        StreamWriter sw = new StreamWriter(Application.persistentDataPath + "/" + fileName + ".art");
        string sp = " "; //space 

        sw.WriteLine(Crypt("achievedLevel" + sp + GameParams.achievedLevel));

        sw.Close();
    }

    public void savePlayerPrefs()
    {
        StreamWriter sw = new StreamWriter(Application.persistentDataPath + "/" + fileNamePref + ".art");
        string sp = " "; //space 

        sw.WriteLine(Crypt("language" + sp + GameParams.language));


        sw.Close();
    }

    public void saveStoryWatched()
    {
        StreamWriter sw = new StreamWriter(Application.persistentDataPath + "/" + fileNameStoryWatched + ".art");
        string sp = " "; //space 

        sw.WriteLine(Crypt("storyWatched" + sp + GameParams.storyWatched));


        sw.Close();
    }
    public void savePurchases()
    {
        StreamWriter sw = new StreamWriter(Application.persistentDataPath + "/" + fileNamePurchase + ".art");
        string sp = " "; //space 

        sw.WriteLine(Crypt("adsBought" + sp + GameParams.getAdsBought()));


        sw.Close();
    }

    private void LoadSavedDataFromFile()
    {
        string[] rows = File.ReadAllLines(Application.persistentDataPath + "/" + fileName + ".art");

        int achievedLevel;
        if (int.TryParse(getSavedValue(rows, "achievedLevel"), out achievedLevel)) GameParams.achievedLevel = achievedLevel;
    }

    //load player prefs on start from file
    private void LoadPrefsFromFile()
    {
        string[] rows = File.ReadAllLines(Application.persistentDataPath + "/" + fileNamePref + ".art");

        int language;
        if (int.TryParse(getSavedValue(rows, "language"), out language)) GameParams.language = language;
    }

    private void LoadStoryWatchedFromFile()
    {
        string[] rows = File.ReadAllLines(Application.persistentDataPath + "/" + fileNameStoryWatched + ".art");

        bool storyWatched;
        if (bool.TryParse(getSavedValue(rows, "storyWatched"), out storyWatched)) GameParams.storyWatched = storyWatched;
    }
    private void LoadPurchaseFromFile()
    {
        string[] rows = File.ReadAllLines(Application.persistentDataPath + "/" + fileNamePurchase + ".art");

        bool adsBought;
        if (bool.TryParse(getSavedValue(rows, "adsBought"), out adsBought)) GameParams.setAdsBought(adsBought);
    }

    private void OnApplicationQuit()
    {
        saveStoryWatched();
        saveGameData();
        savePlayerPrefs();
        savePurchases();
    }
}
