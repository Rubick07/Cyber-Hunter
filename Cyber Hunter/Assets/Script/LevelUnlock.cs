using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelUnlock : MonoBehaviour
{

    public Button[] Level;

    private void Start()
    {
        PlayerPrefs.DeleteAll();
        int levelAt = PlayerPrefs.GetInt("LevelAt", 2);
        Debug.Log(levelAt);

        for(int i = 0; i < Level.Length; i++)
        {

            if(i + 2 > levelAt)
            {
                Level[i].interactable = false;
            }

        }
    }



}
