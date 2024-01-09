using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonController : MonoBehaviour
{
    Animator m_Animator;
    Rigidbody m_Rigidbody;

    [SerializeField] private float moveSpeed;
    [SerializeField] private float rotationSpeed;


    // Start is called before the first frame update
    void Start()
    {
        m_Animator = GetComponent<Animator>();
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // Run animation
        if (Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.Q) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D))
        {
            m_Animator.SetBool("isRunning", true);
        }
        if (!(Input.GetKey(KeyCode.Z) || Input.GetKey(KeyCode.Q) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D)))
        {
            m_Animator.SetBool("isRunning", false);
        }

        // Basic attack
        if (Input.GetMouseButtonDown(0) && !m_Animator.GetCurrentAnimatorStateInfo(0).IsName("Basic Attack") && !m_Animator.GetCurrentAnimatorStateInfo(0).IsName("Tail Attack"))
        {
            m_Animator.SetTrigger("basicAttack");
        }

        // Tail attack
        if (Input.GetMouseButtonDown(1) && !m_Animator.GetCurrentAnimatorStateInfo(0).IsName("Tail Attack") && !m_Animator.GetCurrentAnimatorStateInfo(0).IsName("Basic Attack"))
        {
            m_Animator.SetTrigger("tailAttack");
        }

        if (Input.GetKey(KeyCode.Z)) // Move forward
        {
            m_Rigidbody.MovePosition(transform.position + Time.deltaTime * transform.forward * moveSpeed);
        }
        if (Input.GetKey(KeyCode.S)) // Move backward
        {
            m_Rigidbody.MovePosition(transform.position - Time.deltaTime * transform.forward * moveSpeed);
        }
        if (Input.GetKey(KeyCode.Q)) // Rotate left
        {
            m_Rigidbody.MoveRotation(Quaternion.AngleAxis(transform.rotation.eulerAngles.y - rotationSpeed * Time.deltaTime, Vector3.up));
        }
        if (Input.GetKey(KeyCode.D)) // Rotate right
        {
            m_Rigidbody.MoveRotation(Quaternion.AngleAxis(transform.rotation.eulerAngles.y + rotationSpeed * Time.deltaTime, Vector3.up));
        }
    }

    public void Grow(float rate)
    {
        transform.localScale *= rate;
    }
}
