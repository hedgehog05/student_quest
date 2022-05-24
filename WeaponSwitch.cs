using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitch : MonoBehaviour
{
    public GameObject pencilGun;
    public GameObject book;

    public static bool GameIsStarted = true;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            // 
            if (pencilGun.activeInHierarchy == true)
            {
                //
                pencilGun.SetActive(false);
                //
                book.SetActive(true);
            }
            //
            else if (book.activeInHierarchy == true)
            {
                book.SetActive(false);
                pencilGun.SetActive(true);
            }
        }
    }
}
