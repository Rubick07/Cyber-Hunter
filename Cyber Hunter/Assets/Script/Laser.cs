using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public Transform LaserOrigin;
    public float Range;

    LineRenderer lineRenderer;
    public LayerMask Target;
    bool sumber;

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        
    }

    // Update is called once per frame
    void Update()
    {

        lineRenderer.SetPosition(0, LaserOrigin.position);

        RaycastHit2D hit = Physics2D.Raycast(LaserOrigin.position, transform.right, 100f, Target);

        Vector3 RayOrigin = transform.position;

        if(hit.collider != null)
        {
            lineRenderer.enabled = true;
            //Debug.Log("Ada");
            lineRenderer.SetPosition(1, hit.point);
        }
        else 
        {
            lineRenderer.enabled = false;
            //Debug.Log("Tidak Ada");
            //lineRenderer.SetPosition(1, transform.right * 100);
        }

    }
}
