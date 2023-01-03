using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Character : MonoBehaviour
{
    [Header("Assignment")]
    [SerializeField] Animator _animator;
    [SerializeField] Rigidbody2D _rigidbody;
    [Header("Settings")]
    [SerializeField] float _power = 100f;
    [SerializeField] float _speed = 10f;
    [SerializeField] float _posionLimit = 4f;

    void Start()
    {
        CharacterController.Instance.Register(this);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Obstacle")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
    public void Fly()
    {
        _animator.Play("FlyUpAnim");

        _rigidbody.AddForce(Vector2.up * _power * Time.deltaTime);
        CheckLimits();
    }

    public void MoveForward()
    {
        transform.Translate(Vector2.right * _speed * Time.deltaTime);
    }

    public void Run()
    {
        _animator.Play("RunAnim");
    }

    public void StopFlying()
    {
        _animator.Play("FlyDownAnim");
        _rigidbody.velocity *= 0.5f;
    }

    private void CheckLimits()
    {
        if (transform.position.y > _posionLimit)
        {
            transform.position = new Vector3(transform.position.x, _posionLimit);
            _rigidbody.velocity = Vector2.zero;
        }
    }


}
