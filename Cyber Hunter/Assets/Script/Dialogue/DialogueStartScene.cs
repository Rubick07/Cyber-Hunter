using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueStartScene : MonoBehaviour
{
    public DialogueTrigger trigger;
    private void Start()
    {
        trigger = FindObjectOfType<DialogueTrigger>();
        trigger.NewDialogue();
        
    }

}
