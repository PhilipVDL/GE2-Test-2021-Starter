using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogDropBall : MonoBehaviour
{
    Arrive arrive;
    public GameObject ballCarry;
    public float dropDist;

    private void Start()
    {
        arrive = GetComponent<Arrive>();
    }

    private void Update()
    {
        DropBall();
    }

    void DropBall()
    {
        if (arrive.targetGameObject.CompareTag("MainCamera") && ballCarry.transform.childCount > 0)
        {
            float distance;
            distance = Vector3.Distance(transform.position, arrive.targetPosition);
            if (distance <= dropDist)
            {
                ballCarry.transform.DetachChildren();
            }
        }
    }
}