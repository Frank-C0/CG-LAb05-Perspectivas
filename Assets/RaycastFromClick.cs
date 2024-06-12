using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class RaycastFromClick : MonoBehaviour
{
    public Camera orthoCamera;
    private RaycastHit hitInfo; 
    

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Input.mousePosition;
            Vector3 worldPos = orthoCamera.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, orthoCamera.nearClipPlane));

            Ray ray = orthoCamera.ScreenPointToRay(mousePos);
            Debug.DrawRay(ray.origin, ray.direction * 1000, Color.green, 20f);

            if (Physics.Raycast(ray, out hitInfo))
            {
                Debug.DrawRay(ray.origin, ray.direction * hitInfo.distance, Color.red, 1.0f);
                RotateOnClick receiver = hitInfo.collider.GetComponent<RotateOnClick>();
                if (receiver != null)
                {
                    receiver.RotateRight();
                }
            }
        }
    }
}