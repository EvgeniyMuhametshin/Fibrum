using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour {

    [SerializeField] private Transform[] _obstacle;
    [SerializeField] private float _spawnStep;
    [SerializeField] private float _spawnDistance;

    [SerializeField] private Vector2 _segmentWidth;

    private Transform _myTrans;
    private Vector3 _lastPos;

    private List<Transform> _spavnerObstacles = new List<Transform>();
    public List<Transform> spawnedObstacles
    {
        get { _spavnerObstacles.RemoveAll(TransformIsNull); return _spavnerObstacles; }
    }

    bool TransformIsNull(Transform a)
    {
        return a == null;
    }

    // Use this for initialization
    void Start () {
        _myTrans = transform;
        _lastPos = _myTrans.position;
	}
	
	// Update is called once per frame
	void Update () {
        if (_myTrans.position.z > _lastPos.z + _spawnStep)
        {
            _lastPos.z += _spawnStep;

            Transform newObstacle = _obstacle[Random.Range(0, _obstacle.Length)];

            _spavnerObstacles.Add(Instantiate(newObstacle, new Vector3
                (Random.Range(_segmentWidth.x, _segmentWidth.y),
                0, _lastPos.z + _spawnDistance), Quaternion.identity));
        }
	}
}
