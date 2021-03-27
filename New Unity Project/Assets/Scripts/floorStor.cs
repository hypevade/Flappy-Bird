using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class floorStor : MonoBehaviour
{
    void Update()
    {
        if (PlayerController.isDead)
        {
            GetComponent<Animator>().enabled = false;
        }

    }
}
