using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathController : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Ground")
        {
            Debug.Log("Ground");
            SceneManager.LoadScene(2);
        }
        if(other.gameObject.tag == "Tree")
        {
            Debug.Log("Tree");
            SceneManager.LoadScene(2);
        }
        if(other.gameObject.tag == "Collectable")
        {
            Debug.Log("Collectable");
            PlayerSatsBehaviour stats = GameObject.Find("PlayerStatsBehaviour").GetComponent<PlayerSatsBehaviour>();
            stats.Cash += 10f;
            Destroy(other.gameObject);
        }
        if(other.gameObject.tag == "Enemy")
        {
            Debug.Log("EnemyTouched");
            SceneManager.LoadScene(2);
        }
    }
}