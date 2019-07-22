using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public string exitScene;
    public Vector3 exitSpecific;
    public CameraClearFlags clearFlags;

    void OnTriggerEnter(Collider other)
    {
        // If the player object hits the door trigger collider
        if (other.gameObject.tag == "Player")
        {
            // Disable the movement script and CharacterController to prevent erratic movement while changing scenes
            other.GetComponent<CharacterController>().enabled = false;
            other.GetComponent<movement>().enabled = false;

            // Load the exitScene and set the clearing method, as specified in the Editor
            SceneManager.LoadScene(exitScene);
            Camera.main.clearFlags = clearFlags;

            // Set the player object to a new position so that it doesn't hit the exit door collider of the exitScene and go back
            other.GetComponent<Transform>().SetPositionAndRotation(exitSpecific, other.transform.rotation);

            // Re-enable the movement script and CharacterController to allow movement again
            other.GetComponent<CharacterController>().enabled = true;
            other.GetComponent<movement>().enabled = true;
        }
    }

    void Start()
    {
        // Set simple error messages when errors are anticipated
        if (exitScene == "")
        {
            Debug.LogError("exitScene variable on door object " + this.gameObject.name + "not set.");
        }
        if (clearFlags == 0)
        {
            Debug.LogWarning("clearFlags variable on door object " + this.gameObject.name + "not set.");
        }
    }

}
