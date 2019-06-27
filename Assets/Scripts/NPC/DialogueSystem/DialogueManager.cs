using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    //if the dialgue UI is being shown
    public bool isActive;
    private Queue<string> sentences;

    [HideInInspector]
    public Canvas canvas;
    public Text dialogueBoxText;
    public Image npcImage;
    public Text npcName;
    public Text npcDescriptionText;
    public static DialogueManager Instance {
        get; private set; }
    private void Start()
    {
        sentences = new Queue<string>();
        canvas = GetComponentInChildren<Canvas>();
        canvas.enabled = false;
    }
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    public void StartDialogue(Dialogue dialogue, NPCDetails npcDetails)
    {
        Debug.Log("Started Conversation with" + dialogue.name);
        canvas.enabled = true;
        sentences.Clear();

        npcImage.sprite = npcDetails.image;
        //npcDescriptionText.text = npcDetails.npcDescription;
        npcName.text = npcDetails.npcName;

        //get all the sentences from the dialogue
        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }
        DisplayNextSentence();
    }
    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string nextSentence = sentences.Dequeue();
        Debug.Log(nextSentence);
        dialogueBoxText.text = nextSentence;
    }

    void EndDialogue()
    {
        canvas.enabled = false;
    }
}
