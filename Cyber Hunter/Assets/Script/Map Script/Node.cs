using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{

    public GameObject NodeObject;
    public Buff BuffObject;
    public Color Hovercolor;
    public Color Okecolor;
    public LayerMask PathLayer;
    public bool SebelahPlayer = false;
    GameManager gameManager;
    [SerializeField] Path[] Paths;
    private Color Startcolor;
    private Renderer rend;
    private Node ThisNode;
    private List<Node> NodesYangLewat = new List<Node>();
    private Node NodePlayer;
    private DialogueTrigger dialogueTrigger;
    private void Start()
    {
        gameManager = FindAnyObjectByType<GameManager>().GetComponent<GameManager>();
        ThisNode = GetComponent<Node>();
        rend = GetComponent<Renderer>();
        dialogueTrigger = GetComponent<DialogueTrigger>();
        Startcolor = rend.material.color;


        //biar rapi objectnya ditengah node
        if (NodeObject != null)
        {
            NodeObject.transform.position = transform.position;
        }
        //sama tapi buat buff
        if(BuffObject != null)
        {
            BuffObject.gameObject.transform.position = transform.position;
        }

        //mencari jalan yang bisa ke node lain
        Collider2D[] PathsCollider = Physics2D.OverlapCircleAll(transform.position, 0.1f, PathLayer);
        Paths = new Path[PathsCollider.Length];
        int temp = 0;
        //simpen ke array 
        foreach(Collider2D pathcollider in PathsCollider)
        {
            Paths[temp] = pathcollider.gameObject.GetComponent<Path>();
            temp++;
        }

    }

    private void FixedUpdate()
    {
        //warna ketika memilih action
        if(gameManager.Phase == 1)
        {
            rend.material.color = Startcolor;
        }
    }
    private void OnMouseDown()
    {
        if(gameManager.Phase == 2 && SebelahPlayer == true)
        {
            if(gameManager.Action == "Attack")
            {
                if (ThisNode.NodeObject != null)
                {
                    if (ThisNode.NodeObject.GetComponent<Enemy>())
                    {
                        // enemy take damage
                        Enemy enemy = ThisNode.NodeObject.GetComponent<Enemy>();
                        Player player = gameManager.PlayerNode.NodeObject.GetComponent<Player>();
                        enemy.Takedamage(player.stats.damage);

                        // reset phase
                        gameManager.PlayerTurnEnd();
                    }
                    else
                    {
                        Debug.Log("Bukan enemy");
                        gameManager.Phase--;
                    }
                }
                else
                {
                    Debug.Log("Nothing Happen");
                    gameManager.Phase--;
                    //gameManager.PlayerTurnEnd();
                }

            }
            else if(gameManager.Action == "Dive")
            {
                gameManager.DiveNode = ThisNode;

                    Node[] Nodes = FindObjectsOfType<Node>();

                    foreach(Node node in Nodes)
                    {
                        Collider2D collider2D = node.GetComponent<Collider2D>();
                        collider2D.enabled = false;
                    }
                    MiniGamesStart miniGames = ThisNode.NodeObject.GetComponent<MiniGamesStart>();
                    miniGames.SpawnMiniGames();


            }

            else if(gameManager.Action == "Move")
            {
                if(ThisNode.NodeObject == null)
                {
                    //mindahin player ke node yang diinginkan
                    MovePlayerToThisNode();

                    //reset phase
                    gameManager.PlayerTurnEnd();
                }
                else
                {
                    Debug.Log("ada sesuatu disini");
                    gameManager.Phase--;
                }
            }


        }

    }

    private void OnMouseEnter()
    {
        //ganti warna ketika hover
        if(gameManager.Phase == 2 && SebelahPlayer == true)
        {
            rend.material.color = Hovercolor;
        }

    }

    
    private void OnMouseExit()
    {
        //ganti warna ketika tidak hover
        if (gameManager.Phase == 2 && SebelahPlayer == true)
        {
            rend.material.color = Okecolor;
            
        }

    }
    
    
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, 0.1f);
    }
    
    //buat nandain node di sebelah player
    public void NodeCheckSebelahPlayer()
    {
        foreach (Path path in Paths)
        {
            Path pathEach = path.GetComponent<Path>();

            foreach (Node nodeInPath in pathEach.Nodes)
            {
                if (nodeInPath.gameObject != gameObject)
                {
                    nodeInPath.SebelahPlayer = true;
                    nodeInPath.rend.material.color = nodeInPath.Okecolor;

                }
            }

        }
    }
    //khusus dive
    public void NodeCheckSebelahPlayerDIVE()
    {
        foreach (Path path in Paths)
        {
            Path pathEach = path.GetComponent<Path>();

            foreach (Node nodeInPath in pathEach.Nodes)
            {
                if (nodeInPath.gameObject != gameObject)
                {
                    if(nodeInPath.NodeObject != null && nodeInPath.NodeObject.CompareTag("DiveObject"))
                    {
                        nodeInPath.SebelahPlayer = true;
                        nodeInPath.rend.material.color = nodeInPath.Okecolor;
                    }

                }
            }

        }
    }
    //buat move
    public void MovePlayerToThisNode()
    {
        //MovePlayer
        Node temp = gameManager.PlayerNode.GetComponent<Node>();
        ThisNode.NodeObject = gameManager.PlayerNode.NodeObject;
        ThisNode.NodeObject.transform.position = transform.position;
        gameManager.PlayerNode = ThisNode;
        temp.NodeObject = null;

        //checkBuff
        if(BuffObject != null)
        {
            if (BuffObject.BuffNumber == 0)
            {
                BuffObject.ChatLog();
            }

            else if(BuffObject.BuffNumber == 1)
            {
                BuffObject.VoiceLog();
            }

            else if(BuffObject.BuffNumber == 2)
            {
                BuffObject.DigitalTrail();
            }
            else if(BuffObject.BuffNumber == 3)
            {
                BuffObject.SpareEnergyBox();
            }

            Destroy(BuffObject.gameObject);
        }

        if(dialogueTrigger != null)
        {
            dialogueTrigger.NewDialogue();
            dialogueTrigger = null;
        }

    }


    int MinMove = 99;
    public bool EnemyMovement(Node CurrNode, int move)
    {
        NodesYangLewat.Add(CurrNode);
        
        //Debug.Log("Saya rekursif");
        //Debug.Log(CurrNode);
        if(CurrNode.NodeObject != null)
        {
            if (CurrNode.NodeObject.GetComponent<Player>())
            {
                //Debug.Log(CurrNode + " Aku Player");
                if(move < MinMove)
                {
                    MinMove = move;
                    return true;
                }
                
            }

        }        
           foreach(Path pathEach in CurrNode.Paths)
           {
            //Debug.Log(CurrNode + "" + pathEach);

                foreach (Node nodeInPath in pathEach.Nodes)
                {                    
                    if (nodeInPath.gameObject != gameObject)
                    {
                        if (NodesYangLewat.Contains(nodeInPath))
                        {
                        //Debug.Log(CurrNode + "Block" + nodeInPath);

                        continue;
                        }
                        else if(EnemyMovement(nodeInPath, move + 1))
                        {
                        if (ThisNode != nodeInPath)
                        {
                            //Debug.Log("ThisNode adalah" + ThisNode + "dan NodePLayer adalah" + NodePlayer );
                            NodePlayer = nodeInPath;
                        }
                        

                            
                            
                            //Debug.Log(NodePlayer);
                            
                        
                            return true;
                        }

                    }
                }

           }

        return false;
    }
    


    public void EnemyCariJalan()
    {
        MinMove = 99;
        NodesYangLewat.Clear();               
        NodePlayer = null;
        //Debug.Log
        EnemyMovement(ThisNode, 0);
        if(NodePlayer != null)
        {
            if(NodePlayer.NodeObject != null)
            {
                if (NodePlayer.NodeObject.GetComponent<Player>())
                {
                    Player player = NodePlayer.NodeObject.GetComponent<Player>();
                    Enemy enemy = ThisNode.NodeObject.GetComponent<Enemy>();
                    player.TakeDamage(enemy.damage);
                    Destroy(ThisNode.NodeObject);
                    ThisNode.NodeObject = null;
                }
            }
            else if (NodePlayer.NodeObject == null)
            {
                //Debug.Log("Jalan");
                    NodePlayer.NodeObject = ThisNode.NodeObject;
                    ThisNode.NodeObject.transform.position = NodePlayer.gameObject.transform.position;
                    ThisNode.NodeObject = null;
                
            }

        }
        else
        {
            //print("Kosong hehe");
        }


    }


    
}
