using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public GameObject BulletPrefab;
    public GameObject Player;
    
    private float LastShoot;
    private int Health = 3;

    
    // Update is called once per frame
    private void Update()
    {
        if(Player==null) return;
        Vector3 direction = Player.transform.position - transform.position; //la posicion de Player - la posicion de grunt, obtenemos el vector direccion que va de grunt a Player. si el componente x de la direcciion es positiva, el grunt tiene que mirar hacia la derecha, sino, hacia la izquierda
        if(direction.x >=0.0f) transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        else transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);

        float distance = Mathf.Abs(Player.transform.position.x - transform.position.x);
    
        if(distance < 1.0f && Time.time > LastShoot + 0.7f)
        {
            Shoot();
            LastShoot = Time.time;
        }
    }

    private void Shoot()
    {
        Vector3 direction;
        if(transform.localScale.x == 1.0f) direction = Vector2.right;
        else direction = Vector2.left;

        GameObject bullet = Instantiate(BulletPrefab, transform.position + direction * 0.1f, Quaternion.identity);
        bullet.GetComponent<BulletScript>().SetDirection(direction);
    }

    public void Hit()
    {
        Health = Health - 1;
        if(Health == 0) Destroy(gameObject);
    }
}
