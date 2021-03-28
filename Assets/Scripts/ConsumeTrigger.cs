using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ConsumeTrigger : MonoBehaviour
{
    public UnityEvent<GameObject> OnObjectConsumed;

    private void OnTriggerExit(Collider other)
    {
        OnObjectConsumed.Invoke(other.attachedRigidbody.gameObject);
    }
}
