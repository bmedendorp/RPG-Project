using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPG.Movement;
using RPG.Core;

namespace RPG.Combat
{
    public class Fighter : MonoBehaviour, IAction
    {
        [SerializeField] private float weaponRange = 3f;
        [SerializeField] private float timeBetweenAttacks = 1f;

        private Animator animator;
        private Mover mover;
        private ActionScheduler actionScheduler;
        private Transform target;
        private float timeSinceLastAttack;

        private void Awake()
        {
            animator = GetComponent<Animator>();
            mover = GetComponent<Mover>();
            actionScheduler = GetComponent<ActionScheduler>();
        }

        private void Update()
        {
            timeSinceLastAttack += Time.deltaTime;

            if (target == null) return;
    
            if (!IsInRange())
            {
                mover.MoveTo(target.position);
            }
            else
            {
                mover.Cancel();
                AttackBehavior();
            }
        }

        private void AttackBehavior()
        {
            if (timeSinceLastAttack > timeBetweenAttacks)
            {
                animator.SetTrigger("attack");
                timeSinceLastAttack = 0;
            }
        }

        public void Attack(CombatTarget combatTarget)
        {
            actionScheduler.StartAction(this);
            target = combatTarget.transform;
        }

        private bool IsInRange()
        {
            return Vector3.Distance(transform.position, target.position) < weaponRange;
        }

        public void Cancel()
        {
            target = null;
        }

        private void Hit()
        {

        }
    }
}