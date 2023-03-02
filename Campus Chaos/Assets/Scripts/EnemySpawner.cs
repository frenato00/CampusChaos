using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject batPrefab;
    [SerializeField]
    private GameObject teacherPrefab;

    [SerializeField]
    private float batInterval = 3.5f;
    [SerializeField]
    private float teacherInterval = 7f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnEnemy(batInterval, batPrefab));
        StartCoroutine(spawnEnemy(teacherInterval, teacherPrefab));
    }

    private IEnumerator spawnEnemy(float interval, GameObject enemy) {
        yield return new WaitForSeconds(interval);
        GameObject newEnemy = Instantiate(enemy, new Vector3(Random.Range(-5f, 5f), Random.Range(-5f, 5f)), Quaternion.identity);
        StartCoroutine(spawnEnemy(interval, enemy));
    }
}
