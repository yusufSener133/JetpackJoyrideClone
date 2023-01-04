using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterGroundController : MonoBehaviour
{
    [SerializeField] Character _character;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Ground")
        {
            _character.Run();
        }
    }
}
