using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    //Variables
    public Text score;
    public Text bestScore;

    void Start()
    {
        score.text += PlayerPrefs.GetInt("Score").ToString();
        bestScore.text += PlayerPrefs.GetInt("BestScore").ToString();
    }
}
