using UnityEngine;
using UnityEngine.AI;

public class WorldInteraction : MonoBehaviour
{
    private NavMeshAgent _playerAgent;

    private void GetInteraction()
    {
        Ray interactionRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit interactionInfo;

        if (!Physics.Raycast(interactionRay, out interactionInfo, Mathf.Infinity)) return;

        GameObject interactedObject = interactionInfo.collider.gameObject;

        if (interactedObject.CompareTag("Interactable"))
        {
            interactedObject.GetComponent<Interactable>().MoveToInteraction(_playerAgent);
        }
        else
        {
            _playerAgent.stoppingDistance = 0;
            _playerAgent.destination = interactionInfo.point;
        }
    }

    private void Start()
    {
        _playerAgent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && !UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject())
        {
            GetInteraction();
        }
    }
}