using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //Variables
    public static GameManager instance;
    public Text textTime;
    float time = 0.0f;
    public GameObject zombie;
    public GameObject wolf;
    int score = 0;

    public void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        textTime.text = ((int)time).ToString();

        //Cuando el contador llegue a 10, aparecerá el Zombie
        if ((int)time == 10)
        {
            zombie.gameObject.SetActive(true);
        }
        //Cuando el contador llegue a 20, aparecerá el Wolf
        if ((int)time == 20)
        {
            wolf.gameObject.SetActive(true);
        }

        time += Time.deltaTime;
    }

    public int getScore()
    {
        return (int)time;
    }

    //Método para llamar a la pantalla de GameOver
    public void gameOver()
    {
        score = GameManager.instance.getScore();

        //Si se consigue una puntuación mayor al record actual, se guarda la nueva puntuación
        if (score > PlayerPrefs.GetInt("BestScore"))
        {
            PlayerPrefs.SetInt("BestScore", score);
        }

        PlayerPrefs.SetInt("Score", score);
        SceneManager.LoadScene("GameOver");
    }
}
