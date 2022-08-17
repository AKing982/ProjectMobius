using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] AudioClip thrustAudio;
    [SerializeField] float verticalSpeed = 2500f;
    [SerializeField] float boost = 50f;
    [SerializeField] ParticleSystem MainEngine;
    [SerializeField] ParticleSystem RightBooster;
    [SerializeField] ParticleSystem LeftBooster;

    Rigidbody player; 
    AudioSource m_AudioSource;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Rigidbody>();
        m_AudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerControls();
        PlayerRotate();
        PlayerThrust();
    }

    void PlayerControls()
    {
        // If the player holds down the Up arrow key, move the player upwards
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            if (!m_AudioSource.isPlaying)
            {
                m_AudioSource.PlayOneShot(thrustAudio);
            }

            if(!MainEngine.isPlaying)
            {
                MainEngine.Play();
            }

            if (!LeftBooster.isPlaying)
            {
                LeftBooster.Play();
            }

            if (!RightBooster.isPlaying)
            {
                RightBooster.Play();
            }


            player.AddRelativeForce(Vector3.up * verticalSpeed * Time.deltaTime);
        }
        else
        {
            m_AudioSource.Stop();
            MainEngine.Stop();
            LeftBooster.Stop();
            RightBooster.Stop();    
        }

    }

    void PlayerThrust()
    {

        if (Input.GetKeyDown(KeyCode.RightShift) || Input.GetKeyDown(KeyCode.LeftShift))
        {
            Boost();
        }
    }

    void PlayerRotate()
    {
        // If the player holds down the right arrow key or D key, the Player ship will rotate right
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            RotateShip(boost);
            if (!MainEngine.isPlaying)
            {
                MainEngine.Play();
            }

            if(!LeftBooster.isPlaying)
            {
                LeftBooster.Play();
            }

            if(!RightBooster.isPlaying)
            {
                RightBooster.Play();
            }

        }

        // If the player holds down the left arrow key or A key, the Player ship will rotate left
        else if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            RotateShip(-boost);
            if (!MainEngine.isPlaying)
            {
                MainEngine.Play();
            }
            if (!LeftBooster.isPlaying)
            {
                LeftBooster.Play();
            }

            if (!RightBooster.isPlaying)
            {
                RightBooster.Play();
            }

        }
        
    }

    void RotateShip(float rotationFactor)
    {
      
        transform.Rotate(Vector3.right * rotationFactor * Time.deltaTime);
        
    }

    void Boost()
    {
        player.velocity = Vector3.up * boost * Time.deltaTime; 
    }

}
