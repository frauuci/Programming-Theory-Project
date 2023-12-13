using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//INHERITANCE
public class Rabbit : Animal
{
    Rigidbody animalRb;
    // Start is called before the first frame update
    void Start()
    {
        Speed = 1f;
        animalRb = GetComponent<Rigidbody>();
    }
    // POLYMORPHISM
    public override void Walk()
    {
        animalRb.AddForce(WalkingForce(), ForceMode.Impulse);
    }
    // Update is called once per frame
    void Update()
    {
        Walk();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            Speed *= -1;
        }
    }
}
