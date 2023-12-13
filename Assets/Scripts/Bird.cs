using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//INHERITANCE
public class Bird : Animal
{
    public GameObject wallLeft;
    public GameObject wallRight;

    Rigidbody animalRb;
    float speedBound = 2f;
    Vector3 leftWallTarget = new Vector3(-50, 10, 0);
    Vector3 rigWallTarget = new Vector3(-50, 10, 0);
    bool isFlyRight = false;
    // Start is called before the first frame update
    void Start()
    {
        Speed = speedBound;
        isFlyRight = false;
        animalRb = GetComponent<Rigidbody>();
    }
    // POLYMORPHISM
    private void Fly()
    {
        Vector3 wallPosition = wallLeft.transform.position;
        if (isFlyRight )
        {
            wallPosition = wallRight.transform.position;
        }
        Vector3 lookDirection = (wallPosition - transform.position).normalized;
        animalRb.AddForce(lookDirection * Speed);
    }
    // Update is called once per frame
    void Update()
    {
        Fly();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            isFlyRight = !isFlyRight;
        }
    }
}
