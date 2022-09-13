using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class Mover : MonoBehaviour
{
    [SerializeField] LayerMask layerMask;

    RichAI richAI;

    private void Awake()
    {
        richAI = GetComponent<RichAI>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            MoveToCursor();
        }
    }

    private void MoveToCursor()
    {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit, float.MaxValue, layerMask))
            {
                richAI.destination = hit.point;
            }
    }
}
