using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GainPoint : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            SingletonPlayer.Instance.points++;
            Destroy(gameObject);
        }
    }
}
