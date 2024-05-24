using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public Transform LaserOrigin;
    public float Range;

    LineRenderer lineRenderer;
    public LayerMask Target;
    public bool sumber;

    private float CountDown = 1;
    RaycastHit2D hit;
    

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        lineRenderer.SetPosition(0, LaserOrigin.position);

        hit = Physics2D.Raycast(LaserOrigin.position, transform.right, 100f, Target);

        Vector3 RayOrigin = transform.position;      

        if(sumber == true)
        {
            lineRenderer.SetPosition(1, transform.right * 100);
            //Debug.Log(hit);
            if (hit.collider != null)
            {
                lineRenderer.enabled = true;
                //Debug.Log("Ada");
                lineRenderer.SetPosition(1, hit.point);
                if (hit.collider.GetComponent<Laser>()){
                    NyalainLaser();
                }
                else
                {
                    MatiinLaser();
                }

            }

        }   
        else
        {
            if(CountDown <= 0)
            {
                lineRenderer.enabled = false;
                return;
            }
            else
            {
                if (hit.collider != null)
                {
                    lineRenderer.SetPosition(1, hit.point);

                    if (hit.collider.GetComponent<Laser>())
                    {                        
                        NyalainLaser();
                    }

                    else if (hit.collider.GetComponent<LightGoal>())
                    {
                        Debug.Log("menang");
                        MiniGames miniGames = FindAnyObjectByType<MiniGames>();
                        StartCoroutine(miniGames.ClearStage());
                    }
                    else
                    {
                        lineRenderer.SetPosition(1, hit.point);
                    }

                }
                else 
                {
                lineRenderer.SetPosition(1, transform.right * 100);
                }
                CountDown -= Time.deltaTime;
            }

            
        }
        
        


    }

    public void NyalainLaser()
    {
        Laser laser = hit.collider.GetComponent<Laser>();
        LineRenderer line = hit.collider.GetComponent<LineRenderer>();
        line.enabled = true;

        laser.enabled = true;
        laser.CountDown = 0.1f;
    }

    public void MatiinLaser()
    {
        Laser laser = hit.collider.GetComponentInParent<Laser>();
        LineRenderer line = hit.collider.GetComponentInParent<LineRenderer>();
        if(laser.sumber == false)
        {
        line.enabled = false;
        laser.enabled = false;
        }

    }




}
