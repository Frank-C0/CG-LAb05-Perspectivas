using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateOnClick : MonoBehaviour
{
    private bool rotating = false;
    public float rotationSpeed = 90f;
    public void RotateRight()
    {
        if (rotating)
        {
            return;
        }
        StartCoroutine(RotateCoroutine(90f));
    }

    // Coroutine para manejar la rotaci�n suave
    private IEnumerator RotateCoroutine(float angle)
    {
        rotating= true;
        SingletonPlayer.Instance.playerController.canMove = false;
        // �ngulo inicial
        Quaternion startRotation = transform.parent.rotation;
        // �ngulo objetivo
        Quaternion endRotation = Quaternion.Euler(transform.parent.eulerAngles + new Vector3(0, angle, 0));

        // Variable de tiempo
        float elapsedTime = 0f;

        // Calcula la duraci�n de la rotaci�n basada en la velocidad de rotaci�n
        float duration = angle / rotationSpeed;

        while (elapsedTime < duration)
        {
            // Interpola suavemente entre la rotaci�n inicial y la final
            transform.parent.rotation = Quaternion.Slerp(startRotation, endRotation, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null; // Espera hasta el siguiente frame
        }

        // Asegura que la rotaci�n final sea exactamente la deseada
        transform.parent.rotation = endRotation;
        rotating = false;
        SingletonPlayer.Instance.playerController.canMove = true;
    }
}
