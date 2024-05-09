using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    public Texture2D crosshairTexture;
    public AudioClip pistolShotClip;
    public ParticleSystem gunFlare;
    public float range = 20.0f;

    private Rect crosshairPos;
    private AudioSource audioSource;
    
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        crosshairPos = new Rect((Screen.width - crosshairTexture.width) / 2,
            (Screen.height - crosshairTexture.height) / 2,
            crosshairTexture.width, crosshairTexture.height);

        audioSource = GetComponent<AudioSource>();
        audioSource.clip = pistolShotClip;
    }

    private void OnGUI()
    {
        GUI.DrawTexture(crosshairPos, crosshairTexture);
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Ray ray = new Ray(transform.parent.position, transform.parent.forward);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.tag == "Enemy" && hit.distance < range)
                {
                    Debug.Log("Enemy hit!");
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
