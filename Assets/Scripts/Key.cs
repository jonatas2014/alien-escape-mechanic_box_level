using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;

public class Key : MonoBehaviour
{
    private Door _door;

    private void Start()
    {
        _door = FindObjectOfType<Door>();
        if (_door == null)
        {
            Debug.LogWarning("No Door on the scene, please add Door Prefab");
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            if (_door != null)
            {
                _door.Open();
            }

            gameObject.SetActive(false);
        }
    }
}
