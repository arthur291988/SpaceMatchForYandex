using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneSwitchManager : MonoBehaviour
{
    public static void LoadMenuScene()
    {
        Loader.Load(1);
    }
    public static void LoadBattleScene()
    {
        Loader.Load(2);
    }
}
