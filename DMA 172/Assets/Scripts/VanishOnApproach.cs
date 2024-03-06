using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// https://stackoverflow.com/questions/52998687/particle-system-is-not-playing-through-code

public class VanishOnApproach : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] Sprite vanishSprite; // sprite before turning into cloud
    [SerializeField] float threshold;
    [SerializeField] ParticleSystem particleSystem;
    float distance;
    SpriteRenderer spriteRenderer; // animal's sprite renderer
    Vector3 animalPosition;
    // add bool so doesn't keep emitting particle xd

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animalPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(animalPosition, player.transform.position);
        // if (distance < 10)
        // {
        //     spriteRenderer.sprite = vanishSprite;
        // }

        if (distance < threshold)
        {
            spriteRenderer.enabled = false;
            particleSystem.Emit(1);
            // particleSystem.Play();
        }
    }
}
