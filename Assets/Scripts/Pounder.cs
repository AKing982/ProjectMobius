using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pounder : MonoBehaviour
{
    public Transform startMarker;
    public Transform endMarker;

    public float speed = 1.0f;
    private float beginTime;
    private float journeyLength;
   
    // Start is called before the first frame update
    void Start()
    {
        // Keep track of the time during movement
        beginTime = Time.time;

        // Calculate the journey length
        journeyLength = Vector3.Distance(startMarker.position, endMarker.position);
    }

    // Update is called once per frame
    void Update()
    {
        MovePounder();
    }

    void MovePounder()
    {
        // Distance is equal to the time elapsed times speed
        float distCovered = (Time.time - beginTime) * speed;

        // Fraction of journey completed equals distance divided by total distance
        float fractionJourney = distCovered / journeyLength;

        // Set the position of our Slider as a fraction of the distance between markers.
        transform.position = Vector3.Lerp(startMarker.position, endMarker.position, Mathf.PingPong(fractionJourney, 0.8f));
    }

}
