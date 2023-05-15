using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MusicChange : MonoBehaviour
{
    public AudioMixerSnapshot baseSnapshot;
    public AudioMixerSnapshot tension;
    public AudioMixerSnapshot combat;

    public float transitionTimeFast = 0.25f;
    public float transitionTimeSlow = 1.00f;

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Tension")
            tension.TransitionTo(transitionTimeSlow);

        if (collider.gameObject.tag == "IndoorMusic")
            combat.TransitionTo(transitionTimeFast);
    }

    void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.tag == "IndoorMusic")
            tension.TransitionTo(transitionTimeFast);

        if (collider.gameObject.tag == "Tension")
            baseSnapshot.TransitionTo(transitionTimeSlow);
    }
}