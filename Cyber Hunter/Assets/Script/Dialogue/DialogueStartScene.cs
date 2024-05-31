using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueStartScene : MonoBehaviour
{
    private DialogueTrigger trigger;
    private void Start()
    {
        
        trigger = GetComponent<DialogueTrigger>();
        Debug.Log("Oke Start");
        StartCoroutine(StartScene());
    }

    public IEnumerator StartScene()
    {
        Debug.Log("Oke");
        yield return new WaitForSeconds(0.2f);
        
        trigger.TriggerDialogue();
    }

    

}
