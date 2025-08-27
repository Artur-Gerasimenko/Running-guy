using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsScript : MonoBehaviour
{
    public bool MoveForward;
    public bool Turn;

    [SerializeField] private float Speed = 1;

    [SerializeField] private float TurnToX;
    [SerializeField] private float TurnToY;
    [SerializeField] private float TurnToZ;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (MoveForward) GoForward();
        if (Turn) TurnAxises();
    }
    private void TurnAxises()
    {
        transform.Rotate(TurnToX, TurnToY, TurnToZ);
    }
    private void GoForward()
    {
        transform.position += (transform.forward * Speed) * Time.deltaTime;
    }
}
