using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowBall : MonoBehaviour
{
    public GameObject ball;
    public Arrive dogArrive;
    public float throwForce;
    public AudioSource dogSource;

    private void Update()
    {
        BallThrow();
    }

    void BallThrow()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //spawn
            Vector3 inFront = transform.position + transform.forward;
            Quaternion facing = Quaternion.Euler(transform.rotation.eulerAngles);
            GameObject thrown = Instantiate(ball, inFront, facing);

            //throw
            Rigidbody rb = thrown.GetComponent<Rigidbody>();
            rb.AddForce(rb.transform.forward * throwForce);

            //fetch
            dogArrive.targetGameObject = thrown;
            dogSource.Play();

        }
    }
}
