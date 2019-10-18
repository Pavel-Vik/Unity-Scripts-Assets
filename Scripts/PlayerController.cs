using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 400;
    public float jumpforce;

    private GameObject gameobject;
    private Rigidbody2D rb;
    private Collider2D collider;
    private float rotateVelocity;
    private Vector2 direction;
    private bool grounded;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        collider = GetComponentInChildren<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveInput = Input.GetAxisRaw("Horizontal");
        direction = new Vector2(moveInput, 1);
        rotateVelocity = - moveInput * speed;
    }

    private void FixedUpdate()
    {
        //grounded = Physics2D.OverlapCircle(ground.position, radius, groundlayers);
        rb.MoveRotation(rb.rotation + rotateVelocity * Time.fixedDeltaTime);
        if (Input.GetKeyDown(KeyCode.Space) && collider.IsTouchingLayers())
        {
            rb.AddForce(direction.normalized * jumpforce, ForceMode2D.Impulse);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name);
    }
}
