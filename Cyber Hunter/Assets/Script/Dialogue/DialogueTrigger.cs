using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue[] dialogue;
    public GameObject button;
    int index = 0;


    private void Awake()
    {
        DialogueManager.Instance.DialogueSelanjutnyaPunyaManager = DialogSelanjutnya;
    }
    public void TriggerDialogue()
    {
        //FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
        DialogueManager.Instance.StartDialogue(dialogue[index]);

    }

    public void DialogSelanjutnya()
    {
        if(index + 1 < dialogue.Length)
        {
            index++;
            TriggerDialogue();
        }
        
        else
        {
            DialogueManager.Instance.TurnOffTxtBox();
            if(PlayerPrefs.GetInt("LevelAt") < SceneManager.GetActiveScene().buildIndex)
            {
                PlayerPrefs.SetInt("LevelAt", SceneManager.GetActiveScene().buildIndex);

                button.SetActive(true);
            }
        }

    }

    public void NewDialogue()
    {
        index = 0;
        TriggerDialogue();
    }

}
