using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiddleSpawner : MonoBehaviour
{
    [SerializeField] private GameObject NonMoveEnemy, Coin;
    [SerializeField, HideInInspector] private int index;
    [SerializeField] private GameObject parent;

    void Start()
    {
        index = Random.Range(0, 5);
        if(index == 0)
        {
            return;
        }
        if(index < 5 && index > 0)
        {
            GameObject CoinCopy = Instantiate(Coin, parent.transform.position, parent.transform.rotation);
            CoinCopy.transform.SetParent(parent.transform);
        }
        if(index == 5)
        {
            GameObject Enemy = Instantiate(NonMoveEnemy, this.transform.position, this.transform.rotation);
            Enemy.transform.SetParent(GameObject.Find("Enemies").GetComponent<Transform>());
        }
    }
}
