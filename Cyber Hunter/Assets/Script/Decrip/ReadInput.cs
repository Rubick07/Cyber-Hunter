using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadInput : MonoBehaviour
{
    private string input;
    Decri Jawaban;
    MiniGames miniGames;
    private void Awake()
    {
        Jawaban = FindObjectOfType<Decri>();
        miniGames = GetComponentInParent<MiniGames>();
    }

    public void ReadStringInput(string s)
    {
        input = s;
        CheckJawaban();
        Debug.Log(input);
    }

    public void CheckJawaban()
    {
        if(input.ToUpper() == Jawaban.DecriMeaning.ToUpper())
        {
            Debug.Log(input.ToUpper());
            Debug.Log("Kamu Benar");
            StartCoroutine(miniGames.WinMinigames());
        }
        else
        {
            Debug.Log("Anjay salah");
            
        }
    }


}
