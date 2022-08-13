using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Booster : MonoBehaviour
{
    public Rigidbody player;
    [SerializeField] GameObject booster;
    private float BoostSpeed = 200f;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        BoostMeUpScotty();
    }

    void BoostMeUpScotty()
    {
        if(booster.CompareTag("Booster") && booster != null)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
            {
                player.AddRelativeForce(Vector3.up * BoostSpeed * Time.deltaTime, ForceMode.Acceleration);
            }
        }
    }
}
