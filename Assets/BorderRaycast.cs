using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BorderRaycast : MonoBehaviour
{
    public float maxDistance = 0.2f;
    public bool isColliding = false;
    public LayerMask layerMask;
    public Vector3 distanceToCollision;
    public float boxSize = 0.1f; // Tamaño del cubo
    public Transform collisionObject;

    
    void Update()
    {
        RaycastHit hit;
        if (Physics.BoxCast(transform.position, Vector3.one * (boxSize / 2), Vector3.down, out hit, Quaternion.identity, maxDistance, layerMask))
        {
            if (hit.collider.tag == "top")
            {
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

    // Draw the BoxCast in the editor
    void OnDrawGizmos()
    {
        if (transform == null)
            return;

        Gizmos.color = Color.red;
        Vector3 halfExtents = Vector3.one * (boxSize / 2);
        Gizmos.DrawWireCube(transform.position + Vector3.down * maxDistance / 2, new Vector3(boxSize, maxDistance, boxSize));
    }
}
