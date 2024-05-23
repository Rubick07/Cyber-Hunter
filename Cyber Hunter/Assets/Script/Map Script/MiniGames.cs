using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGames : MonoBehaviour
{
    GameManager gameManager;

    void Start()
    {
        gameManager = FindAnyObjectByType<GameManager>().GetComponent<GameManager>();
    }

    public void Win()
    {
        Debug.Log("You Win");
        gameManager.PlayerTurnEnd();
        Destroy(gameManager.DiveNode.NodeObject);
        Destroy(gameObject);
    }

    public void Lose()
    {
        Debug.Log("You Lose");
        gameManager.PlayerTurnEnd();
        Destroy(gameObject);
    }

}
