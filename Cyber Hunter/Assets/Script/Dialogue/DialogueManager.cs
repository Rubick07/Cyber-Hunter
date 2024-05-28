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
    public Button DialogueButton;
    public static DialogueManager Instance;
    public delegate void NextDialogue();
    public NextDialogue DialogueSelanjutnyaPunyaManager;
    public bool NextScene;
    public bool StartGame;


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

        DialogueButton.image.enabled = true;
        //DialogueButton.enabled = true;
        nameText.text = dialogue.name;
        Character.enabled = true;
        Character.sprite = dialogue.CharacterImage;
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
            yield return new WaitForSeconds(0.01f);
        }
    }
    
    public void EndDialogue()
    {
        Debug.Log("End Dialogue");
        StopAllCoroutines();
        //Character.color = new Color(255, 255, 255, 0.5f);
        DialogueButton.image.enabled = false;
        DialogueText.text = "";
        nameText.text = "";
        DialogueSelanjutnyaPunyaManager?.Invoke();

    }

    public void TurnOffTxtBox()
    {
        Character.enabled = false;
        DialogueButton.image.enabled = false;
        DialogueText.text = "";
        nameText.text = "";
    }


        
}
