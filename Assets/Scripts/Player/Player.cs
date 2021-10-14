using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField] private int _coinsAmount;
    
    public event UnityAction<int> CoinsAmountChanged;
    
    public void Die()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    
    public void AddCoin(int coin)
    {
        _coinsAmount += coin;
        CoinsAmountChanged?.Invoke(_coinsAmount);
    }
}
