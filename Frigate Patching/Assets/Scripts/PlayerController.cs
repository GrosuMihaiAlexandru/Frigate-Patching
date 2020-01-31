using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Player player;
    public GameObject bullet;

    public Transform movingCamera;

    public float screenLimitX;
    public float screenLimitY;

    private bool fired;
    private float fireDelay;

    void Start()
    {
        player = gameObject.GetComponent<Player>();
        movingCamera = Camera.main.transform;
    }

    public void Move()
    {
        float velocityX;
        float velocityY;
        // Calculate movement velocity
        if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
        {
            velocityX = Input.GetAxisRaw("Horizontal") * player.moveSpeed;
            velocityY = Input.GetAxisRaw("Vertical") * player.moveSpeed;
            Vector2 velocity = Vector3.right * Time.deltaTime * GameManager.Instance.gameSpeed + new Vector3(velocityX, velocityY, 0);
            //Debug.Log(velocity);
            gameObject.GetComponent<Rigidbody2D>().velocity = velocity;
        }
        else
        {
            gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.right * Time.deltaTime * GameManager.Instance.gameSpeed * 100;
        }
        // Screen bounds X
        if (transform.position.x >= movingCamera.position.x + screenLimitX)
            transform.position = new Vector3(movingCamera.position.x + screenLimitX, transform.position.y, transform.position.z);
        else if (transform.position.x <= movingCamera.position.x - screenLimitX)
            transform.position = new Vector3(movingCamera.position.x - screenLimitX, transform.position.y, transform.position.z);

        // Screen bounds Y  
        if (transform.position.y >= screenLimitY)
            transform.position = new Vector3(transform.position.x, screenLimitY, transform.position.z);
        else if (transform.position.y <= -screenLimitY)
            transform.position = new Vector3(transform.position.x, -screenLimitY, transform.position.z);
    }
    // Bullet Shooting needs some rework
    public Vector3 BulletSpawnCoordinatesA()
    {
        SpriteRenderer sprite = gameObject.GetComponent<SpriteRenderer>();
        Bounds b = sprite.bounds;
        Debug.Log(b.size.x);
        Vector3 location = new Vector3(transform.position.x - b.size.x / 3, transform.position.y + b.size.y / 2, transform.position.z);

        return location;

    }
    public Vector3 BulletSpawnCoordinatesB()
    {
        SpriteRenderer sprite = gameObject.GetComponent<SpriteRenderer>();
        Bounds b = sprite.bounds;
        Debug.Log(b.size.x);
        Vector3 location = new Vector3(transform.position.x + b.size.x / 3, transform.position.y + b.size.y / 2, transform.position.z);

        return location;

    }
   /* public void Shoot()
    {
        if (Input.GetAxisRaw("Fire1") == 1f)
        {
            if (fired == false)
            {
                fired = true;
                GameObject bulletInstance = Instantiate(bullet);
                bulletInstance.transform.SetParent(transform.parent);
                bulletInstance.transform.position = BulletSpawnCoordinatesA();
                bulletInstance.GetComponent<Rigidbody2D>().velocity = new Vector2(0, player.fireSpeed);
                GameObject bulletInstance2 = Instantiate(bullet);
                bulletInstance2.transform.SetParent(transform.parent);
                bulletInstance2.transform.position = BulletSpawnCoordinatesB();
                bulletInstance2.GetComponent<Rigidbody2D>().velocity = new Vector2(0, player.fireSpeed);
                Destroy(bulletInstance, 2f);
                Destroy(bulletInstance2, 2f);
                Debug.Log("Fire");
            }
        }
        else
        {
            fired = false;
        }

    }*/

    void Update()
    {
        Move();
        //Shoot();
    }
}
