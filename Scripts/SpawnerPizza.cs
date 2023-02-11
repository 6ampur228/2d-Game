using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerPizza : MonoBehaviour
{
    [SerializeField] private Pizza _templatePizza;
    [SerializeField] private Transform _spawnPoints;

    private Transform[] _points;

    private void Start()
    {
        _points = new Transform[_spawnPoints.childCount];

        for(int i = 0; i < _points.Length; i++)
        {
            _points[i] = _spawnPoints.GetChild(i);

            Instantiate(_templatePizza, _points[i].position, Quaternion.identity);
        }
    }
}
