using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
            other.GetComponent<Destroyable>().OnHit(transform.root.gameObject, 1);
        }
    }
}
