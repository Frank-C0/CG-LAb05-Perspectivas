using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoinToObject : MonoBehaviour
{
    public PlayerController playerController;

    public float maxDistance = 0.2f;
    public bool isColliding = false;
    public LayerMask layerMask;
    public Vector3 distanceToCollision;

    // Update is called once per frame
    void Update()
    {
    }

    public void verify()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, maxDistance, layerMask))
        {
            if (hit.collider.tag == "top")
            {
                isColliding = true;
                distanceToCollision = hit.point - transform.position;
                playerController.SetParentToCollider(hit.collider);
            }
            else
            {
                isColliding = false;
                distanceToCollision = Vector3.zero;
            }
            //Debug.Log("Colliding with: " + hit.collider.tag);
        }
        else
        {
            isColliding = false;
            distanceToCollision = Vector3.zero;
        }
    }

    // Draw the ray in the editor
    void OnDrawGizmos()
    {
        if (transform == null)
            return;
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, Vector3.down * maxDistance);
    }
}