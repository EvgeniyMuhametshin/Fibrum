using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelGenerated : MonoBehaviour
{

    [SerializeField] private List<Transform> _segments;
    [SerializeField] private float _minDistans;
    [SerializeField] private Transform _player;

    void Update()
    {
        Transform lastObject = _segments[_segments.Count - 1];//Обращаемся к последнему элементу в списке

        float dis = Vector3.Distance(lastObject.position, _player.position);

        if (dis < _minDistans)
        {
            Transform firstObject = _segments[0];
            firstObject.position = lastObject.position;

            Vector3 offset = lastObject.GetComponent<Collider>().bounds.extents + firstObject.GetComponent<Collider>().bounds.extents;
            firstObject.position += Vector3.forward * offset.z;

            _segments.Remove(firstObject);
            _segments.Add(firstObject);
        }
    }
}
