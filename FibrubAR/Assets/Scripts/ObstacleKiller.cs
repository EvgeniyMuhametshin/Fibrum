using UnityEngine;
using System.Collections.Generic;

public class ObstacleKiller : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private ObstacleSpawner _spawner;
    [SerializeField] private float _killDistanceZ;

    // Update is called once per frame
    void Update()
    {
        List<Transform> obstacle = _spawner.spawnedObstacles;

        for (int i = 0; i < obstacle.Count; i++)
        {
            if (_player.position.z > obstacle[i].position.z + _killDistanceZ)
            {
                Destroy(obstacle[i].gameObject);
            }
        }
    }
}
