using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{
    public GameObject gameOverScreen;
    public int playerscore;
    public Text scoreText;

    void Start()
    {

        gameOverScreen.SetActive(false);
    }

    public void addscore()
    {
        playerscore = playerscore + 1;
        scoreText.text = playerscore.ToString();
    }

    void Update()
    {

    }
    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GameOver()
    {
        gameOverScreen.SetActive(true);
    }
}
