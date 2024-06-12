using System.Collections;
using System.Collections.Generic;
using UnityEditor.XR;
using UnityEngine;

public class OrtographicPerspectiveRaycast : MonoBehaviour
{
    public Vector3 offset; // El offset desde la posici�n actual
    public Vector3 halfExtents; // Tama�o del cubo (la mitad de sus dimensiones totales)
    public LayerMask layerMask; // M�scara de capa para especificar las capas con las que queremos colisionar
    public float maxDistance = 10f; // La distancia m�xima del cubecast

    public bool isColliding = false; // Variable para saber si estamos colisionando con algo
    void Update()
    {
        Vector3 origin = transform.position + offset;
        Vector3 direction = transform.position - origin;

        RaycastHit hit;

        // Realizamos el cubecast
        if (Physics.BoxCast(origin, halfExtents, direction, out hit, transform.rotation, maxDistance, layerMask))
        {
            isColliding = true;
            // Aqu� puedes realizar la acci�n deseada al colisionar con algo en la capa espec�fica
            Debug.Log("Colisionado con: " + hit.collider.name);

            // Ejemplo de acci�n: desactivar el objeto con el que colisionamos
            // hit.collider.gameObject.SetActive(false);
        }
        else
        {
            isColliding = false;
        }
    }

    // M�todo para dibujar el cubo en el editor de Unity para visualizar el BoxCast
    void OnDrawGizmos()
    {
        if (transform == null)
            return;

        Gizmos.color = Color.red;
        Vector3 origin = transform.position + offset;
        Vector3 direction = (transform.position - origin).normalized * maxDistance;
        Gizmos.DrawRay(origin, direction);

        Gizmos.matrix = Matrix4x4.TRS(origin, transform.rotation, Vector3.one);
        Gizmos.DrawWireCube(Vector3.zero, halfExtents * 2);
    }
}