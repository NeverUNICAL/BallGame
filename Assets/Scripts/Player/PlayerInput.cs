using UnityEngine;
using UnityEngine.Events;

public class PlayerInput : MonoBehaviour
{
    public event UnityAction ClosedGame;
    public event UnityAction ChangedGravity;
    
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
