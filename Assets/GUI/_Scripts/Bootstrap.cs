using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Bootstrap : MonoBehaviour
{
    [SerializeField] private GameObject FirstEnterWindow;

    [SerializeField] private GameObject _inputField;
    [SerializeField] private TMP_Text _welcomeText;

    [SerializeField] private Button _continue;

    private void Start()
    {
        _continue.interactable = false;
        string enter = PlayerPrefs.GetString("FirstEnter", "");
        if (enter != "")
        {
            FirstEnterWindow.SetActive(false);
        }
    }

    public void OnSubmitName(string name)
    {
        _inputField.SetActive(false);
        _welcomeText.text = $"Добро пожаловать, {name}!";
        PlayerPrefs.SetString("FirstEnter", name);
        _continue.interactable = true;
    }
}
