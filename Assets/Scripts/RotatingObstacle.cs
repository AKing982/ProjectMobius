using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingObstacle : MonoBehaviour
{
    private Rigidbody obstacle;

    private float xAngle = 2f;
    private float yAngle = 0f;
    private float zAngle = 0f;

    Vector3 m_EulerAngleVelocity;


    // Start is called before the first frame update
    void Start()
    {
        // Initialize our rigidbody component 
        obstacle = GetComponent<Rigidbody>();

        // Set the angular velocity of our rigidbody
        m_EulerAngleVelocity = new Vector3(xAngle, yAngle, zAngle);
    }

    // Update is called once per frame
    void Update()
    {
        // First check if the Rigidbody component is null
        if(obstacle != null)
        {
            // If the tag is set to T obstacle, we will set the rotation of our T obstacle to rotate 5 deg/sec along the x-axis
            if(obstacle.CompareTag("TObstacle"))
            {
                Quaternion quaternionRotation = Quaternion.Euler(m_EulerAngleVelocity * Time.fixedDeltaTime);
                obstacle.MoveRotation(obstacle.rotation * quaternionRotation);
            }
        }
        else
        {
            Debug.Log("Rigidbody component no longer exists!");
        }
         
    }
}
