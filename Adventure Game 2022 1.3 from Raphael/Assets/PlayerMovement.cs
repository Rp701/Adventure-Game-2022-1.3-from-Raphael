using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;

    public float Speed = 2.5f;
    public float JumpHeight = 5f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(Input.GetAxis("Horizontal")*Speed, rb.velocity.y);
        transform.GetChild(0).gameObject.GetComponent<Animator>().SetFloat("Speed", Mathf.Round(Mathf.Abs(Input.GetAxis("Horizontal"))));

        if(Input.GetKeyDown(KeyCode.Space)){
            rb.velocity = new Vector2(rb.velocity.x, JumpHeight);
            transform.GetChild(0).gameObject.GetComponent<Animator>().SetTrigger("Jump");
        }
    }
}
