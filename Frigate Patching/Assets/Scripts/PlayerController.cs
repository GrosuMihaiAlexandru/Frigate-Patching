using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private Player player;

    private BulletLauncher launcher;
    public Transform projectileSpawnPos;

    public Transform movingCamera;

    public float screenLimitX;
    public float screenLimitY;

    private bool fired;
    private float fireDelay = 1f;

    float lastFire;

    void Start()
    {
        player = gameObject.GetComponent<Player>();
        movingCamera = Camera.main.transform;
        launcher = GetComponent<BulletLauncher>();
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
            Vector3 velocity = new Vector3(velocityX, velocityY, 0);
            //Debug.Log(velocity);
            transform.position += Vector3.right * Time.deltaTime * GameManager.Instance.gameSpeed + velocity;
        }
        else
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            transform.position += Vector3.right * Time.deltaTime * GameManager.Instance.gameSpeed;
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

    public void Shoot()
    {
        if (Input.GetAxisRaw("Fire1") == 1f)
        {
            if (Time.time - lastFire > fireDelay)
            {
                if (player.ammo > 0)
                {
                    GameEvents.FireAction();
                    player.ammo--;
                    lastFire = Time.time;
                    launcher.FireBullet(projectileSpawnPos.position);
                    AudioPlayer.Instance.PlayFire();
                }
            }
        }

    }

    void Update()
    {
        Move();
        Shoot();

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("MenuScene");
        }
    }
}
