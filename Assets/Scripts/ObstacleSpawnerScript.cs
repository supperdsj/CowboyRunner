using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ObstacleSpawnerScript : MonoBehaviour {
    [SerializeField] GameObject[] obstacles;
    [SerializeField] List<GameObject> obstaclesForSpawing = new List<GameObject>();

    void Awake() {
        InitializeObstacles();
    }

    void Start() {
        StartCoroutine(SpawnRandomObstacle());
    }

    void InitializeObstacles() {
        int index = 0;
        for (int i = 0; i < obstacles.Length * 3; i++) {
            GameObject obj = Instantiate(
                obstacles[index],
                new Vector3(transform.position.x, transform.position.y, -2),
                Quaternion.identity);
            obstaclesForSpawing.Add(obj);
            obstaclesForSpawing[i].SetActive(false);
            index++;
            if (index == obstacles.Length) {
                index = 0;
            }
        }
    }

    void Shuffle() {
        for (int i = 0; i < obstaclesForSpawing.Count; i++) {
            int random = Random.Range(i, obstaclesForSpawing.Count);
            GameObject temp = obstaclesForSpawing[i];
            obstaclesForSpawing[i] = obstaclesForSpawing[random];
            obstaclesForSpawing[random] = temp;
        }
    }

    IEnumerator SpawnRandomObstacle() {
        yield return new WaitForSeconds(Random.Range(1.5f, 4.5f));
        while (true) {
            int index = Random.Range(0, obstaclesForSpawing.Count);
            if (!obstaclesForSpawing[index].activeInHierarchy) {
                obstaclesForSpawing[index].transform.position =
                    new Vector3(transform.position.x, transform.position.y, -2);
                obstaclesForSpawing[index].SetActive(true);
                break;
            }
        }

        StartCoroutine(SpawnRandomObstacle());
    }
}
