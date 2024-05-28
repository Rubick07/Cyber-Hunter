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


    private void Start()
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
            if(DialogueManager.Instance.NextScene == true) SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            if(DialogueManager.Instance.StartGame == true)
            {
                GameManager gameManager = FindAnyObjectByType<GameManager>().GetComponent<GameManager>();
                gameManager.enabled = true;
                gameManager.ActionMenu.SetActive(true);
                DialogueManager.Instance.StartGame = false;
            }

            if (button != null) button.SetActive(true);
            
        }

    }

    public void NewDialogue()
    {
        index = 0;
        TriggerDialogue();
    }

}
