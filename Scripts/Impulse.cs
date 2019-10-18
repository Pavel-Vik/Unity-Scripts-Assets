using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Impulse : MonoBehaviour
{
    public Vector2 direction;
    public float acceleration;
    private Rigidbody2D rb;
    public GameObject gameobject;
    private float oldSpeed, newSpeed;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //oldSpeed = gameobject.GetComponent<PlayerController>().speed;
        //newSpeed = gameobject.GetComponent<PlayerController>().speed;
    }

    private void Update()
    {
        float moveInputX = Input.GetAxisRaw("Horizontal");
        float moveInputY = Input.GetAxisRaw("Vertical");
        direction = new Vector2(moveInputX, moveInputY);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddForce(direction.normalized * acceleration, ForceMode2D.Impulse);
            //newSpeed = oldSpeed + acceleration;
        }
        //else if (Input.GetKeyUp(KeyCode.LeftShift) && (newSpeed > oldSpeed))
        //{
        //    newSpeed = oldSpeed;
        //}
        //gameobject.GetComponent<PlayerController>().speed = newSpeed;
    }
}
