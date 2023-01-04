using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    static LevelGenerator _instance;
    public static LevelGenerator Instance => _instance;
    [SerializeField] GameObject[] Levels;
    [SerializeField] int _poolSize;

    Vector3 pos = new Vector3(0, 0, 0);

    Dictionary<int, List<GameObject>> _pools = new Dictionary<int, List<GameObject>>();
    void Awake()
    {
        _instance = this;

        for (int i = 0; i < Levels.Length; i++)
        {
            var pool = new List<GameObject>();
            for (int j = 0; i < _poolSize; j++)
            {
                var part = Instantiate(Levels[i], transform);
                part.SetActive(false);
                pool.Add(part);
            }

            _pools.Add(i, new List<GameObject>());
        }

        for (int i = 0; i < Levels.Length; i++)
        {
            CreateLevel(i);
        }
    }
    public void CreateRandomPart()
    {
        var type = Random.Range(0, Levels.Length);
        CreateLevel(type);
    }
    public void CreateLevel(int type)
    {
        var part = _pools[type][0];
        _pools[type].Remove(part);
        part.SetActive(true);
        pos.x += 41;
        part.transform.position = pos;
    }

    public void AddToPool(int type, GameObject part)
    {
        _pools[type].Add(part);
        part.SetActive(false);
    }
}
