using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeechBubble : MonoBehaviour
{
    public Text text;
    public Animator animator;

    public void DestroySpeechBubble()
    {
        Destroy(gameObject);
    }

}

