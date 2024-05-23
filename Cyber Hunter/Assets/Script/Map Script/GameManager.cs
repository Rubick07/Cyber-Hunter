using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Properties turn")]
    public int Phase = 0;
    public int Turn = 0;
    public int MaxTurn;
    public bool DoubleTurn = false;
    [Header("GameObjects")]
    public GameObject ActionMenu;
    public GameObject MiniGamesFireWall;
    public GameObject MiniGamesFinish;
    public string Action;
    public Node PlayerNode;
    public Node DiveNode;
    [Header("Static")]
    public static GameManager Instance;
    int oke = 0;
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
                    //Debug.Log(node);
                    PlayerNode = node;
                }
            }
        }
    }

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;

        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Update()
    {
        //Phase 0 = check buff
        if(Phase == 0)
        {
            Phase++;
        }
        //Phase 1 = Milih Action
        else if(Phase == 1)
        {
            ActionMenu.SetActive(true);
            Action = null;
        }
        //Phase 2 = Sudah Memilih Action, sekarang fase memilih Node
        else if(Phase == 2)
        {
            ActionMenu.SetActive(false);
        }
        //Phase 3 = Check Condition
        else if(Phase == 3)
        {
            Phase++;
            ResetNode();
        }
        //Phase 4 = Enemy turn
        else if(Phase == 4 && oke == 0)
        {
            //bikin list Node enemy yang mana aja
            List<Node> EnemyNode = new List<Node>();
            Node[] Nodes = FindObjectsOfType<Node>();
            
            //masukin ke list
            foreach(Node node in Nodes)
            {
                if(node.NodeObject != null)
                {
                    if (node.NodeObject.GetComponent<Enemy>())
                    {
                        EnemyNode.Add(node);
                        Debug.Log("Masuk");
                    }
                }

            }

            foreach(Node Enemy in EnemyNode)
            {
                Enemy.EnemyCariJalan();
            }

            oke = 1;
            Phase++;
        }
        //Phase 5 = Check Condition
        else if(Phase == 5)
        {
            Phase++;
        }
        else if (Phase == 6)
        {
            resetPhase();
        }




    }

    public void PlayerTurnEnd()
    {
        if(DoubleTurn == true)
        {
            Phase--;
            DoubleTurn = false;
        }
        else
        {
            Phase++;
        }        
        ResetNode();
    }

    public void EnemyTurnEnd()
    {
        Phase++;

    }

    public void CheckCondition()
    {

    }
    public void resetPhase()
    {
        Phase = 0;
        oke = 0;
        Turn++;
    }

    public void MiniGamesStart(int tanda)
    {
        if(tanda == 0)
        {
            Instantiate(MiniGamesFinish, PlayerNode.transform);
        }
        else if(tanda == 1)
        {
            Instantiate(MiniGamesFireWall, PlayerNode.transform);
        }

    }

    public void ResetNode()
    {
        Node[] nodes = FindObjectsOfType<Node>();
        foreach (Node node in nodes)
        {

            node.SebelahPlayer = false;
        }
    }


}
