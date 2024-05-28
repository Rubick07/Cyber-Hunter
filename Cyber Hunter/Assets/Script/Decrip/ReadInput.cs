using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadInput : MonoBehaviour
{
    private string input;
    Decri Jawaban;

    private void Awake()
    {
        Jawaban = FindObjectOfType<Decri>();
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
        }
        else
        {
            Debug.Log("Anjay salah");
        }
    }


}
