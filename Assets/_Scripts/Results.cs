using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Results : MonoBehaviour
{
    [SerializeField] private TMP_Text _enemyName;
    [SerializeField] private TMP_Text _coinsCollected;
    private int _coinsQuantity;
    private int _coinsSum;

    private void Start()
    {
        string enemyName = PlayerPrefs.GetString("EnemyName", "");
        _enemyName.text = "Бой с " + enemyName;
        _coinsQuantity += Random.Range(100, 1001);
        _coinsCollected.text = _coinsQuantity.ToString();
        _coinsSum = PlayerPrefs.GetInt("Coins", 0);
        PlayerPrefs.SetInt("Coins", _coinsQuantity + _coinsSum);
    }

    public void ContinueButton()
    {
        SceneManager.LoadScene("WelcomeScene");
    }
}