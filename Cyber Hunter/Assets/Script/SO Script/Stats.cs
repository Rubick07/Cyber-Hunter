using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Stats", menuName ="Stats")]
public class Stats : ScriptableObject
{
    public new string name;
    public string description;

    public Sprite sprite;

    public int HP;
    public int damage;

}
