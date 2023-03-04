using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public HeroController player;
    public Enemy[] enemies;

    private void Start()
    {
        player = FindObjectOfType<HeroController>();
        enemies = FindObjectsOfType<Enemy>();
        foreach (var enemy in enemies)
        {
            enemy.target = player;
        }
    }
}
