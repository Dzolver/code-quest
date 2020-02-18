using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Collider))]
public class BattleLoad : MonoBehaviour
{
    public GameObject prompt;
    public bool inRange;
    private GameObject player;
    private void Start()
    {
        prompt.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 10)
        {
            player = other.gameObject;
            inRange = true;
            prompt.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 10)
        {
            inRange = false;
            prompt.SetActive(false);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && inRange)
        {
            player.GetComponent<CharacterController>().enabled = false;
            player.GetComponent<movement>().enabled = false;
            SceneManager.LoadScene("BattleScene");            
        }
    }
}

