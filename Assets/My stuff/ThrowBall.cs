using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowBall : MonoBehaviour
{
    public GameObject ballPrefab;
    public GameObject thrown;
    public float throwForce;

    DogFSM dogState;

    private void Start()
    {
        dogState = GameObject.FindGameObjectWithTag("Dog").GetComponent<DogFSM>();
    }

    private void Update()
    {
        BallThrow();
    }

    void BallThrow()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //spawn
            dogState.barked = false;
            Vector3 inFront = transform.position + transform.forward;
            Quaternion facing = Quaternion.Euler(transform.rotation.eulerAngles);
            thrown = Instantiate(ballPrefab, inFront, facing);

            //throw
            Rigidbody rb = thrown.GetComponent<Rigidbody>();
            rb.AddForce(rb.transform.forward * throwForce);

            //fetch
            dogState.SetState("fetch");
        }
    }
}
