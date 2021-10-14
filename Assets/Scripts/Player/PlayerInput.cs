using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(PlayerMover))]

public class PlayerInput : MonoBehaviour
{
    public event UnityAction ClosedGame;
    public event UnityAction ChangedGravity;

    private PlayerMover _mover;

    private void Start()
    {
        _mover = GetComponent<PlayerMover>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S))
        {
            ChangedGravity?.Invoke();
        }
        
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ClosedGame?.Invoke();
        }
    }
}
