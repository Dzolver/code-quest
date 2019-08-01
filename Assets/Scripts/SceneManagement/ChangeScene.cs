using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public string exitScene;
    public Vector3 exitSpecific;
    public CameraClearFlags clearFlags;

    public Animator fade;

    void OnTriggerEnter(Collider other)
    {
        // If the player object hits the door trigger collider
        if (other.gameObject.tag == "Player")
        {
            // Start the coroutine to load the exitScene specified in the Editor
            // SceneManager.LoadScene(exitScene);
            StartCoroutine(LoadAsync(exitScene, other.gameObject));
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

    IEnumerator LoadAsync(string scene, GameObject player)
    {
        // Disable the movement script and CharacterController to prevent erratic movement while changing scenes
        player.GetComponent<CharacterController>().enabled = false;
        player.GetComponent<movement>().enabled = false;

        // Start screen fade to black
        fade.SetBool("FadeStart", true);

        // Start loading the scene asynchronously
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(scene);

        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {

            // If the scene is loaded
            if (asyncLoad.progress >= 0.9f)
            {

                // Set the background clearing flags, as specified in the editor
                Camera.main.clearFlags = clearFlags;

                // Set the player object to a new position so that it doesn't hit the exit door collider of the exitScene and go back
                player.GetComponent<Transform>().SetPositionAndRotation(exitSpecific, player.transform.rotation);

                // Re-enable the movement script and CharacterController to allow movement again
                player.GetComponent<CharacterController>().enabled = true;
                player.GetComponent<movement>().enabled = true;

                // Reset fade animation
                fade.SetBool("FadeStart", true);
            }

            yield return null;
        }
    }

}
