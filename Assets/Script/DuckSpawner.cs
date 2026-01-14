using UnityEngine;

public class DuckSpawner : MonoBehaviour
{
    public GameObject duckPrefab;
    public int maxDucks = 10;
    public float spawnInterval = 1.5f;

    [Header("Spawn Area")]
    public Vector2 center = new Vector2(6, 0);
    public Vector2 size = new Vector2(10, 6);

    float timer;

    void Update()
    {
        if (duckPrefab == null) return;

        timer += Time.deltaTime;
        if (timer >= spawnInterval)
        {
            timer = 0f;

            if (GameObject.FindGameObjectsWithTag("Duck").Length < maxDucks)
                SpawnDuck();
        }
    }

    void SpawnDuck()
    {
        Vector2 pos = center + new Vector2(
            Random.Range(-size.x / 2f, size.x / 2f),
            Random.Range(-size.y / 2f, size.y / 2f)
        );

        GameObject d = Instantiate(duckPrefab, pos, Quaternion.identity);
        d.tag = "Duck";
    }

#if UNITY_EDITOR
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(center, size);
    }
#endif
}
