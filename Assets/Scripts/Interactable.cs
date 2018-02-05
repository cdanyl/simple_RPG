using UnityEngine;
using UnityEngine.AI;

public class Interactable : MonoBehaviour
{
    private NavMeshAgent _playerAgent;
    private bool _hasInteracted;

    public virtual void MoveToInteraction(NavMeshAgent playerAgent)
    {
        _hasInteracted = false;
        _playerAgent = playerAgent;
        _playerAgent.stoppingDistance = 3f;
        _playerAgent.destination = transform.position;
    }

    public virtual void Interact()
    {
        Debug.Log("Interacting with base class");
    }

    private void Update()
    {
        if (_hasInteracted || _playerAgent == null || _playerAgent.pathPending) return;

        if (_playerAgent.remainingDistance >= _playerAgent.stoppingDistance) return;

        _hasInteracted = true;
        Interact();
    }
}