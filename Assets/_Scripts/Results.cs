using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Results : MonoBehaviour
{
    [SerializeField] private TMP_Text _enemyName;
    [SerializeField] private TMP_Text _coinsCollected;

    private void Start()
    {
        string enemyName = PlayerPrefs.GetString("EnemyName", "");
        _enemyName.text = "Бой с " + enemyName;

        _coinsCollected.text = Random.Range(100, 1001).ToString();
    }

    public void ContinueButton()
    {
        SceneManager.LoadScene("WelcomeScene");
    }
}