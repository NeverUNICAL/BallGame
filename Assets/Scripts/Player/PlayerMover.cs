using System;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Player))]

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private WinningPanel _panel;
    
    private Player _player;
    private Rigidbody _rigidbody;
    private bool _isGrounded;
    private Vector3 _defaultGravity;
    
    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _player = GetComponent<Player>();
        _defaultGravity = new Vector3(0, -9.8f, 0);
    }

    private void Update()
    {
        if (Physics.gravity.y < 1)
                _rigidbody.AddTorque(0, 0, -1);
        else
            _rigidbody.AddTorque(0, 0, 1);
    }

    private void OnCollisionEnter(Collision collision)
    {
        _isGrounded = true;
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.TryGetComponent(out DeathZone deathZone))
        {
            _player.Die();
            Physics.gravity = _defaultGravity;
        }
        
        if (collider.TryGetComponent(out Coin coin))
        {
            Destroy(collider.gameObject);
            _player.AddCoin(coin.Value);
        }

        if (collider.TryGetComponent(out WinZone winZone))
        {
            _panel.OpenPanel();
        }
    }

    private void OnCollisionExit(Collision other)
    {
        _isGrounded = false;
    }

    public void ChangeGravity()
    {
        if (_isGrounded)
            Physics.gravity = new Vector3(0,Physics.gravity.y * -1,0);
    }
}
