using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class CarSoundController : MonoBehaviour
{
    public AudioMixer audioMixer;
    public AudioClip engineStart;
    private AudioSource audioSource;
    private Rigidbody rb;
    private float previousVelocity = 1f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioMixer.SetFloat("drivingVolume", 0.0001f);
        audioMixer.SetFloat("idleVolume", 1);
        audioSource = GetComponent<AudioSource>(); 
        audioSource.PlayOneShot(engineStart);
    }

    // Update is called once per frame
    void Update()
    {
        if(previousVelocity <= 0.5 && rb.velocity.magnitude > 0.5){
            StartCoroutine(FadeMixerGroup.StartFade(audioMixer, "drivingVolume", 2, 1));
            StartCoroutine(FadeMixerGroup.StartFade(audioMixer, "idleVolume", 2, 0));
        }

        if(previousVelocity > 0.5 && rb.velocity.magnitude <= 0.5){
            StartCoroutine(FadeMixerGroup.StartFade(audioMixer, "idleVolume", 2, 1));
            StartCoroutine(FadeMixerGroup.StartFade(audioMixer, "drivingVolume", 2, 0));
        }

        previousVelocity = rb.velocity.magnitude;
    }
}
