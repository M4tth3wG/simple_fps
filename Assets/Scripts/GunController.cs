using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    public AudioClip pistolShotClip;
    public ParticleSystem gunFlare;
    

    private AudioSource audioSource;
    private float range;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = pistolShotClip;
        range = GameController.instance.configuration.gunRange;
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1") && !GameController.instance.IsPaused)
        {
            Ray ray = new Ray(transform.parent.position, transform.parent.forward);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.tag == "Enemy" && hit.distance < range)
                {
                    Debug.Log("Enemy hit!");

                    EnemyController enemy = hit.transform.GetComponent<EnemyController>();
                    enemy?.OnHit();

                }
                else
                {
                    Debug.Log("Object is not an enemy!");
                }
            }
            else
            {
                Debug.Log("Out of range!");
            }

            Debug.DrawRay(transform.parent.position, range * transform.parent.forward, Color.cyan, 3.0f, false);
            audioSource.PlayOneShot(pistolShotClip);
            gunFlare.Play();
        }
    }
}
