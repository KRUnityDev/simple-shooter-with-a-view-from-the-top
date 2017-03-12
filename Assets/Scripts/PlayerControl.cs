using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerControl : MonoBehaviour {

    public float Speed = 10f;
    Rigidbody2D playerRigidbody;

    private void Awake()
    {
        playerRigidbody = gameObject.GetComponent<Rigidbody2D>();
    }

    void FixedUpdate () {

    #if UNITY_STANDALONE
        float verticalAxis = Input.GetAxis("Vertical");
        float horizontalAxis = Input.GetAxis("Horizontal");
        playerRigidbody.velocity = new Vector2(horizontalAxis*Speed, verticalAxis*Speed);
    #endif
    #if UNITY_ANDROID
        //TODO
    #endif

    }
}
