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

    void Start()
    {
        // Balığın rb sine ulaştık 
        _rb = GetComponent<Rigidbody2D>();

    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _rb.velocity = new Vector2(_rb.velocity.x, speed);

        }

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

        transform.rotation = Quaternion.Euler(0, 0, angle);
    }
}
