using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Bootstrap : MonoBehaviour
{
    [SerializeField] private GameObject _firstEnterWindow;
    [SerializeField] private GameObject _enemySearchWindow;

    [SerializeField] private GameObject _inputField;
    [SerializeField] private TMP_Text _welcomeText;

    [SerializeField] private Button _continue;

    private void Start()
    {
        _continue.interactable = false;
        string playerName = PlayerPrefs.GetString("PlayerName", "");
        if (playerName != "")
        {
            GoToLoadWindow();
        }
    }

    public void OnSubmitName(string name)
    { 
        PlayerPrefs.SetString("PlayerName", name);
        if (name != "")
        {
            _inputField.SetActive(false);
            _welcomeText.text = $"Добро пожаловать, {name}!";
            _continue.interactable = true;
        }
    }

    public void GoToLoadWindow()
    {
        _firstEnterWindow.SetActive(false);
        _enemySearchWindow.SetActive(true);
    }
}