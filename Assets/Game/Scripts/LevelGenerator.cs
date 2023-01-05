using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    static LevelGenerator _instance;
    public static LevelGenerator Instance => _instance;


    [SerializeField] GameObject[] Parts;
    [SerializeField] int _poolSize = 3;

    Vector3 _lastPos = Vector3.zero;

    Dictionary<int, List<GameObject>> _pools = new Dictionary<int, List<GameObject>>();
    void Awake()
    {
        _instance = this;

        for (int i = 0; i < Parts.Length; i++)
        {
            var pool = new List<GameObject>();

            for (int j = 0; j < _poolSize; j++)
            {
                var part = Instantiate(Parts[i], transform);
                part.SetActive(false);
                pool.Add(part);
            }

            _pools.Add(i, pool);
        }

        for (int i = 0; i < Parts.Length; i++)
        {
            CreateLevel(i);
        }
    }
    public void CreateRandomPart()
    {
        var type = Random.Range(0, Parts.Length);
        CreateLevel(type);
    }
    public void CreateLevel(int type)
    {
        var part = _pools[type][0];
        _pools[type].Remove(part);
        part.SetActive(true);
        _lastPos.x += 41;
        part.transform.position = _lastPos;
    }
    public void AddToPool(int type, GameObject part)
    {
        _pools[type].Add(part);
        part.SetActive(false);
    }
}
