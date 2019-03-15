using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Movement : MonoBehaviour
{

    public event MovementFinishedHandler OnMovementFinished;
    public delegate void MovementFinishedHandler();

    public float moveSpeed;
    
    [SerializeField] 
    private Transform target = null;

    [SerializeField] 
    private float terminationDistance = 0.01f;

    private bool shouldMove = false;
    private float squaredTerminationDistance;


    public void Start()
    {
        squaredTerminationDistance = terminationDistance * terminationDistance;
        StartMovement();
    }
   
    public void StartMovement()
    {
        shouldMove = true;
    }
    
    public void StopMovement()
    {
        shouldMove = false;
    }

    public void Update()
    {
        if (shouldMove)
        {
            if ((target.position - transform.position).sqrMagnitude > squaredTerminationDistance)
            {
                transform.position =
                    Vector3.MoveTowards(transform.position, target.position, Time.deltaTime * moveSpeed);
            }
            else
            {
                shouldMove = false;
                OnMovementFinished?.Invoke();
            }
        }
    }
}