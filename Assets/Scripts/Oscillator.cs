using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillator : MonoBehaviour
{
    Vector3 startingposition;
    [SerializeField] Vector3 movementvector;
    [SerializeField][Range(0,1)] float movementfactor;
    [SerializeField] float period = 2f;

    // Start is called before the first frame update
    void Start()
    {
        startingposition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        oscillate();
    }
    void oscillate()
    {
        if(period <= Mathf.Epsilon) { return; }
        float cycles = Time.time / period;               //continuously growing over time
        const float tau = Mathf.PI * 2;                 //const value of 6.283
        float rawsinewave = Mathf.Sin(cycles * tau);   //going from -1 to 1
        movementfactor = (rawsinewave + 1f) / 2f;     //recalculate to go from 0 to 1 so its cleaner.
        Vector3 offset = movementvector * movementfactor;
        transform.position = startingposition + offset;
    }
}
