using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Stats stats;
    GameManager gameManager;
    int HP;
    int damage;

    private void Start()
    {
        gameManager = FindAnyObjectByType<GameManager>().GetComponent<GameManager>();
    }
    private void Awake()
    {
        HP = stats.HP;
        damage = stats.damage;
    }

    void Update()
    {
        if(gameManager.Phase == 4)
        {
            //Debug.Log("Enemy Turn!");
        }

    }

    public void Takedamage(int damage)
    {
        HP-= damage;        
        if(HP <= 0)
        {
            Destroy(gameObject);
        }

        Debug.Log(HP);
    }

}
