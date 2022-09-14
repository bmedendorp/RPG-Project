using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPG.Movement;

namespace RPG.Control
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] LayerMask layerMask;

        Mover mover;

        private void Awake()
        {
            mover = GetComponent<Mover>();
        }

        private void Update()
        {
            if (Input.GetMouseButton(0))
            {
                MoveToCursor();
            }
        }

        private void MoveToCursor()
        {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out RaycastHit hit, float.MaxValue, layerMask))
            {
                mover.MoveToPoint(hit.point);
            }
        }

    }
}