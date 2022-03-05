using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;

    public float Speed = 2.5f;
    public float JumpHeight = 5f;

    public bool Wiggle = true;
    public float WiggleSpeed = 1f;
    public float WiggleEffect = 10f;
    
    public UnityEvent OnJump;
    public UnityEvent OnLand;

    int groundHits;
    bool IsGrounded;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        groundHits = 0;
        IsGrounded = false;
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(Input.GetAxis("Horizontal")*Speed, rb.velocity.y);
        transform.GetChild(0).gameObject.GetComponent<Animator>().SetFloat("Speed", Mathf.Round(Mathf.Abs(Input.GetAxis("Horizontal"))));

        if(Input.GetKeyDown(KeyCode.Space) && IsGrounded){
            rb.velocity = new Vector2(rb.velocity.x, JumpHeight);
            transform.GetChild(0).gameObject.GetComponent<Animator>().SetTrigger("Jump");

            OnJump.Invoke();
        }

        transform.GetChild(0).gameObject.GetComponent<Animator>().SetBool("IsGrounded", IsGrounded);
        if(Wiggle)
            transform.rotation = Quaternion.Euler(0f, 0f, Mathf.Cos(Time.time*WiggleSpeed)*WiggleEffect*Input.GetAxis("Horizontal"));
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "Ground"){
            groundHits++;
            IsGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D other) {
        if(other.gameObject.tag == "Ground"){
            groundHits--;
            if(groundHits == 0){
                IsGrounded = false;
                OnLand.Invoke();
            }
        }
    }
}
