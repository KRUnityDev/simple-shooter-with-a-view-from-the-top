using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour {

    public Transform Clicker;

    public Transform ClickerOFFPosition;
    public Transform ClickerONPosition;

    public enum ButtonState {OFF, WantToBeOFF, ON, WantToBeON};
    public ButtonState buttonState = ButtonState.WantToBeOFF;

    public TextMesh textMesh;

    private float stateChangeSpeed = 10f;

    public void FixedUpdate()
    {
        switch(buttonState)
        {
            case ButtonState.WantToBeON:
                if (Clicker.position != ClickerONPosition.position)
                    Clicker.position = Vector3.MoveTowards(transform.position, ClickerONPosition.position, stateChangeSpeed);
                else
                    MakeButtonON();
            break;

            case ButtonState.WantToBeOFF:
                if (Clicker.position != ClickerOFFPosition.position)
                    Clicker.position = Vector3.MoveTowards(transform.position, ClickerOFFPosition.position, stateChangeSpeed);
                else
                    MakeButtonOFF();
            break;
        }
    }

    public void MakeButtonON()
    {
        buttonState = ButtonState.ON;
        textMesh.text = "ON";
    }

    public void MakeButtonOFF()
    {
        buttonState = ButtonState.OFF;
        textMesh.text = "OFF";
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("ButtonClicker"))
        {
            if (buttonState == ButtonState.ON) buttonState = ButtonState.WantToBeOFF;
            if (buttonState == ButtonState.OFF) buttonState = ButtonState.WantToBeON;
        }
    }
}
