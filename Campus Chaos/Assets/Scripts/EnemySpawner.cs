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

    private Collider2D collider2D;

    // Start is called before the first frame update
    void Start()
    {
        collider2D = GetComponent<Collider2D>();
        StartCoroutine(spawnEnemy(batInterval, batPrefab));
        StartCoroutine(spawnEnemy(teacherInterval, teacherPrefab));
    }

    private IEnumerator spawnEnemy(float interval, GameObject enemy) {
        yield return new WaitForSeconds(interval);
        Vector3 position;
        do {
            position = new Vector2(Random.Range(collider2D.bounds.min.x, collider2D.bounds.max.x), Random.Range(collider2D.bounds.min.y, collider2D.bounds.max.y));
        } while (!collider2D.OverlapPoint(position));
        GameObject newEnemy = Instantiate(enemy, position, Quaternion.identity);
        StartCoroutine(spawnEnemy(interval, enemy));
    }
}
