using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    [SerializeField] private GameObject _resultsWindow;
    [SerializeField] private TMP_Text _enemyName;
    [SerializeField] private TMP_Text _hpText;
    [SerializeField] private Image _healthBar;
    private int _totalHealth;
    private float _currentHealth;

    private void Start()
    {
        string enemyName = PlayerPrefs.GetString("EnemyName", "");
        _enemyName.text = enemyName;
        _totalHealth = Random.Range(50, 101);
        _currentHealth = _totalHealth;
        _hpText.text = $"{_currentHealth}/{_totalHealth}";
    }

    public void EnemyHit()
    {
        if (_currentHealth > 0)
        {
            int hitPower = Random.Range(5, 11);
            _currentHealth -= hitPower;
            _healthBar.fillAmount = _currentHealth / _totalHealth;
            _hpText.text = $"{_currentHealth}/{_totalHealth}";
            if (_currentHealth <= 0)
            {
                _resultsWindow.SetActive(true);
            }
        }
    }
}