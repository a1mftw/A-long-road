using System;
using UnityEngine;
using UnityEngine.SceneManagement;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Text nameText;
    public Text dialogueText;

    public Animator animator;
    private string sentence = "";

    private Queue <string> sentences;

    void Start()
    {
        sentences = new Queue<string>();
    }

   public void StartDialogue (Dialogue dialogue)
    {
        animator.SetBool("IsOpen", true);

        Debug.Log("Starting conversation with " + dialogue.name);

        nameText.text = dialogue.name;

        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            
            sentences.Enqueue(sentence);
        }

       // DisplayNextSentence();
    } 

    public void DisplayNextSentence (bool quest = false)
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            if (quest)
                StartQuest();
           
            return;
        }

       sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence());
    }

    private void StartQuest()
    {
        SceneManager.LoadScene(3);
    }

    public void TypeNewSentence()
    {
        sentence = sentences.Dequeue();
        StartCoroutine(TypeSentence());
    }

     IEnumerator TypeSentence ()
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(0.03f);
        }
    }

    public void EndDialogue()
    {
        animator.SetBool("IsOpen", false);
        FindObjectOfType<PlayerBehaviour>().inDialogue = false;
        sentences.Clear();
    }
}
 