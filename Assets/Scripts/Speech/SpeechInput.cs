using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeechInput : MonoBehaviour
{
    public SpeechBubble speechBubblePrefab;

    public InputField inputField;

    SpeechBubble activeSpeechBubble;

    public VerticalLayoutGroup speechContainer;
    public ScrollRect scrollRect;


    public void Update()
    {

        //spawning bubble if none exists and text is input
        if (inputField.text.Length > 0)
        {
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
            }
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
