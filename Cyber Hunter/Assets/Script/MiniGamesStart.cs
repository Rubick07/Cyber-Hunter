using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGamesStart : MonoBehaviour
{
    public GameObject Minigames;

    public void SpawnMiniGames()
    {
        GameManager gameManager = FindObjectOfType<GameManager>().GetComponent<GameManager>();
        gameManager.UI.SetActive(false);
        GameObject MinigamesObject = Instantiate(Minigames, gameManager.PlayerNode.transform);
        MinigamesObject.transform.parent = null;
    }

}
