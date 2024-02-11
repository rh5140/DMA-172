using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VanishOnApproach : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] Sprite vanishSprite; // sprite before turning into cloud
    SpriteRenderer spriteRenderer; // animal's sprite renderer
    Vector3 animalPosition;
    float distance;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animalPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(animalPosition, player.transform.position);
        if (distance < 10)
        {
            // swap to vanishSprite
        }

        if (distance < 7)
        {
            spriteRenderer.enabled = false;
        }
    }
}
