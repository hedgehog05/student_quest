using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public GameObject bullet;
    public Joystick joystick;
    public Transform shotPoint;

    public float startTimeBtwShots;
    public float offset;

    private float timeBtwShots;
    private float rotZ;
    private Vector3 difference;

    public float player;

    /*private float timeBtwShots;
    private Player player;


    // Start is called before the first frame update
    private void Start()
    {
        player = gameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    void Update()
    {
        //раскомментировать при внедрении джостиков
        //if (player.controlType == Player.ControlType.PC)
        //{
        //    difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) = transform.position;
        //    rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        //}

        //закоментрировать при внедрении джостиков

        difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) = transform.position;
        rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;


        transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);
        if (timeBtwShots <= 0)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Instantiate(bullet, shotPoint.position, transform.rotation);
                timeBtwShots = startTimeBtwShots;
            }
        }
    }*/
}
