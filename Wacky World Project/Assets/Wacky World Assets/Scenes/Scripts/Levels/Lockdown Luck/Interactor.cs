using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactor : MonoBehaviour
{
    private List<IInteractable> interactables = new List<IInteractable>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && interactables.Count > 0)
        {
            IInteractable closest = FindClosest();
            closest?.Interact(this);
        }
    }

    private IInteractable FindClosest()
    {
        float treshHold = 60 * Mathf.Deg2Rad;
        float bestAngle = float.PositiveInfinity;
        IInteractable selected = interactables[0];

        for(int i = 0; i < interactables.Count; i++)
        {
            float angle = Quaternion.Angle(Quaternion.Euler(transform.forward), Quaternion.Euler(((interactables[i] as MonoBehaviour).transform.position - transform.position).normalized));
            if (angle < bestAngle)
            {
                bestAngle = angle;
                selected = interactables[i];
            }
        }
        Debug.Log("Best: " + bestAngle);
        return bestAngle > treshHold ? null:selected;
           
    }

    private void OnTriggerEnter(Collider other)
    {
        IInteractable interactable = other.GetComponent<IInteractable>();
        if (interactable != null)
            interactables.Add(interactable);

        Debug.Log("Enter: " + other.name);
    }

    private void OnTriggerExit(Collider other)
    {
        interactables.Remove(other.GetComponent<IInteractable>());
        Debug.Log("Exit: " + other.name);
    }
}
