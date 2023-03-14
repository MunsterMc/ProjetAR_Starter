using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PushMachine : MonoBehaviour
{
    [SerializeField] private Transform inPoint;
    [SerializeField] private Transform outPoint;
    [SerializeField] private float speed = 1;
    private Vector3 pushDirection;

    private void Start()
    {
        //Vector AB = B-A, send object that collides along axis from point of entry to point of exit
        pushDirection = (outPoint.position - inPoint.transform.position).normalized;
    }
    private void OnCollisionEnter(Collision collision)
    {
        Rigidbody rb_object = collision.gameObject.GetComponent<Rigidbody>();
        //Apply velocity to object that collides
        rb_object.velocity = transform.TransformDirection(pushDirection * speed);
    }
}
