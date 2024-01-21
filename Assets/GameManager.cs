using System.Collections;
using UnityEngine;



internal class GameManager : MonoBehaviour
{
    public float enemySpawnerDuration = 0.75f;
    public Transform enemySpawnerPosition;
    public GameObject enemyPrefab;



    private void Start() {
        StartCoroutine(EnemySpawner());
    }


    public IEnumerator EnemySpawner()
    {
        while (true)
        {
            yield return new WaitForSeconds(this.enemySpawnerDuration);
            GameObject _enemy = Instantiate(this.enemyPrefab, enemySpawnerPosition.position, Quaternion.identity);
        }
    }
}