using UnityEngine;
using IJunior.TypedScenes;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Player))]
[RequireComponent(typeof(PlayerInput))]

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private WinningPanel _panel;
    
    private Player _player;
    private PlayerInput _input;
    private Rigidbody _rigidbody;
    private bool _isGrounded;
    private Vector3 _defaultGravity;
    
    private void Awake()
    {
        _input = GetComponent<PlayerInput>();
    }

    private void Start()
    {
        _defaultGravity = new Vector3(0, -9.8f, 0);
        _rigidbody = GetComponent<Rigidbody>();
        _player = GetComponent<Player>();
        Physics.gravity = _defaultGravity;
    }

    private void OnEnable()
    {
        _input.ChangedGravity += OnGravityChanged;
        _input.ClosedGame += OnGameClosed;
    }

    private void OnDisable()
    {
        _input.ChangedGravity -= OnGravityChanged;
        _input.ClosedGame -= OnGameClosed;
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

    private void OnGameClosed()
    {
        MainMenu.Load();
    }
    
    private void OnGravityChanged()
    {
        if (_isGrounded)
            Physics.gravity = new Vector3(0,Physics.gravity.y * -1,0);
    }
}
