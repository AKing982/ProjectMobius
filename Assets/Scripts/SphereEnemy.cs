using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereEnemy : MonoBehaviour
{
    [SerializeField] Transform playerTarget;
    [SerializeField] float step = 10.0f;

    // Update is called once per frame
    void Update()
    {
        FollowPlayer();
    }

    void FollowPlayer()
    {
        transform.LookAt(playerTarget);
        transform.position = Vector3.MoveTowards(transform.position, playerTarget.position, Time.deltaTime * step);
    }
}
