using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Health damage;
    public GameObject hitPoints;

    public float speed;
    public bool left = true;

    // Start is called before the first frame update
    void Start()
    {
        damage = hitPoints.GetComponent<Health>();
        speed = .01f;
    }

    // Update is called once per frame
    void Update()
    {
        if (left)
            transform.position = new Vector2(transform.position.x - speed, transform.position.y);
        else
            transform.position = new Vector2(transform.position.x + speed, transform.position.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            damage.TakeDamage(1);
        }

        if (collision.tag == "Wall" && left == true)
        {
            Debug.Log("hit");
            left = false;
        }
        else if (collision.tag == "Wall" && left == false)
        {
            Debug.Log("hit");
            left = true;
        }
    }
}
