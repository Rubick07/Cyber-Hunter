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

    private void Start()
    {
        gameManager = FindAnyObjectByType<GameManager>().GetComponent<GameManager>();
        ThisNode = GetComponent<Node>();
        rend = GetComponent<Renderer>();
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
                if(ThisNode.NodeObject.name == "Finish")
                {
                    gameManager.MiniGamesStart(0);
                }
                else
                {

                }

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

    }



}
