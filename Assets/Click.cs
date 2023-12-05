using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.ReorderableList;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Click : MonoBehaviour
{
    float speed; // speed of the object
    Vector2 lastMousePos; // position of mouse
    bool moving; // check if object is moving

    void Start()
    {
        speed = 10f; // setting the speed variable
    }

    // Update is called once per frame
    void Update()
    {
        // if left button is clicked
        if (Input.GetMouseButtonDown(0))
        {
            // change the value of lastMousePos to the current position of the mouse
            lastMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            // check if the object is moving
            moving = true;
        }

        // if object is moving and is not at the last position of the mouse
        if (moving && (Vector2)transform.position != lastMousePos)
        {
            // create variable for movement
            float step = speed * Time.deltaTime;

            // move the object to the new last position of the mouse
            transform.position = Vector2.MoveTowards(transform.position, lastMousePos, step);
        }

        // when the object has reached the last mouse position
        else
        {
            // stop moving
            moving = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Wall")
            SceneManager.LoadScene("GameOver");
        else if (collision.tag == "Finish")
            SceneManager.LoadScene("Finish");

    }
}
