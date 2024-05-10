using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path : MonoBehaviour
{
    public Node[] Nodes;
    public LayerMask NodeLayer;
    public Transform Point1;
    public Transform Point2;


    private void Start()
    {
        //Cek ujung path untuk mencari Node
        Collider2D[] Collidernode1 = Physics2D.OverlapCircleAll(Point1.position, 0.1f, NodeLayer);
        Collider2D[] Collidernode2 = Physics2D.OverlapCircleAll(Point2.position, 0.1f, NodeLayer);

        //Convert ke Node
        Node Node1 = Collidernode1[0].gameObject.GetComponent<Node>();
        Node Node2 = Collidernode2[0].gameObject.GetComponent<Node>();

        //simpan ke array
        Nodes[0] = Node1;
        Nodes[1] = Node2;

    }



    private void OnDrawGizmos()
    {
        if(!Point1 && !Point2)
        {
            return;
        }
        Gizmos.DrawWireSphere(Point1.position, 0.1f);
        Gizmos.DrawWireSphere(Point2.position, 0.1f);
    }

}
