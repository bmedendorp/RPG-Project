using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPG.Movement;

namespace RPG.Combat
{
    public class Fighter : MonoBehaviour
    {
        [SerializeField]private float weaponRange = 2f;

        private Mover mover;
        private Transform target;

        private void Awake()
        {
            mover = GetComponent<Mover>();
        }

        private void Update()
        {
            if (target != null)
            {
                if (Vector3.Distance(transform.position, target.position) > weaponRange)
                {
                    mover.MoveTo(target.position);
                }
                else
                {
                    mover.Stop();
                }
            }
        }

        public void Attack(CombatTarget combatTarget)
        {
            target = combatTarget.transform;
        }

        public void Cancel()
        {
            target = null;
        }
    }
}