using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    private SpriteRenderer _sprite;
    private BoxCollider2D _collider;
    private Menu _menu;

    private void Start()
    {
        _collider = GetComponent<BoxCollider2D>();
        _sprite = GetComponent<SpriteRenderer>();
        _menu = FindObjectOfType<Menu>();
        if (_menu == null)
        {
            Debug.LogWarning("No Canvas in the scene, please add Canvas Prefab");
        }
    }

    public void Open()
    {
        _collider.enabled = true;
        _sprite.color = Color.blue;
        
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            if (_menu != null)
            {
                _menu.OpenVictoryPanel();
                Time.timeScale = 0f;
            }
        }
    }

}
