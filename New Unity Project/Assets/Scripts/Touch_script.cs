using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Touch_script : MonoBehaviour
{

    private void OnMouseDown()
    {
        if(!Pause_script.GameIsPause)
            PlayerController.isJump = true;

    }
}
