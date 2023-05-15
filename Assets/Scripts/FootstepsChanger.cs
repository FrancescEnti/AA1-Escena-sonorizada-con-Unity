using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootstepsChanger : MonoBehaviour
{
    public AudioClip[] Grass;
    public AudioClip[] Dirt;
    public AudioClip[] PathWalk;
    public AudioClip[] DriveWay;

    public string material;

    void PlayFootstep()
    {
        AudioSource aSource = GetComponent<AudioSource>();
        aSource.volume = Random.Range(0.9f, 1.0f);
        aSource.pitch = Random.Range(0.8f, 1.2f);

        switch(material)
        {
            case "Grass":
                if (Grass.Length > 0) aSource.PlayOneShot(Grass[Random.Range(0, Grass.Length)]);
                break;
            case "Dirt":
                if (Dirt.Length > 0) aSource.PlayOneShot(Dirt[Random.Range(0, Dirt.Length)]);
                break;
            case "PathWalk":
                if (PathWalk.Length > 0) aSource.PlayOneShot(PathWalk[Random.Range(0, PathWalk.Length)]);
                break;
            case "DriveWay":
                if (DriveWay.Length > 0) aSource.PlayOneShot(DriveWay[Random.Range(0, DriveWay.Length)]);
                break;
        }

        print(material);
    }

    private void OnCollisionEnter(Collision collision)
    {
        switch(collision.gameObject.tag)
        {
            case "Grass":
            case "Dirt":
            case "PathWalk":
            case "DriveWay":
                material = collision.gameObject.tag;
                break;
            default:
                break;
        }
    }
}
