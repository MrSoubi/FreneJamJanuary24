using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using NUnit.Framework.Interfaces;

public class DragonController : MonoBehaviour
{
    Animator m_Animator;
    Rigidbody m_Rigidbody;
    AudioSource m_AudioSource;

    [SerializeField] private float moveSpeed;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private float growthRate;

    private int rank;

    // Start is called before the first frame update
    void Start()
    {
        m_Animator = GetComponent<Animator>();
        m_Rigidbody = GetComponent<Rigidbody>();
        m_AudioSource = GetComponent<AudioSource>();

        rank = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.GetRank() > rank)
        {
            //Debug.Log(GameManager.GetRank());
            rank = GameManager.GetRank();
            Grow();
        }

        ManageAnimations();
    }

    private void FixedUpdate()
    {
        ManageMovement(true);
    }

    private void ManageAnimations()
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
    }

    private void ManageMovement(bool newMethod)
    {
        if (newMethod)
        {
            if (Input.GetKey(KeyCode.Z)) // Move forward
            {
                m_Rigidbody.velocity = moveSpeed * Time.deltaTime * transform.forward * (1.0f + rank / 2.0f);
            }
            else if (Input.GetKey(KeyCode.S)) // Move backward
            {
                m_Rigidbody.velocity = - moveSpeed * Time.deltaTime * transform.forward * (1.0f + rank / 2.0f);
            }
            else
            {
                m_Rigidbody.velocity = Vector3.zero;
            }
        }
        else
        {
            if (Input.GetKey(KeyCode.Z)) // Move forward
            {
                m_Rigidbody.MovePosition(transform.position + moveSpeed * Time.deltaTime * transform.forward * (1.0f + rank / 2.0f));
            }
            if (Input.GetKey(KeyCode.S)) // Move backward
            {
                m_Rigidbody.MovePosition(transform.position - moveSpeed * Time.deltaTime * transform.forward * (1.0f + rank / 2.0f));
            }
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

    public void Grow()
    {
        transform.DOScale(transform.localScale * growthRate, 1);
        m_AudioSource.Play();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.GetComponent<Destroyable>() != null)
        {
            if (collision.collider.GetComponent<Destroyable>().GetRank() <= rank - 2)
            {
                collision.collider.GetComponent<Destroyable>().Demolish();
            }
        }
    }
}