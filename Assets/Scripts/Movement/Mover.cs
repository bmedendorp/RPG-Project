using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

namespace RPG.Movement
{
    public class Mover : MonoBehaviour
    {
        RichAI richAI;
        Animator animator;

        private void Awake()
        {
            richAI = GetComponent<RichAI>();
            animator = GetComponent<Animator>();
        }

        private void Update()
        {
            UpdateAnimation();
        }

        public void MoveToPoint(Vector3 destination)
        {
            richAI.destination = destination;
        }

        private void UpdateAnimation()
        {
            Vector3 localVelocity = transform.InverseTransformDirection(richAI.velocity);
            animator.SetFloat("forwardSpeed", localVelocity.z);
        }
    }
}