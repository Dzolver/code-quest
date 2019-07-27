using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagement : MonoBehaviour
{
    // The player Prefab should be assigned to this variable in the editor
    public GameObject playerPrefab;
    public Sprite defSprite;
    private SpriteRenderer sprite_renderer;
    void Start()
    {
        // If the player object is not already in the scene (for e.g. entering from another scene)
        if (!GameObject.Find(playerPrefab.name))
        {
            // Instantiate the player object, and
            GameObject player = Instantiate(playerPrefab);
            sprite_renderer = player.GetComponent<SpriteRenderer>();
            sprite_renderer.sprite = defSprite;
            // Set its name to player, so that doesn't get named something like player(Clone)
            player.name = playerPrefab.name;
        }
    }
}
