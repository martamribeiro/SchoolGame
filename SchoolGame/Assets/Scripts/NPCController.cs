using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem.XR;

public class NPCController : MonoBehaviour
{
    public Transform[] walkablePlanes; // The walkable planes (rooms, corridors, etc.)
    private NavMeshAgent agent;
    private Vector3 targetPosition;

    public AudioClip[] FootstepAudioClips;
    [Range(0, 1)] public float FootstepAudioVolume = 0.5f;

    private AudioSource audioSource; // Add an AudioSource component to your NPC

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        if (agent == null)
        {
            Debug.LogError("NavMeshAgent not found on NPC.");
            enabled = false; // Disable the script if there's no NavMeshAgent.
            return;
        }
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        audioSource.spatialBlend = 1.0f; // Make the audio 3D spatialized
        SetRandomDestination();
    }

    void Update()
    {
        if (agent != null && agent.isActiveAndEnabled && agent.isOnNavMesh && !agent.pathPending && agent.remainingDistance < 0.1f)
        {
            SetRandomDestination();
        }
        // Check for footstep sounds here
        if (agent.velocity.magnitude > 0.1f && !audioSource.isPlaying)
        {
            PlayRandomFootstepSound();
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

    void PlayRandomFootstepSound()
    {
        if (FootstepAudioClips.Length > 0)
        {
            int randomIndex = Random.Range(0, FootstepAudioClips.Length);
            audioSource.clip = FootstepAudioClips[randomIndex];
            audioSource.volume = FootstepAudioVolume;
            audioSource.Play();
        }
    }

    private void OnFootstep(AnimationEvent animationEvent)
    {
        //ignore
    }
}
