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
    private float batInitialInterval = 3f;
    [SerializeField]
    private float teacherInitialInterval = 6f;

    private Collider2D col;

    // Start is called before the first frame update
    void Start()
    {
        col = GetComponent<Collider2D>();
        StartCoroutine(spawnEnemy(batInitialInterval, batPrefab));
        StartCoroutine(spawnEnemy(teacherInitialInterval, teacherPrefab));
    }

    private IEnumerator spawnEnemy(float interval, GameObject enemy)
    {
        yield return new WaitForSeconds(interval);
        Vector3 position;
        do
        {
            position = new Vector2(Random.Range(col.bounds.min.x, col.bounds.max.x), Random.Range(col.bounds.min.y, col.bounds.max.y));
        } while (!col.OverlapPoint(position));
        if (GameObject.FindGameObjectsWithTag("Enemy").Length < 30)
            Instantiate(enemy, position, Quaternion.identity);
        StartCoroutine(spawnEnemy(Mathf.Max(0.98f * interval, 1.5f), enemy));
    }
}
