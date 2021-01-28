using System.Collections;
using UnityEngine;

public class SpawnObject : MonoBehaviour
{

    public GameObject Foodprefab;
    public Vector3 center;
    public Vector3 size;

    void Start() {
        for (int i = 0; i < 150; i++)
            SpawnFood();
    }

    void Update() {

    }

    public void SpawnFood() {
        Vector3 pos = new Vector3(Random.Range(-76, 143) - 350, 70 ,Random.Range(-17, 100));

        Instantiate(Foodprefab, pos, Quaternion.identity);
    }

    void OnDrawGizmosSelect() {
        Gizmos.color = new Color(1, 0, 0, 0.5f);
        Gizmos.DrawCube(center, size);
    }
}
