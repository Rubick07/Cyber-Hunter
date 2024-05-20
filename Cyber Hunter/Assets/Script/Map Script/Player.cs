using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    GameManager gameManager;
    public Stats stats;
    int HP;
    int MaxHp;
    int damage;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindAnyObjectByType<GameManager>().GetComponent<GameManager>();

    }
    private void Awake()
    {
        HP = stats.HP;
        MaxHp = HP;
        damage = stats.damage;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(1) && gameManager.Phase == 2)
        {
            gameManager.Phase--;
            gameManager.ResetNode();
        }

    }

    public void TakeDamage(int damage)
    {
        HP -= damage;
    }

    public void TakeHeal(int heal)
    {
        HP += heal;
        HP = (int)Mathf.Clamp(HP, 0f, MaxHp);
    }
}
