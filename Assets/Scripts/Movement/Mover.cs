using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using RPG.Combat;

namespace RPG.Movement
{
    public class Mover : MonoBehaviour
    {
        RichAI richAI;
        Animator animator;
        Fighter fighter;

        private void Awake()
        {
            richAI = GetComponent<RichAI>();
            animator = GetComponent<Animator>();
            fighter = GetComponent<Fighter>();
        }

        private void Update()
        {
            UpdateAnimation();
        }

        public void StartMoveAction(Vector3 destination)
        {
            fighter.Cancel();
            MoveTo(destination);
        }

        public void MoveTo(Vector3 destination)
        {
            richAI.destination = destination;
            richAI.isStopped = false;
        }

        public void Stop()
        {
            richAI.isStopped = true;
        }

        private void UpdateAnimation()
        {
            Vector3 localVelocity = transform.InverseTransformDirection(richAI.velocity);
            animator.SetFloat("forwardSpeed", localVelocity.z);
        }
    }
}