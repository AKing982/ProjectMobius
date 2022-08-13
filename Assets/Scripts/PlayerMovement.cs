using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody player;
    [SerializeField] float verticalSpeed = 2500f;
    [SerializeField] float boost = 50f;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Rigidbody>();
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
            Thrust();
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
        }

        // If the player holds down the left arrow key or A key, the Player ship will rotate left
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.LeftArrow))
        {
            RotateShip(-boost);
        }
    }

    void RotateShip(float rotationFactor)
    {
      
        transform.Rotate(Vector3.right * rotationFactor * Time.deltaTime);
        
    }

    void Thrust()
    {
        player.AddRelativeForce(Vector3.up * verticalSpeed * Time.deltaTime);
    }

    void Boost()
    {
        player.velocity = Vector3.up * boost * Time.deltaTime; 
    }

  
}
