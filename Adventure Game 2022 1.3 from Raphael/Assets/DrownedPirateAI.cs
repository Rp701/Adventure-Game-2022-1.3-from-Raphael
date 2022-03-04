using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrownedPirateAI : MonoBehaviour
{
    Rigidbody2D rb;
    Animator anim;

    public GameObject player;
    public float Speed = 3f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Mathf.Abs(transform.position.x-player.transform.position.x) > 2f){
            anim.SetFloat("Speed", 1f);
            if(player.transform.position.x > transform.position.x){
                rb.velocity = new Vector2(Speed, rb.velocity.y);
            }else if(player.transform.position.y < transform.position.x){
                rb.velocity = new Vector2(-Speed, rb.velocity.y);
            }
        }else{
            anim.SetFloat("Speed", 0f);
        }
    }
}
