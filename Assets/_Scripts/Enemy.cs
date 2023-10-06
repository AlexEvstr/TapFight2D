using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    [SerializeField] private TMP_Text _enemyName;
    [SerializeField] private Image _healthBar;
    private int _enemyHealth;
    private float _currentHealth;

    private void Start()
    {
        string enemyName = PlayerPrefs.GetString("EnemyName", "");
        _enemyName.text = enemyName;
        _enemyHealth = Random.Range(50, 101);
        _currentHealth = _enemyHealth;
    }

    public void EnemyHit()
    {
        if (_currentHealth > 0)
        {
            int hitPower = Random.Range(5, 11);
            _currentHealth -= hitPower;

            _healthBar.fillAmount = _currentHealth / _enemyHealth;
            Debug.Log($"currentHealth {_currentHealth} / _enemyHealth {_enemyHealth} = {_currentHealth / _enemyHealth}");
        }
    }
}
