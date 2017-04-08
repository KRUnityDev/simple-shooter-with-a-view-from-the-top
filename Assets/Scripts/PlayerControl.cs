using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerControl : MonoBehaviour {

    public float Speed = 10f;
    Rigidbody2D playerRigidbody;

    private Vector2 currentReturn;

    public Vector2 GetReturn()
    {
        return currentReturn;
    }

    private void Awake()
    {
        currentReturn = Vector2.up;
        playerRigidbody = gameObject.GetComponent<Rigidbody2D>();
    }

    void FixedUpdate () {
    
    #if UNITY_STANDALONE
        float verticalAxis = Input.GetAxis("Vertical");
        float horizontalAxis = Input.GetAxis("Horizontal");
        playerRigidbody.velocity = new Vector2(horizontalAxis*Speed, verticalAxis*Speed);

        if (Input.anyKey)
        {
            currentReturn = new Vector2(Mathf.Round(horizontalAxis), Mathf.Round(verticalAxis));
             Debug.Log("vertical: " + currentReturn.x + " horizontal: " + currentReturn.y);
            if (Mathf.Round(currentReturn.x) == 1 && Mathf.Round(currentReturn.y) == 1)
                transform.localEulerAngles = new Vector3(0,0, -45);
            if (Mathf.Round(currentReturn.x) == 0 && Mathf.Round(currentReturn.y) == 1)
                transform.localEulerAngles = new Vector3(0, 0, 0);

            if (Mathf.Round(currentReturn.x) == -1 && Mathf.Round(currentReturn.y) == 1)
                transform.localEulerAngles = new Vector3(0, 0, 45);

            if (Mathf.Round(currentReturn.x) == 1 && Mathf.Round(currentReturn.y) == 0)
                transform.localEulerAngles = new Vector3(0, 0, -90);
            if (Mathf.Round(currentReturn.x) == -1 && Mathf.Round(currentReturn.y) == 0)
                transform.localEulerAngles = new Vector3(0, 0, 90);

            if (Mathf.Round(currentReturn.x) == -1 && Mathf.Round(currentReturn.y) == -1)
                transform.localEulerAngles = new Vector3(0, 0, 135);
            if (Mathf.Round(currentReturn.x) == 1 && Mathf.Round(currentReturn.y) == -1)
                transform.localEulerAngles = new Vector3(0, 0, -135);

            if (Mathf.Round(currentReturn.x) == 0 && Mathf.Round(currentReturn.y) == -1)
                transform.localEulerAngles = new Vector3(0, 0, -180);

        }
           

        if ( (int)Input.GetAxis("Fire") == 1)
        {
            gameObject.SendMessage("Shot");
        }

    #endif
    #if UNITY_ANDROID
        //TODO
    #endif
    
    }
}
