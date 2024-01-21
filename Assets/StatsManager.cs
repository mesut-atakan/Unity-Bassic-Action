using UnityEngine;
using UnityEngine.UI;



internal class StatsManager : MonoBehaviour
{
    public Text killText;
    public int killCount = 0;





    private void OnEnable() 
    {
        Actions.OnEnemyKilled += EnemyKilled;
    }


    private void OnDisable() 
    {
        Actions.OnEnemyKilled -= EnemyKilled;
    }





    public void EnemyKilled()
    {
        killCount++;
        killText.text = killCount.ToString();
        Debug.Log("Calisti");
    }
}