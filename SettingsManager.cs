using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsManager : MonoBehaviour
{
    public void DeleteScore()
    {
        PlayerPrefs.DeleteKey("Score");
        PlayerPrefs.DeleteKey("BestScore");
    }
}
