using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Attach this script to any part of the dragon containing at least one trigger collider.
// The attack will work only if the dragon is currently in the "Tail Attack" animation state.

public class SC_TailAttack : MonoBehaviour
{
    Animator m_Animator;

    // Start is called before the first frame update
    void Start()
    {
        m_Animator = transform.root.GetComponent<Animator>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (m_Animator.GetCurrentAnimatorStateInfo(0).IsName("Tail Attack") && other.GetComponent<Destroyable>() != null)
        {
            other.GetComponent<Destroyable>().OnHit(1);
        }
    }
}
