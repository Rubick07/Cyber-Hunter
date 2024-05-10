using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int Phase = 0;
    public int Turn = 0;
    public GameObject ActionMenu;
    public string Action;

    public Node PlayerNode;
    void Start()
    {
        Phase = 0;
        Node[] nodes = FindObjectsOfType<Node>();
        foreach (Node node in nodes)
        {
            if (node.NodeObject != null)
            {
                if (node.NodeObject.GetComponent<Player>())
                {
                    Debug.Log(node);
                    PlayerNode = node;
                }
            }
        }
    }

    
    void Update()
    {
        //Phase 0 = Milih Action
        if(Phase == 0)
        {
            ActionMenu.SetActive(true);
            Action = null;
        }
        //Phase 1 = Sudah Memilih Action, sekarang fase memilih Node
        else if(Phase == 1)
        {
            ActionMenu.SetActive(false);
        }




    }
}
