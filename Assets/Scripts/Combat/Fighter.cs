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
        [SerializeField] private float damageAmt = 5f;

        private Animator animator;
        private Mover mover;
        private ActionScheduler actionScheduler;
        private Health target;
        private float timeSinceLastAttack = Mathf.Infinity;

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

            if (target.isDead)
            {
                Cancel();
                return;
            }
    
            if (!IsInRange())
            {
                mover.MoveTo(target.transform.position);
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
                transform.LookAt(target.transform);

                StartAttack();
                timeSinceLastAttack = 0;
            }
        }

        private void StartAttack()
        {
            animator.ResetTrigger("cancelAttack");
            animator.SetTrigger("attack");
        }

        public void Attack(GameObject combatTarget)
        {
            actionScheduler.StartAction(this);
            target = combatTarget.GetComponent<Health>();
        }

        public bool CanAttack(GameObject combatTarget)
        {
            if (!combatTarget) return false;
            if (!combatTarget.TryGetComponent<Health>(out Health targetHealth)) return false;

            return !targetHealth.isDead;
        }

        private bool IsInRange()
        {
            if (target == null) return false;

            return Vector3.Distance(transform.position, target.transform.position) < weaponRange;
        }

        public void Cancel()
        {
            target = null;
            StopAttack();
        }

        private void StopAttack()
        {
            animator.ResetTrigger("attack");
            animator.SetTrigger("cancelAttack");
        }

        private void Hit()
        {
            if (!target) return;

            target.TakeDamage(damageAmt);
        }
    }
}