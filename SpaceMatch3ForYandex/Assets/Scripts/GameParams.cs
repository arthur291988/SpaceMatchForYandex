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
        "После объединения всех людей в мире мы начали жить в гармонии и совершили гигантский скачок вперед",

        "Солнечная федерация возникла из человеческой цивилизации Земли. Она стала единым государством для всех",

        "Затем мы предприняли шаги по исследованию Солнечной системы",

        "Вначале это были скромные проекты на ближних планетах",

        "Но очень скоро мы построили огромные колонии на каждой планете системы",

        "Сейчас человечество готово начать свое путешествие к звездам",

        "Покоряя новые миры и преодолевая все опасности на своем пути"
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
        "--На колени перед войсками Императора Цереса\r\n--Я Владыка Филш и вы будете уничтожены моим передовым отрядом\r\n--Прощайтесь с жизнью",
        "--Вы смогли одолеть отряд слабаков\r\n--Я отомщу вам уничтожив эту планету \r\n--Вы все сгорите",
        "--Надо же, вы смогли победить ничтожного Филша\r\n--Я Владыка Зерв и со мной вам не тягаться\r\n--Мародеры раздавите этих муравьев и разграбьте эту планету",
        "--Придя к моей станции Вы подписали себе смертный приговор\r\n--Готовьтесь встретить свою погибель\r\n--А после, я уничтожу эту планету",
        "--Не могу поверить что Филш и мой брат Зерв уничтожены\r\n--Я отправил на уничтожение вашей красной планеты свой элитный отряд а сам направлюсь на вашу основную планету\r\n--Теперь вам точно конец, император Церес будет доволен",
        "--Вы здесь?! Стало быть, мой элитный отряд уничтожен\r\n--Во имя Императора я вас всех сотру в звездную пыль\r\n--Пусть победит сильнейший",
        "--Ничтожества!\r\n--Как вы посмели противостоять моим войскам\r\n--С самого начала нашей целью была ваша звезда, я планирую выкачать всю ее энергию \r\n--А вы погибните как насекомые\r\n--Смерьт Вам!"

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
       "--Приветствую Вас капитан Солнечной федерации\r\n--Получено тревожное сообщение с границ нашей федерации, на нас напали враждебные пришельцы. \r\n--Вы должны отправляться на граничные сектора и отбить первую волну атаки \r\n--Удачи Вам капитан",
       "--Отлично капитан\r\n--Мы отбили первую волну атаки\r\n--Сейчас враг концентрирует свои силы у Нептуна где наши приграничные колонии\r\n--Включайте нулевой переход и перехватите их силы",
       "--Вы настоящий защитник человечества\r\n--Поступают сообщения о разграбленных водородных добывающих платформах на Сатурне\r\n--Нам необходимо защитить наши ресурсы \r\n--Запускайте двигатели мы летим туда сейчас же",
       "--Сатурн защищен, пора уничтожить Зерва\r\n--Он находится на своей станции рядом с Юпитером\r\n--Кажется, они собираются взорвать ядро планеты\r\n--Срочно телепортируемся туда и предотвратим катастрофу для наших сограждан",
       "--Отлично мы уничтожили Зерва\r\n--Однако мы получили сообщение что враг собрал большие силы у Марса\r\n--Это вторая по величине наша колония \r\n--Вам выделили сильный флот, воспользуйтесь им мудро",
       "--Враг попытался разделить нас напав на Марс\r\n--Основные силы Зербо направил на нашу главную планету, Землю\r\n--Армада уже вплотную приблизилась на расстояние удара\r\n--Атакуем их сейчас же",
       "--О Боже капитан… мы обнаружили огромный флот врага рядом с Солнцем\r\n--Я никогда не видела так много флагманских кораблей\r\n--Кажется это основной флот врага, мы можем положить конец этому вторжению\r\n--Уничтожьте врагов раз и навсегда",
       "--Поздравляю Капитан, мы отразили вторжение пришельцев\r\n--Мы доказали, что Федерация готова к развитию за границами Солнечной Системы\r\n--Очень скоро перед Вами будут поставлены новые задачи\r\n--Приглашаем Вас ступить в штаб командования"

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
        "Битва у границ",
        "Защита Нептуна",
        "Мародеры на Сатурне",
        "Враг у Юпитера",
        "Атака на Марс",
        "Битва за Землю",
        "Император у Солнца",
        "Новые битвы скоро"
    };

    public static List<string> CharactersNameTextEng = new List<string> {
        "Commander",
        "Lord Filsh",
        "Lord Zerf",
        "Admiral Zerbo",
        "Emperor Ceres"
    }; 
    
    public static List<string> CharactersNameTextRus = new List<string> {
        "Капитан 2 ранга",
        "Владыка Филш",
        "Владыка Зерв",
        "Адмирал Зербо",
        "Император Церес"
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
        else levelWord = "Уровень";

        return levelWord;
    }

    public static string getStartWord () { 
        if (language == 0) startWord = "Start";
        else startWord = "Старт";

        return startWord;
    }

    public static string getDefeatWord() {
        if (language == 0) endGameWord = "Defeat";
        else endGameWord = "Поражение";

        return endGameWord;
    }
    public static string getVictoryWord()
    {
        if (language == 0) endGameWord = "Victory";
        else endGameWord = "Победа";

        return endGameWord;
    }

    public static string getLoadingWord()
    {
        if (language == 0) loadingWord = "Loading";
        else loadingWord = "Загрузка";

        return loadingWord;
    }
    public static string getShieldOffWord()
    {
        if (language == 0) shieldsOffWord = "Shields off";
        else shieldsOffWord = "Щиты выкл.";

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
