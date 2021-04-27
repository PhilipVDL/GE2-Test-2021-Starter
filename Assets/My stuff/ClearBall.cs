using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearBall : MonoBehaviour
{
    private void Start()
    {
        Destroy(gameObject, 5);
    }
}