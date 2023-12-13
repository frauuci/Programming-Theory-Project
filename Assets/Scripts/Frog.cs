using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frog : Animal
{
    Rigidbody animalRb;
    [SerializeField]
    private float jumpHeight = 50;
    float groundHeight;
    void Start()
    {
        Speed =30f;
        groundHeight = transform.position.y; 
        animalRb = GetComponent<Rigidbody>();
    }
    void Pingpong()
    {

        transform.position = new Vector3(transform.position.x, Mathf.PingPong(Time.time, jumpHeight- groundHeight) + groundHeight, transform.position.z);
       
    }
    // Update is called once per frame
    void Update()
    {
        Pingpong();
    }

}
