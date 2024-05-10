using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{

    public GameObject NodeObject;
    public Color Hovercolor;
    public Color Okecolor;
    public LayerMask PathLayer;

    bool SebelahPlayer = false;
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
        if(gameManager.Phase == 0)
        {
            rend.material.color = Startcolor;
        }



    }
    private void OnMouseDown()
    {
        if(gameManager.Phase == 1 && SebelahPlayer == true)
        {
            if(gameManager.Action == "Attack")
            {

            }
            else if(gameManager.Action == "Dive")
            {

            }
            else if(gameManager.Action == "Move")
            {
                //mindahin player ke node yang diinginkan
                Node temp = gameManager.PlayerNode.GetComponent<Node>();
                ThisNode.NodeObject = gameManager.PlayerNode.NodeObject;
                ThisNode.NodeObject.transform.position = transform.position;
                gameManager.PlayerNode = ThisNode;
                temp.NodeObject = null;

                //reset phase
                gameManager.Phase = 0;
            }
        }

    }

    private void OnMouseEnter()
    {
        //ganti warna ketika hover
        if(gameManager.Phase == 1 && SebelahPlayer == true)
        {
            rend.material.color = Hovercolor;
        }

    }

    
    private void OnMouseExit()
    {
        //ganti warna ketika tidak hover
        if (gameManager.Phase == 1 && SebelahPlayer == true)
        {
            rend.material.color = Okecolor;
            
        }

    }
    
    
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, 0.1f);
    }
    
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
}
