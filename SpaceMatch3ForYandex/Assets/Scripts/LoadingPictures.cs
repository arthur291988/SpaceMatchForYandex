using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LoadingPictures : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI loadingWord;

    [SerializeField]
    private Image planet;

    [SerializeField]
    private List<Sprite> planets;

    //private List
    // Start is called before the first frame update
    void Start()
    {
        if (GameParams.currentLevel <= 1) planet.sprite = planets[0]; //Neptune
        else if (GameParams.currentLevel == 2) planet.sprite = planets[1];//Saturn
        else if (GameParams.currentLevel == 3) planet.sprite = planets[2];//Jupiter
        else if (GameParams.currentLevel == 4) planet.sprite = planets[3];//Mars
        else if (GameParams.currentLevel == 5) planet.sprite = planets[4];//Earth
        else if (GameParams.currentLevel == 6) planet.sprite = planets[5];//Venus

        loadingWord.text = GameParams.getLoadingWord();
    }

}
