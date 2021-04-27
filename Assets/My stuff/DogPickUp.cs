using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogPickUp : MonoBehaviour
{
    Arrive arrive;
    public float pickDist;
    public GameObject ballCarry;

    private void Start()
    {
        arrive = GetComponent<Arrive>();
    }

    private void Update()
    {
        PickUp();
    }

    void PickUp()
    {
        if (arrive.targetGameObject.CompareTag("Ball"))
        {
            float distance;
            distance = Vector3.Distance(transform.position, arrive.targetPosition);
            if (distance <= pickDist)
            {
                arrive.targetGameObject.transform.SetParent(ballCarry.transform);
                arrive.targetGameObject.transform.position = ballCarry.transform.position;
                arrive.targetGameObject = Camera.main.gameObject;
            }
        }
    }
}