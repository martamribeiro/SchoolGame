using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCController : MonoBehaviour
{
    public Transform[] walkablePlanes; // The walkable planes (rooms, corridors, etc.)
    private NavMeshAgent agent;
    private Vector3 targetPosition;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        SetRandomDestination();
    }

    void Update()
    {
        if (!agent.pathPending && agent.remainingDistance < 0.1f)
        {
            SetRandomDestination();
        }
    }

    void SetRandomDestination()
    {
        int randomIndex = Random.Range(0, walkablePlanes.Length);
        targetPosition = GetRandomPointInPlane(walkablePlanes[randomIndex]);
        agent.SetDestination(targetPosition);
    }

    Vector3 GetRandomPointInPlane(Transform plane)
    {
        Bounds bounds = plane.GetComponent<Collider>().bounds;
        Vector3 randomPoint = new Vector3(
            Random.Range(bounds.min.x, bounds.max.x),
            transform.position.y,
            Random.Range(bounds.min.z, bounds.max.z)
        );
        return randomPoint;
    }
}
