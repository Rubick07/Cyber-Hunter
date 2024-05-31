using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ReadInput : MonoBehaviour
{
    private string input;
    public TMP_Text TandaSalah;
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
            TandaSalah.text = "BENAR";
            StartCoroutine(miniGames.WinMinigames());
        }
        else
        {
            TandaSalah.text = "SALAH";
            Debug.Log("Anjay salah");
            
        }
    }


}
