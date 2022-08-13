using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPlayer : MonoBehaviour
{
    [SerializeField] GameObject player;

    private void OnCollisionEnter(Collision collision)
    {
       if(collision.gameObject.CompareTag("Player"))
        {
            // Destroy the player gameObject
            Destroy(player.gameObject);
        }
    }
}
