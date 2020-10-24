using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NonMoveEnemyAI : MonoBehaviour
{
    [SerializeField] private float Health = 100f;
    [SerializeField] public int Index;
    public Sprite DamagedEnemy;



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(Health <= 50.00f)
        {
            SpriteRenderer rend = this.gameObject.GetComponent<SpriteRenderer>();
            rend.sprite = DamagedEnemy;
        }
        if(Health <= 0.00f)
        {
            PlayerSatsBehaviour stats = GameObject.Find("PlayerStatsBehaviour").GetComponent<PlayerSatsBehaviour>();
            stats.Points += 10;
            Destroy(this.gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Bullet")
        {
            Health -= 25f;
            Destroy(other.gameObject);
        }
    }
}
