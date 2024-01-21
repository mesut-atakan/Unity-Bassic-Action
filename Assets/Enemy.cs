using UnityEngine;



internal class Enemy : MonoBehaviour
{
    public float enemySpeed;








    public void EnemyMove()
    {
        this.transform.Translate(Vector3.right * enemySpeed * Time.deltaTime);
    }


    private void EnemyKilled() {
        Actions.OnEnemyKilled();
        Destroy(this.gameObject);
    }


    private void Update() {
        if (Input.GetMouseButtonDown(0))
            EnemyKilled();
    }



    private void FixedUpdate() {
        EnemyMove();
    }
}