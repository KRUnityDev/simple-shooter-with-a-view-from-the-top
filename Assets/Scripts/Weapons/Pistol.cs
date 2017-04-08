using System.Collections;
using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;
using UnityEngine;

public class Pistol : MonoBehaviour, IWeapon
{

    private GameObject ammo;
    private float shotPower = 10f;
    private float reloadTime = 1f;

    public Pistol()
    {
        ammo = Resources.Load<GameObject>("ammo");
    }


    public void Shot(Vector2 shotPoint, Vector2 direction)
    {
        GameObject newAmmo = Instantiate(ammo, shotPoint, Quaternion.identity) as GameObject;
        newAmmo.GetComponent<Rigidbody2D>().velocity = new Vector2(direction.x * shotPower, direction.y * shotPower);
    }
}
