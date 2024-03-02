using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinCondition : MonoBehaviour
{
    public GameObject winScreen;

    // When the flag is triggered, player wins
    private void OnTriggerEnter2D(Collider2D collision)
    {
        winScreen.SetActive(true);

        Debug.Log(collision.gameObject.name);
    }
}
