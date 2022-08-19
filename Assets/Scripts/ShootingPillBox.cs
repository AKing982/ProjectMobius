using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingPillBox : MonoBehaviour
{
    [SerializeField]  GameObject[] projectiles;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Shoot()
    {
        // Generate a random number between 0 and the length of projectiles Array
        int projectileIndex = Random.Range(0, projectiles.Length);

        // Instantiate the projectile at the position and rotation of this transform.
        Instantiate(projectiles[projectileIndex], transform.position, transform.rotation);
    }
}
