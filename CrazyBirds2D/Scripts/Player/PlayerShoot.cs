using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerShoot : MonoBehaviour
{
    public enum OperatingSystem {PcOrMac = 0, IOS = 1, Android = 2 }
    public OperatingSystem operatingSystem = OperatingSystem.PcOrMac;

    [SerializeField] private GameObject Bullet;
    [SerializeField] private GameObject Enemy;
    [SerializeField] private Button IOSAndriodShootButton;

    Vector2 BulletDirection;
    Rigidbody2D rb;
    float bulletSpeed = 1f;

    void Awake()
    {
        if (operatingSystem == OperatingSystem.IOS)
        {
            IOSAndriodShootButton.enabled = true;
            IOSAndriodShootButton.onClick.AddListener(ShootBullet);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        SetTarget();
    }

    void ShootBullet()
    {
        if (Enemy != null)
        {
            GameObject bul = Instantiate(Bullet, this.gameObject.transform);
            rb = bul.GetComponent<Rigidbody2D>();
            rb.velocity = BulletDirection * bulletSpeed;
            Debug.Log("Fired");
            StartCoroutine(DestroyBullet(bul));
        }
    }

    IEnumerator DestroyBullet(GameObject bul)
    {
        yield return new WaitForSeconds(5f);
        Destroy(bul);
    }

    void SetTarget()
    {
        Enemy = GameObject.FindGameObjectWithTag("Enemy");
        if (Enemy != null)
        {
            BulletDirection = Enemy.transform.position - this.transform.position;
            if (operatingSystem == OperatingSystem.PcOrMac)
            {
                if (Input.GetKeyUp(KeyCode.W))
                {
                    ShootBullet();
                }
            }
        }
    }
}
