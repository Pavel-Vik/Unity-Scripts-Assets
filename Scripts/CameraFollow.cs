using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    //public GameObject target;
    public float damping = 1.5f;
    public Vector2 offset = new Vector2(2f, 1f);
    public bool faceLeft;
    private Transform player;
    private int lastX;
    private float lastY;

    void Start()
    {
        offset = new Vector2(Mathf.Abs(offset.x), Mathf.Abs(offset.y));
        FindPlayer(faceLeft);
        lastY = player.position.y;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (player)
        {
            int currentX = Mathf.RoundToInt(player.position.x);
            if (currentX > lastX) faceLeft = false; else if (currentX < lastX) faceLeft = true;
            lastX = Mathf.RoundToInt(player.position.x);
            if (lastY - player.position.y < 500)
                lastY = player.position.y;


            Vector3 target;
            if (faceLeft)
            {
                target = new Vector3(player.position.x - offset.x, lastY, transform.position.z);
            }
            else
            {
                target = new Vector3(player.position.x + offset.x, lastY , transform.position.z);
            }
            Vector3 currentPosition = Vector3.Lerp(transform.position, target, damping * Time.deltaTime);
            transform.position = currentPosition;
        }
    }

    public void FindPlayer(bool playerFaceLeft)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        lastX = Mathf.RoundToInt(player.position.x);
        if (playerFaceLeft)
        {
            transform.position = new Vector3(player.position.x - offset.x, player.position.y + offset.y, transform.position.z);
        }
        else
        {
            transform.position = new Vector3(player.position.x + offset.x, player.position.y + offset.y, transform.position.z);
        }
    }
}
