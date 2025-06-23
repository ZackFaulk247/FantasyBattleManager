using UnityEngine;
using Pathfinding;
using UnityEditor.Build.Reporting;

public class AIAgent : MonoBehaviour
{
    private AIPath path;
    [SerializeField] private float moveSpeed;
    [SerializeField] private Transform target;

    [SerializeField] private float stopDistanceThreshold;
    private float distanceToTarget;
    private void Start()
    {
        path = GetComponent<AIPath>();
    }
    private void Update()
    {
        path.maxSpeed = moveSpeed;
        distanceToTarget = Vector2.Distance(transform.position, target.position);
        if (distanceToTarget < stopDistanceThreshold)
        {
            path.destination = transform.position;
        }
        else
        { 
            path.destination = target.position;
        }
    }
}
