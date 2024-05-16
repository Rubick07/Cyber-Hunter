using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ActionMenu : MonoBehaviour
{
    GameManager gameManager;
    public GameObject FirstButtonActionMenu;
    void Start()
    {
        gameManager = FindAnyObjectByType<GameManager>().GetComponent<GameManager>();
    }

    private void OnEnable()
    {
        //reset firstbutton
        EventSystem.current.SetSelectedGameObject(null);
        //pasang firstbutton
        EventSystem.current.SetSelectedGameObject(FirstButtonActionMenu);
    }
    public void AttackAction()
    {
        gameManager.Phase++;
        gameManager.Action = "Attack";
        gameManager.PlayerNode.NodeCheckSebelahPlayer();
        
        Debug.Log("Attack");
    }

    public void DiveAction()
    {
        gameManager.Phase++;
        gameManager.Action = "Dive";
        Node[] nodes = FindObjectsOfType<Node>();
        gameManager.PlayerNode.NodeCheckSebelahPlayerDIVE();

        Debug.Log("Dive");
    }

    public void MoveAction()
    {
        gameManager.Phase++;
        gameManager.Action = "Move";
        gameManager.PlayerNode.NodeCheckSebelahPlayer();

        print("Move");
    }
}
