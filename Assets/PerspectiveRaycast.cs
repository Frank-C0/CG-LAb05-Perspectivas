using System.Collections;
using System.Collections.Generic;
using UnityEditor.XR;
using UnityEngine;

public class PerspectiveRaycast : MonoBehaviour
{
    public float offset; 
    public LayerMask layerMask;
    public float maxDistance = 10f;

    public bool isColliding = false; 
    public Vector3 distanceToCollision; 
    public Transform collisionObject;

    public bool lastColl = false;

    void Update()
    {
        lastColl = isColliding;
        Quaternion quaternionDirection = Quaternion.Euler(45, 45, 0);
        Vector3 origin = transform.position - quaternionDirection * Vector3.forward * offset;
        Vector3 direction = quaternionDirection * Vector3.forward * maxDistance;

        // make a raycast from ofset to position
        RaycastHit hit;
        if (Physics.Raycast(origin, direction, out hit, maxDistance, layerMask))
        {
            if (hit.collider.tag == "top") { 
                isColliding = true;
                distanceToCollision = hit.point - transform.position;
                collisionObject = hit.transform;
            }
            else
            {
                isColliding = false;
                distanceToCollision = Vector3.zero;
                collisionObject = null;
            }
            //Debug.Log("Colliding with: " + hit.collider.tag);

        }
        else
        {
            isColliding = false;
            distanceToCollision = Vector3.zero;
            collisionObject = null;
        }
    }

    void OnDrawGizmos()
    {
        if (transform == null)
            return;

        Gizmos.color = Color.red;
        Quaternion quaternionDirection = Quaternion.Euler(45, 45, 0);
        Vector3 origin = transform.position - quaternionDirection * Vector3.forward * offset;
        Vector3 direction = quaternionDirection * Vector3.forward * maxDistance;

        Gizmos.DrawRay(origin, direction);
    }
}