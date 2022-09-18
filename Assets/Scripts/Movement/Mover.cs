using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using RPG.Core;

namespace RPG.Movement
{
    public class Mover : MonoBehaviour, IAction
    {
        RichAI richAI;
        Animator animator;
        ActionScheduler actionScheduler;
        Health health;

        private void Awake()
        {
            richAI = GetComponent<RichAI>();
            animator = GetComponent<Animator>();
            actionScheduler = GetComponent<ActionScheduler>();
            health = GetComponent<Health>();
        }

        private void Update()
        {
            richAI.enabled = !health.isDead;
            
            UpdateAnimation();
        }

        public void StartMoveAction(Vector3 destination)
        {
            actionScheduler.StartAction(this);
            MoveTo(destination);
        }

        public void MoveTo(Vector3 destination)
        {
            richAI.destination = destination;
            richAI.isStopped = false;
        }

        public void Cancel()
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