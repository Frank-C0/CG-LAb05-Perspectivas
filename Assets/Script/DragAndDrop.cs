using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    private bool _mouseState;
    private GameObject target;
    public GameObject plataforma;
    public Vector3 screenSpace;
    public Vector3 offset;

    // Use this for initialization
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        //aumentar escala
        //clic izquierdo
        if (Input.GetMouseButtonDown(0))
        {

            RaycastHit hitInfo;
            target = GetClickedObject(out hitInfo);
            if (target != null)
            {
                _mouseState = true;
                AgrandarEscala();
                screenSpace = Camera.main.WorldToScreenPoint(target.transform.position);
                offset = target.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenSpace.z));
            }
        }else

        //reducir escala
        //clic derecho
        if (Input.GetMouseButtonDown(1))
        {

            RaycastHit hitInfo;
            target = GetClickedObject(out hitInfo);
            //revisa si se escogio un objeto y que este no este cerca o atras de la camara
            if (target != null && target.transform.position.z - (16 * target.transform.localScale.x) > transform.position.z)
            {
                _mouseState = true;
                ReducirEscala();
                screenSpace = Camera.main.WorldToScreenPoint(target.transform.position);
                offset = target.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenSpace.z));
            }
        }

        if (Input.GetMouseButtonUp(0) || Input.GetMouseButtonUp(1))
        {
            _mouseState = false;
        }
        if (_mouseState)
        {
            //keep track of the mouse position
            var curScreenSpace = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenSpace.z);

            //convert the screen mouse position to world point and adjust with offset
            var curPosition = Camera.main.ScreenToWorldPoint(curScreenSpace) + offset;

            //update the position of the object in the world
            target.transform.position = curPosition;
        }
    }


    public void AgrandarEscala()
    {

        target.transform.localScale = target.transform.localScale * 1.2f;
        
        Vector3 pos = target.transform.position;
        pos.z = pos.z + (4f* target.transform.localScale.x);
        target.transform.position = pos;

    }

    public void ReducirEscala()
    {

        target.transform.localScale = target.transform.localScale * 0.8f;

        Vector3 pos = target.transform.position;
        pos.z = pos.z - (6f * target.transform.localScale.x);
        target.transform.position = pos;

    }

    GameObject GetClickedObject(out RaycastHit hit)
    {
        GameObject target = null;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray.origin, ray.direction * 10, out hit))
        {
            target = hit.collider.gameObject;
        }

        //para que la plataforma no se escoja con el mouse
        if (target == plataforma)
            return null;

        return target;
    }
}

