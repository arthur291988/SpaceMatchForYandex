using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameParams 
{
    public static int achievedLevel;
    public static int currentLevel;
    //0-eng, 1-Rus
    public static int language;

    public static bool storyWatched;


    private static string levelWord;
    private static string startWord;

    private static string endGameWord;
    private static string loadingWord;
    private static string shieldsOffWord;

    private static float adsTimer;
    private static bool adsOff;


    public static List<string> storyTextEng = new List<string> {
        "After union of all people in the world, we started to live in harmony and made a giant leap forward",

        "Solar Federation raised from human civilization of Earth. It became single state for everyone",

        "After, we made steps on exploration of the Solar System",

        "In the beginning, it was humble projects on near planets",

        "But, very soon we built up huge colonies on each planet of system",

        "Now humanity is ready to start its journey to the stars",

        "Conquering new worlds and going through all the dangers on its way"
    };

    public static List<string> storyTextRus = new List<string> {
        "����� ����������� ���� ����� � ���� �� ������ ���� � �������� � ��������� ���������� ������ ������",

        "��������� ��������� �������� �� ������������ ����������� �����. ��� ����� ������ ������������ ��� ����",

        "����� �� ����������� ���� �� ������������ ��������� �������",

        "������� ��� ���� �������� ������� �� ������� ��������",

        "�� ����� ����� �� ��������� �������� ������� �� ������ ������� �������",

        "������ ������������ ������ ������ ���� ����������� � �������",

        "������� ����� ���� � ����������� ��� ��������� �� ����� ����"
    };


    //index is level
    public static List<string> alienTextEng = new List<string> {
        "--Kneel before the troops of Emperor Ceres\r\n--I am Lord Filsh and you will be destroyed by my vanguard\r\n--Say goodbye to life",
        "--You were able to defeat a squad of weaklings\r\n--I will take revenge on you by destroying this planet\r\n--You will all burn",
        "--Well well, you destroyed the worthless Filsh\r\n--I'm Lord Zerf and you can't compete with me\r\n--Marauders crush these ants and plunder this planet",
        "--Coming to my station you signed your own death sentence\r\n--Prepare for it now\r\n--And then I will destroy this planet",
        "--I can't believe Filsh and my brother Zerf are destroyed\r\n--I have sent my elite squad to destroy your red planet and I will go to your main planet myself\r\n--Now you are definitely finished, Emperor Ceres will be pleased",
        "--Are you here?! So my elite squad was destroyed\r\n--In the name of the emperor, I will grind you all into stardust\r\n--May the strongest win",
        "--Nothingness!\r\n--How dare you stand against my troops\r\n--From the very beginning, our goal was your star, I plan to drain all its energy\r\n--And you will die like insects\r\n--Death to you!"

    }; 
    public static List<string> alienTextRus = new List<string> {
        "--�� ������ ����� �������� ���������� ������\r\n--� ������� ���� � �� ������ ���������� ���� ��������� �������\r\n--���������� � ������",
        "--�� ������ ������� ����� ��������\r\n--� ������ ��� ��������� ��� ������� \r\n--�� ��� �������",
        "--���� ��, �� ������ �������� ���������� �����\r\n--� ������� ���� � �� ���� ��� �� ��������\r\n--�������� ��������� ���� �������� � ���������� ��� �������",
        "--����� � ���� ������� �� ��������� ���� �������� ��������\r\n--���������� ��������� ���� ��������\r\n--� �����, � �������� ��� �������",
        "--�� ���� �������� ��� ���� � ��� ���� ���� ����������\r\n--� �������� �� ����������� ����� ������� ������� ���� ������� ����� � ��� ���������� �� ���� �������� �������\r\n--������ ��� ����� �����, ��������� ����� ����� �������",
        "--�� �����?! ����� ����, ��� ������� ����� ���������\r\n--�� ��� ���������� � ��� ���� ����� � �������� ����\r\n--����� ������� ����������",
        "--�����������!\r\n--��� �� ������� ������������� ���� �������\r\n--� ������ ������ ����� ����� ���� ���� ������, � �������� �������� ��� �� ������� \r\n--� �� ��������� ��� ���������\r\n--������ ���!"

    };

    //index is level
    public static List<string> assistantTextEng = new List<string> {
        "--Greetings Captain of the Solar Federation\r\n--We have received a disturbing message from the borders of the Federation, we were attacked by hostile aliens\r\n--You must fly to the boundary sectors and fight off the first wave of attack\r\n--Good luck Captain",

        "--Excellent Captain\r\n--We fought off the first wave of attack\r\n--Now the enemy is concentrating his forces at Neptune, where our frontier colonies\r\n--Turn on zero surge and intercept their forces",

        "--You are the true defender of humanity\r\n--There are reports of plundered hydrogen production platforms on Saturn\r\n--We need to protect our resources\r\n--Start your engines, we go there immediately",

        "--Saturn is protected, it's time to destroy Zerf\r\n--He is at his station next to Jupiter\r\n--Looks like they're going to blow up the core of the planet\r\n--Urgently teleport there and prevent a catastrophe for our fellow citizens",

        "--Great, we destroyed Zerf\r\n--However, we received a message that the enemy has gathered a large force near Mars\r\n--This is our second largest colony\r\n--You have been assigned a strong fleet, use it wisely",

        "--The enemy tried to divide us by attacking Mars\r\n--Zerbo sent the main forces to our main planet, Earth\r\n--The armada is already close to striking distance\r\n--Attack them now",

        "--Oh my God Captain... we've found a huge enemy fleet near the Sun\r\n--I have never seen so many flagships\r\n--It looks like the enemy's main fleet, we can put an end to this invasion\r\n--Destroy your enemies once and for all",

        "--Congratulations Captain, we repelled the alien invasion\r\n--We have proven that the Federation is ready to develop beyond the boundaries of the Solar System\r\n--Very soon new tasks will be set before you\r\n--We invite you to step into the headquarters of the command"
    };

    //index is level
    public static List<string> assistantTextRus = new List<string> {
       "--����������� ��� ������� ��������� ���������\r\n--�������� ��������� ��������� � ������ ����� ���������, �� ��� ������ ���������� ���������. \r\n--�� ������ ������������ �� ��������� ������� � ������ ������ ����� ����� \r\n--����� ��� �������",
       "--������� �������\r\n--�� ������ ������ ����� �����\r\n--������ ���� ������������� ���� ���� � ������� ��� ���� ������������ �������\r\n--��������� ������� ������� � ����������� �� ����",
       "--�� ��������� �������� ������������\r\n--��������� ��������� � ������������� ���������� ���������� ���������� �� �������\r\n--��� ���������� �������� ���� ������� \r\n--���������� ��������� �� ����� ���� ������ ��",
       "--������ �������, ���� ���������� �����\r\n--�� ��������� �� ����� ������� ����� � ��������\r\n--�������, ��� ���������� �������� ���� �������\r\n--������ ��������������� ���� � ������������ ���������� ��� ����� ���������",
       "--������� �� ���������� �����\r\n--������ �� �������� ��������� ��� ���� ������ ������� ���� � �����\r\n--��� ������ �� �������� ���� ������� \r\n--��� �������� ������� ����, �������������� �� �����",
       "--���� ��������� ��������� ��� ����� �� ����\r\n--�������� ���� ����� �������� �� ���� ������� �������, �����\r\n--������ ��� �������� ������������ �� ���������� �����\r\n--������� �� ������ ��",
       "--� ���� ������� �� ���������� �������� ���� ����� ����� � �������\r\n--� ������� �� ������ ��� ����� ����������� ��������\r\n--������� ��� �������� ���� �����, �� ����� �������� ����� ����� ���������\r\n--���������� ������ ��� � ��������",
       "--���������� �������, �� �������� ��������� ����������\r\n--�� ��������, ��� ��������� ������ � �������� �� ��������� ��������� �������\r\n--����� ����� ����� ���� ����� ���������� ����� ������\r\n--���������� ��� ������� � ���� ������������"

    };



    public static List<string> levelNameTextEng = new List<string> {
        "Battle on the border",
        "Protection of Neptune",
        "Marauders on Saturn",
        "Enemy on Jupiter",
        "Attack on Mars",
        "Battle for Earth",
        "Emperor at the Sun",
        "New challenges soon"
    }; 
    public static List<string> levelNameTextRus = new List<string> {
        "����� � ������",
        "������ �������",
        "�������� �� �������",
        "���� � �������",
        "����� �� ����",
        "����� �� �����",
        "��������� � ������",
        "����� ����� �����"
    };

    public static List<string> CharactersNameTextEng = new List<string> {
        "Commander",
        "Lord Filsh",
        "Lord Zerf",
        "Admiral Zerbo",
        "Emperor Ceres"
    }; 
    
    public static List<string> CharactersNameTextRus = new List<string> {
        "������� 2 �����",
        "������� ����",
        "������� ����",
        "������� �����",
        "��������� �����"
    };
    public static List<string> getStoryTextList()
    {
        if (language == 0) return storyTextEng;
        else return storyTextRus;
    }
    public static List <string> getAlienTextList() {
        if (language == 0) return alienTextEng;
        else return alienTextRus;
    }
    public static List<string> getAssistantTextList()
    {
        if (language == 0) return assistantTextEng;
        else return assistantTextRus;
    }
    public static List<string> getLevelName()
    {
        if (language == 0) return levelNameTextEng;
        else return levelNameTextRus;
    }

    public static string getLevelWord() {
        if (language == 0) levelWord = "Level";
        else levelWord = "�������";

        return levelWord;
    }

    public static string getStartWord () { 
        if (language == 0) startWord = "Start";
        else startWord = "�����";

        return startWord;
    }

    public static string getDefeatWord() {
        if (language == 0) endGameWord = "Defeat";
        else endGameWord = "���������";

        return endGameWord;
    }
    public static string getVictoryWord()
    {
        if (language == 0) endGameWord = "Victory";
        else endGameWord = "������";

        return endGameWord;
    }

    public static string getLoadingWord()
    {
        if (language == 0) loadingWord = "Loading";
        else loadingWord = "��������";

        return loadingWord;
    }
    public static string getShieldOffWord()
    {
        if (language == 0) shieldsOffWord = "Shields off";
        else shieldsOffWord = "���� ����.";

        return shieldsOffWord;
    }

    public static List<string> getCharacterName()
    {
        if (language == 0) return CharactersNameTextEng;
        else return CharactersNameTextRus;
    }

    public static void AdsTimer(float value) {
        adsTimer += value;
    }
    public static void SetAdsTimer(float value)
    {
        adsTimer = value;
    }
    public static void ResetAdsTimer()
    {
        adsTimer = 0;
    }
    public static float getAdsTimer()
    {
        return adsTimer;
    }


    public static void setAdsBought(bool state) {
        adsOff = state;
    }

    public static bool getAdsBought() {
        return adsOff;
    }
}
