using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class BackgroundManager : MonoBehaviour
{

    public static BackgroundManager Instance { get; private set; }

    private GameObject ObjectPulled;
    private List<GameObject> ObjectPulledList;
    private const int level3AsteroidsCount =4;
    private const int level4AsteroidsCount=5;
    private const int level5AsteroidsCount=3;

    [SerializeField]
    private List<GameObject> levelBackdounds;

    private void Awake()
    {
        Instance = this;
    }


    public void pullAsteroidsOnStart()
    {
        if (CommonData.Instance.getGameLevel() == 3)
        {
            for (int i = 0; i < level3AsteroidsCount; i++)
            {
                ObjectPulledList = ObjectPuller.current.GetAsteroidsList();
                ObjectPulled = ObjectPuller.current.GetGameObjectFromPull(ObjectPulledList);
                ObjectPulled.transform.position = new Vector2 (UnityEngine.Random.Range (CommonData.Instance.horisScreenSize/2, -CommonData.Instance.horisScreenSize / 2), UnityEngine.Random.Range(4f, 7f));
                ObjectPulled.SetActive(true);
            }
        }
        else if (CommonData.Instance.getGameLevel() == 4) {
            for (int i = 0; i < level4AsteroidsCount; i++)
            {
                ObjectPulledList = ObjectPuller.current.GetAsteroidsList();
                ObjectPulled = ObjectPuller.current.GetGameObjectFromPull(ObjectPulledList);
                ObjectPulled.transform.position = new Vector2(UnityEngine.Random.Range(CommonData.Instance.horisScreenSize / 2, -CommonData.Instance.horisScreenSize / 2), UnityEngine.Random.Range(4f, 7f));
                ObjectPulled.SetActive(true);
            }
        }
        else if (CommonData.Instance.getGameLevel() == 5)
        {
            for (int i = 0; i < level5AsteroidsCount; i++)
            {
                ObjectPulledList = ObjectPuller.current.GetAsteroidsList();
                ObjectPulled = ObjectPuller.current.GetGameObjectFromPull(ObjectPulledList);
                ObjectPulled.transform.position = new Vector2(UnityEngine.Random.Range(CommonData.Instance.horisScreenSize / 2, -CommonData.Instance.horisScreenSize / 2), UnityEngine.Random.Range(4f, 7f));
                ObjectPulled.SetActive(true);
            }
        }
    }

    public void setBackground() {
        foreach (GameObject levels in levelBackdounds) levels.SetActive(false);
        levelBackdounds[CommonData.Instance.getGameLevel()].SetActive(true);
    }

    public void pullNewAsteroid() {
        ObjectPulledList = ObjectPuller.current.GetAsteroidsList();
        ObjectPulled = ObjectPuller.current.GetGameObjectFromPull(ObjectPulledList);
        ObjectPulled.transform.position = new Vector2(-CommonData.Instance.horisScreenSize / 2-2, UnityEngine.Random.Range(4f, 7f));
        ObjectPulled.SetActive(true);
    }

}
