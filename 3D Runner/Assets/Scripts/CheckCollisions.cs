using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CheckCollisions : MonoBehaviour
{
    public int score;
    public TextMeshProUGUI CoinText;

    public PlayerController playerController;
    Vector3 PlayerStartPos;
    public GameObject speedBoosterIcon;

    private InGameRanking ig;

    private void Start()
    {
        PlayerStartPos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        speedBoosterIcon.SetActive(false);

        ig = FindObjectOfType<InGameRanking>();

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            AddCoin();
            // Destroy(other.gameObject);
            other.gameObject.SetActive(false);
        }
        else if (other.CompareTag("Finish"))
        {
            PlayerFinished();
             if (ig.namesTxt[6].text == "Player")
            {
                Debug.Log("Congrats!..");
            }
            else
            {
                Debug.Log("You Lose!..");
            }

        }
        else if (other.CompareTag("SpeedBoost"))
        {
            playerController.runningSpeed = playerController.runningSpeed + 3f;
            speedBoosterIcon.SetActive(true);
            StartCoroutine(SlowAfterAWhileCoroutine());
        }
    }

    void PlayerFinished()
    {
        playerController.runningSpeed = 0f;
    }
    public void AddCoin()
    {
        score++;
        CoinText.text = "Score: " + score.ToString();
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            // Debug.Log("Caprti");
            transform.position = PlayerStartPos;
        }
    }

    private IEnumerator SlowAfterAWhileCoroutine()
    {
        yield return new WaitForSeconds(2.0f);
        playerController.runningSpeed = playerController.runningSpeed - 3f;
        speedBoosterIcon.SetActive(false);
    }
}
