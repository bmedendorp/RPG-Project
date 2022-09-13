using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class Mover : MonoBehaviour
{
    [SerializeField] LayerMask layerMask;
    [SerializeField] GameObject playerModel;

    RichAI richAI;
    Animator animator;

    private void Awake()
    {
        richAI = GetComponent<RichAI>();
        animator = playerModel.GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            MoveToCursor();
        }

        UpdateAnimation();
    }

    private void MoveToCursor()
    {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit, float.MaxValue, layerMask))
            {
                richAI.destination = hit.point;
            }
    }

    private void UpdateAnimation()
    {
        Vector3 localVelocity = transform.InverseTransformDirection(richAI.velocity);
        animator.SetFloat("forwardSpeed", localVelocity.z);
    }
}
