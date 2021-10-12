using TMPro;
using UnityEngine;

public class CoinsBalance : MonoBehaviour
{
    [SerializeField] private TMP_Text _coins;
    [SerializeField] private Player _player;

    private void OnEnable()
    {
        _player.CoinsAmountChanged += OnValueChanged;
    }

    private void OnDisable()
    {
        _player.CoinsAmountChanged -= OnValueChanged;
    }

    private void OnValueChanged(int coins)
    {
        _coins.text = "Score:" + coins;
    }
}
