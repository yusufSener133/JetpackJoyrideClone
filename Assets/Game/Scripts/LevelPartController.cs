using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelPartController : MonoBehaviour
{
    [SerializeField] GameObject _levelPart;
    [SerializeField] int _type;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            LevelGenerator.Instance.AddToPool(_type, _levelPart);
            LevelGenerator.Instance.CreateRandomPart();
        }
    }
}
