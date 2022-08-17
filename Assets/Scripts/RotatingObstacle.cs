using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingObstacle : MonoBehaviour
{
    private Rigidbody obstacle;

    private float xAngle = 5f;
    private float yAngle = 0f;
    private float zAngle = 0f;

    public Transform xAngleStart;
    public Transform yAngleStart;
    private float timeCount = 0;
    [SerializeField] float rotationSpeed = 0.01f;

    private float startTime;
    private float HoveringObstacleJourney;
    [SerializeField] float incrementObstacleRotation = 0.5f;

    Vector3 m_EulerAngleVelocity;


    // Start is called before the first frame update
    void Start()
    {
        // Initialize our rigidbody component 
        obstacle = GetComponent<Rigidbody>();

        // Set the angular velocity of our rigidbody
        m_EulerAngleVelocity = new Vector3(xAngle, yAngle, zAngle);

        // Get our Begin Time
        startTime = Time.time;

        // Get the journey Length
        HoveringObstacleJourney = Vector3.Distance(xAngleStart.position,yAngleStart.position);
    }

    // Update is called once per frame
    void Update()
    {
        // Call our Method to Rotate our Obstacles
        RotateObstacles(obstacle);
    }

    void RotateObstacles(Rigidbody RotatingObstacle)
    {
        // First check if the Rigidbody component is null
        if (RotatingObstacle != null)
        {
            // If the tag is set to T obstacle, we will set the rotation of our T obstacle to rotate 5 deg/sec along the x-axis
            if (RotatingObstacle.CompareTag("TObstacle") || RotatingObstacle.CompareTag("Obstacle"))
            {
                Quaternion quaternionRotation = Quaternion.Euler(m_EulerAngleVelocity * Time.fixedDeltaTime);
                RotatingObstacle.MoveRotation(RotatingObstacle.rotation * quaternionRotation);
            }

            if (RotatingObstacle.CompareTag("HalfRotatingObs"))
            {
                float distanceCovered = (Time.time - startTime) * rotationSpeed;

                float fractionOfJourney = distanceCovered / HoveringObstacleJourney;

                RotatingObstacle.rotation = Quaternion.Lerp(xAngleStart.rotation, yAngleStart.rotation, Mathf.PingPong(fractionOfJourney, incrementObstacleRotation));
                timeCount += timeCount * Time.deltaTime;
            }


        }
        else
        {
            Debug.Log("Rigidbody component no longer exists!");
        }
    }
}
