using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;
    public float smoothValue = 0.1f;

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = new Vector3(transform.position.x*(1f-smoothValue) + player.transform.position.x*smoothValue, transform.position.y*(1f-smoothValue) + player.transform.position.y*smoothValue, transform.position.z);
    }
}
