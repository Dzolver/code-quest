using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SpeechInput : MonoBehaviour
{
    public SpeechBubble speechBubblePrefab;

    public InputField inputField;

    SpeechBubble activeSpeechBubble;

    public VerticalLayoutGroup speechContainer;
    public ScrollRect scrollRect;

    public Inventory inventory;
    public movement movement;
    public CharacterController characterController;

    public bool finishedTyping = true;

    private void Awake()
    {
        SceneManager.sceneLoaded += RefreshCanvas;
    }
    public void RefreshCanvas(Scene scene, LoadSceneMode loadSceneMode)
    {
        GetComponent<Canvas>().enabled = false;
        GetComponent<Canvas>().enabled = true;
    }

    public void Update()
    {
        //spawning bubble if none exists and text is input

        if (inputField.text.Length > 0)
        {
            finishedTyping = false;

            if (!activeSpeechBubble)
                SpawnSpeechBubble();
            activeSpeechBubble.text.text = inputField.text;


            //if get key down, fade active speech bubble, set next text to ""
            if (Input.GetKeyDown(KeyCode.Return))
            {
                activeSpeechBubble.animator.SetTrigger("Fade Out");
                activeSpeechBubble = null;
                inputField.text = "";
                inputField.Select();
                inputField.ActivateInputField();
                finishedTyping = true;
            }
        }
        else
        {
            if (!finishedTyping)
            {
                activeSpeechBubble.text.text = "";
                activeSpeechBubble.animator.Play("Fade In Immediate");
                activeSpeechBubble = null;
                inputField.text = "";
                finishedTyping = true;
            }
        }

        if (inputField.isFocused)
        {
            movement.recieveInput = false;
            inventory.recieveInput = false;
            characterController.enabled = false;
        }
        else
        {
            movement.recieveInput = true;
            inventory.recieveInput = true;
            characterController.enabled = true;
        }
    }

    public void SpawnSpeechBubble()
    {
        activeSpeechBubble = Instantiate(speechBubblePrefab, speechContainer.transform);
        activeSpeechBubble.transform.SetAsLastSibling();
        activeSpeechBubble.animator.SetTrigger("Fade In");

        float spacing = 1.2f;
        //speechContainer.spacing = 1.2f;
        scrollRect.verticalNormalizedPosition = 1;
        speechContainer.spacing = spacing;
    }

}
