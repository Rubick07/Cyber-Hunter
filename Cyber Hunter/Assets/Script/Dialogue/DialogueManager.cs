using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public Queue<string> sentences;

    public SpriteRenderer Character;
    public TMP_Text nameText;
    public TMP_Text DialogueText;
    public static DialogueManager Instance;
    public delegate void NextDialogue();
    public NextDialogue DialogueSelanjutnyaPunyaManager;


    void Start()
    {
        sentences = new Queue<string>();
    }

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            
        }
        else
        {
            Destroy(gameObject);
        }
    }


    public void StartDialogue(Dialogue dialogue)
    {
        //Debug.Log("Starting Conversation with" + dialogue.name);

        nameText.text = dialogue.name;
        Character.sprite = dialogue.CharacterImage;
        Character.color = new Color(255, 255, 255, 1f);
        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }


        DisplayNextSentences();
    }

    public void DisplayNextSentences()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentences(sentence));
        //DialogueText.text = sentence;

    }
    
    IEnumerator TypeSentences(string sentence)
    {
        DialogueText.text = "";
        foreach(char letter in sentence.ToCharArray())
        {
            DialogueText.text += letter;
            yield return null;
        }
    }
    
    public void EndDialogue()
    {
        Debug.Log("End Dialogue");
        Character.color = new Color(255, 255, 255, 0.5f);
        DialogueSelanjutnyaPunyaManager?.Invoke();
        //Character.color.a = 
    }




        
}
