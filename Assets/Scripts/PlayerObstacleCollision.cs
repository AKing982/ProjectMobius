using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerObstacleCollision : MonoBehaviour
{
    [SerializeField] Rigidbody player;

    // When the player collides with an obstacle, freeze the rotation of our player
    private void OnCollisionEnter(Collision collision)
    {
        if(gameObject.CompareTag("Player"))
        {
            player.freezeRotation = true;
        }
    }
}
