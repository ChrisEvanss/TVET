using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Events;

public class Goal : MonoBehaviour
{
    public UnityEvent OnGoal;
    void OnTriggerEnter(Collider other)
    {
        // Check if onGoal event exists
        if (OnGoal != null)
        {
            // Invoke event
            OnGoal.Invoke();
        }

    }

}

