using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drag : MonoBehaviour
{
    // starting positions
    float startPosX;
    float startPosY;

    bool isBeingHeld; // checks if object is being held

    // Update is called once per frame
    void Update()
    {
        // if object is being held
        if (isBeingHeld)
        {
            Vector2 mousePos; // create vector two called mousePos
            mousePos = Input.mousePosition; // change value of mousePos
            mousePos = Camera.main.ScreenToWorldPoint(mousePos); // change the value of mousePos

            // change position
            gameObject.transform.position = new Vector2(mousePos.x, mousePos.y);
        }
    }

    // is called when mouse has been clicked on object
    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePos; // create vector two called mousePos
            mousePos = Input.mousePosition; // change value of mousePos
            mousePos = Camera.main.ScreenToWorldPoint(mousePos); // change the value of mousePos

            isBeingHeld = true; // mouse is clicked/held on object
        }
    }

    // is called whrn mouse is lefted up
    private void OnMouseUp()
    {
        isBeingHeld = false;
    }
}
