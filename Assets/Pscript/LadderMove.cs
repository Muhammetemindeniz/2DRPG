using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderMove : MonoBehaviour
{
    float iny;
    float speed = 4;
    private bool isLadder;
    private bool isClimbing;
    [SerializeField] private Rigidbody2D rg;
    void Start()
    {
        
    }
    void Update()
    {
        MoveLadder();
    }
    void MoveLadder()
    {
        iny = Input.GetAxis("Vertical");
        if(isLadder && Mathf.Abs(iny) > 0f)
        {
            isClimbing = true;
        }
    }
    private void FixedUpdate()
    {
        if (isClimbing)
        {
            rg.gravityScale = 0f;
            rg.velocity = new Vector2(rg.velocity.x, iny * speed);
        }
        else
        {
            rg.gravityScale = 1f;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Merdiven"))
        {
            isLadder = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Merdiven"))
        {
            isLadder= false;
            isClimbing = false;
        }
    }
}
