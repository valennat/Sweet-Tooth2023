using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float velocidad = 50.0f;
    [SerializeField] private Animator animator;
    [SerializeField] private AudioClip[] audioClips; 
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        MovimientoPersonaje();
    }

    void MovimientoPersonaje()
    {
        float dirHorizontal = Input.GetAxis("Horizontal");
        float horizontal = dirHorizontal * velocidad;

        if (horizontal != 0)
        {
            if (!audioSource.isPlaying || audioSource.time == audioSource.clip.length)
            {
                playRandClip();
            }
            if (horizontal < 0)
            {

                if (!animator.GetCurrentAnimatorStateInfo(0).IsName("caminata_raton"))
                {
                    animator.Play("caminata_raton");
                }
            }
            else if (Mathf.Abs(horizontal) > 0.1f)
            {

                if (!animator.GetCurrentAnimatorStateInfo(0).IsName("caminata_izq"))
                {
                    animator.Play("caminata_izq");
                }
            }
        }        
        else
        {
            if (!animator.GetCurrentAnimatorStateInfo(0).IsName("ratoncito_idle"))
            {
                animator.Play("ratoncito_idle");
            }
        }

        float movimientoHorizontal = dirHorizontal * velocidad * Time.deltaTime;
        transform.position += new Vector3(movimientoHorizontal, 0, 0);

        float clampedX = Mathf.Clamp(transform.position.x, -189.08f, -125.19f);
        transform.position = new Vector3(clampedX, transform.position.y, transform.position.z);
        
    }

    private void playRandClip() {
        AudioClip randAudio = audioClips[Random.Range(0, audioClips.Length)];

        float randPitch = Random.Range(2.2f, 2.9f);

        audioSource.clip = randAudio;
        audioSource.pitch = randPitch;
        audioSource.Play();
        audioSource.time = 0;
    }
}
