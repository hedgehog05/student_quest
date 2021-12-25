using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PencilGun : MonoBehaviour
{
    public GunType gunType;
    public GameObject pencil;
    public Joystick joystick;
    public Transform shotPoint;

    public float startTimeBtwShots;
    public float offset;


    //для пушки игрока и врага
    public enum GunType {Default, Enemy}


    private float timeBtwShots;
    private float rotZ;
    private Vector3 difference;
    private Player_Boss player;

    // Start is called before the first frame update
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Boss>();
        if (player.controlType == Player_Boss.ControlType.PC && gunType == GunType.Default)
        {
            joystick.gameObject.SetActive(false);
        }

    }

    // Update is called once per frame
    private void Update()
    {
        if (gunType == GunType.Default)
        {
            difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        }

       
        else if (player.controlType == Player_Boss.ControlType.Android && Mathf.Abs(joystick.Horizontal) > 0.3f || Mathf.Abs(joystick.Vertical) > 0.3f)
        {
            rotZ = Mathf.Atan2(joystick.Vertical, joystick.Horizontal) * Mathf.Rad2Deg;
        }

        else if (gunType == GunType.Enemy)
        {
            difference = player.transform.position - transform.position;
            rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        }
        
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);

        if (timeBtwShots <= 0)
        {
            if (Input.GetMouseButton(0) && player.controlType == Player_Boss.ControlType.PC || gunType == GunType.Enemy)
            {

                Shoot();
            }

            else if (player.controlType == Player_Boss.ControlType.Android)
            {
                if (joystick.Horizontal != 0 || joystick.Vertical != 0)
                {
                    Shoot();
                }
            }
        }

        else
        {
            timeBtwShots -= Time.deltaTime;
        }

    }


    public void Shoot()
    {
        Instantiate(pencil, shotPoint.position, shotPoint.rotation);
        timeBtwShots = startTimeBtwShots;
    }
}
