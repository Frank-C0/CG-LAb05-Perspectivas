using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SingletonPlayer : MonoBehaviour
{
    private static SingletonPlayer _instance;
    public int points = 0;
    [SerializeField] public PlayerController playerController;

    public static SingletonPlayer Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<SingletonPlayer>();
                if (_instance == null)
                {
                    GameObject singletonObject = new GameObject("MySingleton");
                    _instance = singletonObject.AddComponent<SingletonPlayer>();
                    DontDestroyOnLoad(singletonObject);
                }
            }
            return _instance;
        }
    }

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (_instance != this)
        {
            Destroy(gameObject);
        }
    }
}
