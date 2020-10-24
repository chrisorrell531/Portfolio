using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] Enemy;
    [SerializeField] private List<GameObject>EnemiesOnScreen;

    // Start is called before the first frame update
    void Start()
    {
        EnemiesOnScreen = new List<GameObject>();
        GameObject isEnemy = GameObject.Find("Enemy").GetComponent<GameObject>();
        if(Enemy == null)
        {
            for(int i = 0; i < 1; i++)
            {
                SpawnEnemy();
            }
        }
    }

    public void SpawnEnemy()
    {
        GameObject go = Instantiate(Enemy[0]);
        Transform parent = GameObject.Find("Enemies").GetComponent<Transform>();
        go.transform.SetParent(parent);
        Transform EnemySpawn = GameObject.Find("EnemySpawnPoint").GetComponent<Transform>();
        go.transform.localPosition = new Vector2(EnemySpawn.transform.position.x, EnemySpawn.transform.position.y);
        EnemyAI ai = go.gameObject.GetComponent<EnemyAI>();
        ai.Index = 0;
        EnemiesOnScreen.Add(go);
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void RemoveFromList(int ind)
    {
        EnemiesOnScreen.RemoveAt(ind);
    }
}