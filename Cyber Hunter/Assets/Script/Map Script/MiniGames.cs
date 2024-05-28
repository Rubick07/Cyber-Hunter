using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MiniGames : MonoBehaviour
{
    GameManager gameManager;
    public bool ClearStageMiniGames;
    public TMP_Text Time_Text;
    [SerializeField] private float Countdown;
    void Start()
    {
        gameManager = FindAnyObjectByType<GameManager>().GetComponent<GameManager>();
    }

    private void Update()
    {
        if (Countdown > 0) {
        Countdown -= Time.deltaTime;
            Time_Text.text = Countdown.ToString("0");
        }
        
        else Lose();
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
        Debug.Log("spawn UI Menang");
        Destroy(gameManager.DiveNode.NodeObject.gameObject);
        Destroy(gameObject);
        //yield return new WaitForSeconds(1f);
        
        gameManager.StageClear();
        //gameManager.PlayerTurnEnd();
    }

    public IEnumerator LoseMiniGames()
    {
        Node[] Nodes = FindObjectsOfType<Node>();
        foreach (Node node in Nodes)
        {
            Collider2D collider2D = node.GetComponent<Collider2D>();
            collider2D.enabled = true;
        }
        Debug.Log("You Lose");
        yield return new WaitForSeconds(1f);

        gameManager.PlayerTurnEnd();
        Destroy(gameObject);
    }

}
