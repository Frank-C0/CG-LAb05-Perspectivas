using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextVisibilityController : MonoBehaviour
{
    public TextMeshProUGUI textObject;
    private void Start()
    {
        UpdateTextVisibility();
    }
    private void Update()
    {
        UpdateTextVisibility();
    }
    public void EnableText()
    {
        textObject.gameObject.SetActive(true);
    }
    public void DisableText()
    {
        textObject.gameObject.SetActive(false);
    }
    public void UpdateTextVisibility()
    {
        if (SingletonPlayer.Instance.points >= 5)
        {
            EnableText();
        }
        else
        {   

            DisableText();
        }
    }
    [ContextMenu("Actualizar Visibilidad del Texto")]
    public void UpdateTextVisibilityFromInspector()
    {
        UpdateTextVisibility();
    }
}