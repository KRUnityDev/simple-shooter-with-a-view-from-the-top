using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerControl))]
public class Player : MonoBehaviour
{
    private IWeapon currentWeapon;
    public Transform weaponPosition;

    public void Awake()
    {
        currentWeapon = new Pistol();
    }

    public void Shot()
    { 
        Vector2 currentReturn = gameObject.GetComponent<PlayerControl>().GetReturn();
        if(currentReturn != Vector2.zero)
            currentWeapon.Shot(weaponPosition.position, currentReturn);
    }
}
