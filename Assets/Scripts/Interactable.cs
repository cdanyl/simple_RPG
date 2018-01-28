using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class Interactable : MonoBehaviour
{
    private NavMeshAgent _playerAgent;

    public virtual void MoveToInteraction(NavMeshAgent playerAgent)
    {
        this._playerAgent = playerAgent;
        playerAgent.stoppingDistance = 3f;
        playerAgent.destination = this.transform.position;

        Interact();
    }

    public virtual void Interact()
    {
        Debug.Log("Interacting with base class");
    }
}