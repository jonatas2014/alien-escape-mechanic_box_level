using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadPoint : MonoBehaviour
{
    private Menu _menu;

    // Start is called before the first frame update
    void Start()
    {
        _menu = FindObjectOfType<Menu>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Box")
        {
 
          
            if (_menu != null)
            {
                _menu.OpenDefeatPanel();
                Time.timeScale = 0f;
            }

        }

    }
}
