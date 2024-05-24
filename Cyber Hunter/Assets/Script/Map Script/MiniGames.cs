using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGames : MonoBehaviour
{
    GameManager gameManager;
    [SerializeField] private float Countdown;
    void Start()
    {
        gameManager = FindAnyObjectByType<GameManager>().GetComponent<GameManager>();
    }

    public void Win()
    {
        Debug.Log("You Win");
        Node[] Nodes = FindObjectsOfType<Node>();
        foreach (Node node in Nodes)
        {
            Collider2D collider2D = node.GetComponent<Collider2D>();
            collider2D.enabled = true;
        }
        gameManager.PlayerTurnEnd();
        Destroy(gameManager.DiveNode.NodeObject);
        Destroy(gameObject);
    }

    public IEnumerator WinMinigames()
    {
        
        Node[] Nodes = FindObjectsOfType<Node>();
        foreach (Node node in Nodes)
        {
            Collider2D collider2D = node.GetComponent<Collider2D>();
            collider2D.enabled = true;
        }
        Debug.Log("You Win");

        yield return new WaitForSeconds(1f);
        
        Destroy(gameManager.DiveNode.NodeObject.gameObject);
        Destroy(gameObject);
        gameManager.PlayerTurnEnd();


    }

    public void Lose()
    {
        Node[] Nodes = FindObjectsOfType<Node>();
        foreach (Node node in Nodes)
        {
            Collider2D collider2D = node.GetComponent<Collider2D>();
            collider2D.enabled = true;
        }
        Debug.Log("You Lose");
        gameManager.PlayerTurnEnd();
        Destroy(gameObject);
    }

    public IEnumerator ClearStage()
    {

        yield return new WaitForSeconds(1f);

        Destroy(gameManager.DiveNode.NodeObject.gameObject);
        Destroy(gameObject);
        gameManager.StageClear();
        //gameManager.PlayerTurnEnd();
    }

}
