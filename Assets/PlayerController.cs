using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float velocidadMovimiento = 4f;
    // perspective raycast for each 4 direction
    public PerspectiveRaycast perspectiveRaycastUp;
    public PerspectiveRaycast perspectiveRaycastDown;
    public PerspectiveRaycast perspectiveRaycastLeft;
    public PerspectiveRaycast perspectiveRaycastRight;

    // border raycast for each 4 direction
    public BorderRaycast borderRaycastUp;
    public BorderRaycast borderRaycastDown;
    public BorderRaycast borderRaycastLeft;
    public BorderRaycast borderRaycastRight;

    public BorderRaycast joinable;

    public Vector3 movimiento;

    public bool canMove = true;

    public bool maintainDown = true;

    
    void Update()
    {
        
        if (!canMove)
        {
            Transform parent = transform.parent;
            transform.SetParent(null);
            transform.rotation = Quaternion.Euler(0, 0, 0);
            transform.SetParent(parent);
            return;
        }
        if (Input.GetKeyDown(KeyCode.U))
        {
            maintainDown = false;
        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            maintainDown = true;
        }


        transform.SetParent(joinable.collisionObject, true);
        float movimientoHorizontal = Input.GetAxis("Horizontal");
        float movimientoVertical = Input.GetAxis("Vertical"); 
        movimiento = new Vector3(movimientoHorizontal, 0, movimientoVertical);

        
        movimiento = movimiento.normalized * velocidadMovimiento * Time.deltaTime;
        if (movimiento.x > 0.001)
        {
            if (!maintainDown)
            {
                if (perspectiveRaycastRight.distanceToCollision.magnitude > 0.2f)
                    transform.Translate(perspectiveRaycastRight.distanceToCollision, Space.World);
            }
            if (!borderRaycastRight.isColliding)
            {
                movimiento.x = 0;
                // move object to collision distance
                if (perspectiveRaycastRight.isColliding)
                {
                    if (maintainDown)
                    {
                        if (perspectiveRaycastRight.distanceToCollision.magnitude > 0.2f && perspectiveRaycastRight.lastColl)
                            transform.Translate(perspectiveRaycastRight.distanceToCollision, Space.World);
                    }
                    else
                    {
                        if (perspectiveRaycastRight.distanceToCollision.magnitude > 0.2f)
                            transform.Translate(perspectiveRaycastRight.distanceToCollision, Space.World);
                    }
                }
            }
            
        }
        else if (movimiento.x < -0.001)
        {
            if (!maintainDown)
            {
                if (perspectiveRaycastLeft.distanceToCollision.magnitude > 0.2f)
                    transform.Translate(perspectiveRaycastLeft.distanceToCollision, Space.World);
            }


            if (!borderRaycastLeft.isColliding)
            {
                movimiento.x = 0;
                // move object to collision distance
                if (perspectiveRaycastLeft.isColliding)
                {
                    if (maintainDown)
                    {
                        if (perspectiveRaycastLeft.distanceToCollision.magnitude > 0.2f && perspectiveRaycastLeft.lastColl)
                            transform.Translate(perspectiveRaycastLeft.distanceToCollision, Space.World);
                    } else
                    {
                        if (perspectiveRaycastLeft.distanceToCollision.magnitude > 0.2f)
                            transform.Translate(perspectiveRaycastLeft.distanceToCollision, Space.World);
                    }

                }
            }
        }
        if (movimiento.z > 0.001)
        {
            if (!maintainDown)
            {
                if (perspectiveRaycastUp.distanceToCollision.magnitude > 0.2f)
                    transform.Translate(perspectiveRaycastUp.distanceToCollision, Space.World);
            }
            

            if (!borderRaycastUp.isColliding)
            {
                movimiento.z = 0;
                if (perspectiveRaycastUp.isColliding)
                {
                    if (maintainDown)
                    {
                        if (perspectiveRaycastUp.distanceToCollision.magnitude > 0.2f && perspectiveRaycastUp.lastColl)
                            transform.Translate(perspectiveRaycastUp.distanceToCollision, Space.World);
                    }
                    else
                    {
                        if (perspectiveRaycastUp.distanceToCollision.magnitude > 0.2f)
                            transform.Translate(perspectiveRaycastUp.distanceToCollision, Space.World);
                    }
                }
            }
        }
        else if (movimiento.z < -0.001)
        {

            if (!maintainDown)
            {
                if (perspectiveRaycastDown.distanceToCollision.magnitude > 0.2f)
                    transform.Translate(perspectiveRaycastDown.distanceToCollision, Space.World);
            }

            if (!borderRaycastDown.isColliding)
            {
                movimiento.z = 0;
                if (perspectiveRaycastDown.isColliding)
                {
                    if (maintainDown)
                    {
                        if (perspectiveRaycastDown.distanceToCollision.magnitude > 0.2f && perspectiveRaycastDown.lastColl)
                            transform.Translate(perspectiveRaycastDown.distanceToCollision, Space.World);
                    }
                    else
                    {
                        if (perspectiveRaycastDown.distanceToCollision.magnitude > 0.2f)
                            transform.Translate(perspectiveRaycastDown.distanceToCollision, Space.World);
                    }
                }
            }
        }


        transform.Translate(movimiento, Space.World);

    }



    public void SetParentToCollider(Collider targetCollider)
    {
        if (targetCollider != null)
        {
            Debug.LogWarning("cambiooooo");
            Transform targetParent = targetCollider.transform.parent;

            Vector3 globalPosition = transform.position;
            Vector3 globalScale = transform.lossyScale;

            transform.SetParent(targetParent, true);
        }
        else
        {
            Debug.LogWarning("El collider proporcionado es nulo.");
        }
    }

}