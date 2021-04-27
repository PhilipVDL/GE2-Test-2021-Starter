using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogFSM : MonoBehaviour
{
    Arrive arrive;
    GameObject player;
    ThrowBall throwBall;
    public bool barked;
    public GameObject inFront;
    AudioSource source;
    GameObject ballCarry;

    public enum State
    {
        follow,
        fetch,
        retrieve
    }

    public State currentState;

    private void Start()
    {
        arrive = GetComponent<Arrive>();
        player = GameObject.FindGameObjectWithTag("MainCamera");
        throwBall = player.GetComponent<ThrowBall>();
        source = GetComponent<AudioSource>();
        ballCarry = GameObject.Find("ballAttach");

        currentState = State.follow;
    }

    private void Update()
    {
        switch (currentState)
        {
            case State.follow:
                FollowPlayer();
                break;
            case State.fetch:
                FetchBall();
                break;
            case State.retrieve:
                RetrieveBall();
                break;
            default:
                break;
        }
    }

    void FollowPlayer()
    {
        arrive.targetGameObject = inFront;
    }

    void FetchBall()
    {
        if (!barked)
        {
            source.Play();
            barked = true;
        }
        arrive.targetGameObject = throwBall.thrown;
        float distance;
        distance = Vector3.Distance(transform.position, arrive.targetPosition);
        if (distance <= 2)
        {
            arrive.targetGameObject.transform.SetParent(ballCarry.transform);
            arrive.targetGameObject.transform.position = ballCarry.transform.position;
            currentState = State.retrieve;
        }
    }

    void RetrieveBall()
    {
        arrive.targetGameObject = player;
        float distance;
        distance = Vector3.Distance(transform.position, arrive.targetGameObject.transform.position);
        if (distance <= 5)
        {
            ballCarry.transform.DetachChildren();
            currentState = State.follow;
        }
    }

    public void SetState(string stateName)
    {
        State parsedState = (State)System.Enum.Parse(typeof(State), stateName);
        currentState = parsedState;
    }
}
