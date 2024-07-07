using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TileSpawner : MonoBehaviour
{
    public GameObject tilePrefab;
    public Transform[] spawnPoints;
    public float spawnInterval = 1f;

    private void Start()
    {
        StartCoroutine(SpawnTiles());
    }

    IEnumerator SpawnTiles()
    {
        while (true)
        {
            SpawnTile();
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    void SpawnTile()
    {
        int randomIndex = Random.Range(0, spawnPoints.Length);
        Instantiate(tilePrefab, spawnPoints[randomIndex].position, Quaternion.identity);
    }

    public void Restart()
    {
        SceneManager.LoadScene("MM");
    }
}
