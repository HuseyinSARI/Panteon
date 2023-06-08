using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour
{

    private Rigidbody2D _rb;
    public float speed;
    int angle;
    int maxAgle = 20;
    int minAgle = -60;
    public Score score;
    public GameManager gameManager;
    public Sprite fishDied;
    SpriteRenderer sp;
    Animator anim;
    bool touchedGround;



    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        sp = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        FishSwim();

    }
    private void FixedUpdate()
    {
        FishRotation();
    }

    void FishSwim()
    {
        if (Input.GetMouseButtonDown(0) && GameManager.gameOver == false)
        {
            _rb.velocity = Vector2.zero;
            _rb.velocity = new Vector2(_rb.velocity.x, speed);
        }
    }

    void FishRotation()
    {

        if (_rb.velocity.y > 0)
        {
            if (angle <= maxAgle)
            {
                angle = angle + 4;

            }

        }
        else if (_rb.velocity.y < -2.5f)
        {
            if (angle >= minAgle)
            {
                angle = angle - 2;

            }
        }
        if (touchedGround == false)
        {
            transform.rotation = Quaternion.Euler(0, 0, angle);
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Obstacle"))
        {
            score.Scored();
        }
        else if (collision.CompareTag("Column"))
        {
            //gameover
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            if (GameManager.gameOver == false)
            {
                gameManager.GameOver();
                GameOver();
            }
        }
    }

    void GameOver()
    {
        sp.sprite = fishDied;
        anim.enabled = false;
        touchedGround = false;
        transform.rotation = Quaternion.Euler(0, 0, -90);
    }

}
