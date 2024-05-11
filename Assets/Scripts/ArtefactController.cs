using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ArtefactController : MonoBehaviour
{
    public ParticleSystem effect;
    
    private AudioSource audioSource;
    private BoxCollider triggerCollider;
    private MeshRenderer meshRenderer;
    private readonly float destroyDelay = 5.0f;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        triggerCollider = GetComponent<BoxCollider>();
        meshRenderer = GetComponent<MeshRenderer>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            triggerCollider.enabled = false;
            effect.Play();
            audioSource.Play();
            meshRenderer.enabled = false;
            GameController.instance.OnArtefactCollect();

            Destroy(gameObject, destroyDelay);
        }
    }

}
