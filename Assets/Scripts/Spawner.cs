using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private Transform[] _points;

    private float _timer;

    void Start()
    {
        _points = new Transform[transform.childCount];

        for (int i = 0; i < transform.childCount; i++)
        {
            _points[i] = transform.GetChild(i);
        }
    }

    void Update()
    {
        _timer += Time.deltaTime;

        if (_timer > 2)
        {
            Instantiate(_enemyPrefab, _points[Random.Range(0, _points.Length)].position, Quaternion.identity);

            _timer = 0;
        }
    }
}
