using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TailWag : MonoBehaviour
{
    Boid boid;
    public float velocity;
    public float speed;
    public float maxRot;

    private void Start()
    {
        boid = GetComponentInParent<Boid>();
        //defaultRot = transform.rotation;
    }

    private void Update()
    {
        Wag();
    }

    void Wag()
    {
        velocity = Mathf.RoundToInt(boid.velocity.magnitude);
        transform.localEulerAngles = new Vector3(0, maxRot * Mathf.Sin(Time.time * (speed + velocity)), 0);
    }
}
