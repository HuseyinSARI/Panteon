using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static Vector2 bottomLeft;
    public static bool gameOver;
    public GameObject gameOverPanel;
    public GameObject getReadyImage;
    public GameObject score;
    public static int gameScore;
    public static bool gameStarted;


    private void Awake()
    {
        bottomLeft = Camera.main.ScreenToWorldPoint(new Vector2(0, 0));
        gameOver = false;

    }
    // Start is called before the first frame update
    void Start()
    {
        gameStarted = false;
    }

    public void GameOver()
    {
        gameOver = true;
        gameScore = score.GetComponent<Score>().GetScore();
        gameOverPanel.SetActive(true);
        score.SetActive(false);
    }

    public void restartBtn()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void GameHasStarted()
    {
        gameStarted = true;
        getReadyImage.SetActive(false);
    }


    void Update()
    {

    }
}
