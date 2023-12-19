using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody rb;
    AudioSource audioSource;
    [SerializeField] float thruster = 1000f;
    [SerializeField] float rotationthrust = 100f;
    [SerializeField] AudioClip audiomain;
    [SerializeField] ParticleSystem boosterparticles;
    [SerializeField] ParticleSystem Lbooster;
    [SerializeField] ParticleSystem Rbooster;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        thrust();
        rotating();
    }
    void thrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            if (!boosterparticles.isPlaying)
            {
                boosterparticles.Play();
            }
            rb.AddRelativeForce(Vector3.up * thruster * Time.deltaTime);
            if (!audioSource.isPlaying)
            {
                audioSource.PlayOneShot(audiomain);
            }

        }
        else
        {
            audioSource.Stop();
            boosterparticles.Stop();
        }
    }
    void rotating()
    {
        if(Input.GetKey(KeyCode.A))
        {
            if (!Lbooster.isPlaying)
            {
                Lbooster.Play();
                boosterparticles.Stop();
            }
            ApplyRotation(rotationthrust);
        }
        else if(Input.GetKey(KeyCode.D))
        {
            if (!Rbooster.isPlaying)
            {
                Rbooster.Play();
                boosterparticles.Stop();
            }
            ApplyRotation(-rotationthrust);
        }
        else { Lbooster.Stop(); Rbooster.Stop(); }
    }

    void ApplyRotation(float rotationForward)
    {
        rb.freezeRotation = true;
        transform.Rotate(Vector3.forward * rotationForward * Time.deltaTime);
        rb.freezeRotation = false;
    }
}
