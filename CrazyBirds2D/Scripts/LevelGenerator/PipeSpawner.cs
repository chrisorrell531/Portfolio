using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] ObsticlePrefabs;
    [SerializeField] private float SpawnTime = 5f;
    [SerializeField] private Transform ObsticleSpawnAndParent;
    [SerializeField] private PlayerSatsBehaviour _stats;
    [SerializeField, HideInInspector] private int _LastSelected;
    [SerializeField, HideInInspector] private float _LastSpawnTime;

    void Start()
    {
        _LastSpawnTime = SpawnTime;
    }

    void Update()
    {
        SpawnTime -= Time.deltaTime;
        switch (SpawnTime)
        {
            case float a when SpawnTime <= 0.00f:
                SpawnTime = _LastSpawnTime;
                StartCoroutine(SelectRandomObsticle());
                break;
        }
    }

    IEnumerator SelectRandomObsticle()
    {
       int _SelectedPrefab = Random.Range(0, 5);
       SpawnObsticle(_SelectedPrefab);
       yield return new WaitForEndOfFrame();
    }

    void SpawnObsticle(int _selected)
    {
        GameObject NewObsticle = Instantiate(ObsticlePrefabs[_selected], ObsticleSpawnAndParent.transform.position, ObsticleSpawnAndParent.rotation);
        _LastSelected = _selected;
        NewObsticle.transform.SetParent(ObsticleSpawnAndParent);
    }
}
