using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Bullet_Pencil : MonoBehaviour
{
    public float speed;
    public float lifetime;
    public float distance;
    public int damage;
    public LayerMask whatIsSolid;

    public GameObject destroyEffect;
    //public GameObject bullet_PencilEffect;

    private void Start()
    {
        Invoke("DestroyBullet", lifetime);
    }

    // Update is called once per frame
    private void Update()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.up, distance, whatIsSolid);
        if (hitInfo.collider != null)
        {
            if (hitInfo.collider.CompareTag("Enemy"))
            //if (hitInfo.collider.CompareTag("MiniEnemy"))
            {
                //hitInfo.collider.GetComponent<Enemy>().TakeDamage(damage);
                hitInfo.collider.GetComponent<MiniEnemyController>().TakeDamage(damage);
            }

            DestroyBullet();
        }

        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }

	public void DestroyBullet()
	{
        Instantiate(destroyEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
