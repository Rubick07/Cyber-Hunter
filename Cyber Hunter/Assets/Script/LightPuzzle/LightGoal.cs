using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightGoal : MonoBehaviour
{
    

    public void LightPuzzleWin()
    {
        MiniGames miniGames = FindAnyObjectByType<MiniGames>().GetComponent<MiniGames>();
        miniGames.Win();
    }

}
