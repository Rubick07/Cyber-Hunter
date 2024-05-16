using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue[] dialogue;
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

    }

    public void NewDialogue()
    {
        index = 0;
        TriggerDialogue();
    }

}
