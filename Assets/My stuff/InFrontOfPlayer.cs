using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InFrontOfPlayer : MonoBehaviour
{
    public GameObject player;
    public Vector3 pos;
    public int distance;

    private void Update()
    {
        InFront();
        OfPlayer();
    }

    void InFront()
    {
        Vector3 playerPos = player.transform.position;
        Vector3 playerForward = player.transform.forward;
        Vector3 inFront = playerPos + (playerForward * distance);

        pos = new Vector3(inFront.x, 0, inFront.z);

    }

    void OfPlayer()
    {
        transform.position = pos;
    }
}