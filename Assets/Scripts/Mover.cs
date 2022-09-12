using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class Mover : MonoBehaviour
{
    [SerializeField] Transform target;

    RichAI richAI;

    private void Awake()
    {
        richAI = GetComponent<RichAI>();
    }

    private void Update()
    {
        richAI.destination = target.position;
    }
}
