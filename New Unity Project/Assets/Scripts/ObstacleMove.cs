using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMove : MonoBehaviour
{
    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(-5f, 0f);
    }

    private void Update()
    {
        if (PlayerController.isDead)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 0f);
        }
    }

}
