using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonController : MonoBehaviour
{
    Animator m_Animator;
    Rigidbody m_Rigidbody;

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
        // Careful, the target detection is not really good, should use the head as the origin of the raycast for more realistic behaviour
        if (Input.GetMouseButtonDown(0))
        {
            m_Animator.SetTrigger("basicAttack");
            RaycastHit hit;
            
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 15.0f))
            {
                if (hit.collider.GetComponent<Building>() != null)
                {
                    hit.collider.gameObject.GetComponent<Building>().OnHit();
                }
            }
        }


        if (Input.GetKey(KeyCode.Z)) // Move forward
        {
            m_Rigidbody.MovePosition(transform.position + Time.deltaTime * transform.forward * 100.0f);
        }
        if (Input.GetKey(KeyCode.S)) // Move backward
        {
            m_Rigidbody.MovePosition(transform.position - Time.deltaTime * transform.forward * 100.0f);
        }
        if (Input.GetKey(KeyCode.Q)) // Rotate left
        {
            m_Rigidbody.MoveRotation(Quaternion.AngleAxis(transform.rotation.eulerAngles.y - 360.0f * Time.deltaTime, Vector3.up));
        }
        if (Input.GetKey(KeyCode.D)) // Rotate right
        {
            m_Rigidbody.MoveRotation(Quaternion.AngleAxis(transform.rotation.eulerAngles.y + 360.0f * Time.deltaTime, Vector3.up));
        }
    }
}
