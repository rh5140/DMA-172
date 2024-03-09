using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// https://stackoverflow.com/questions/52998687/particle-system-is-not-playing-through-code

public class VanishOnApproach : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] float threshold;
    [SerializeField] ParticleSystem particleSystem;
    AudioSource audioSource; // Audio Source
    float distance;
    SpriteRenderer spriteRenderer; // animal's sprite renderer
    Animator animator;
    Vector3 animalPosition;
    bool enteredRange = false;
    bool disappeared = false;

    void Start()
    {
        audioSource = player.GetComponent<AudioSource>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        animalPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(animalPosition, player.transform.position);

        // Replace with this OnTriggerEnter/ OnTriggerExit?
        if (distance < threshold + 8)
        {
            animator.SetBool("clouding", true);
            enteredRange = true;
            audioSource.volume = 0;
            audioSource.Pause();
        }
        else {
            if (enteredRange) {
                animator.SetBool("clouding", false);
                audioSource.UnPause();
                // audio volume to increase
                StartCoroutine(StartFade(audioSource, 2.5f, 1));
                enteredRange = false;
            }
        }

        if (distance < threshold && !disappeared)
        {
            spriteRenderer.enabled = false;
            particleSystem.Emit(1);
            disappeared = true;
        }
    }

    // https://johnleonardfrench.com/how-to-fade-audio-in-unity-i-tested-every-method-this-ones-the-best/
    public static IEnumerator StartFade(AudioSource audioSource, float duration, float targetVolume)
    {
        float currentTime = 0;
        float start = audioSource.volume;
        while (currentTime < duration)
        {
            currentTime += Time.deltaTime;
            audioSource.volume = Mathf.Lerp(start, targetVolume, currentTime / duration);
            yield return null;
        }
        yield break;
    }
}
