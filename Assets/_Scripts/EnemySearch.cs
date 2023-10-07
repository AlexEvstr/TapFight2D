using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;
using Newtonsoft.Json;

public class Root
{
    public List<Result> results { get; set; }
}

public class Result
{
    public Name name { get; set; }
    public Picture picture { get; set; }
}

public class Name
{
    public string title { get; set; }
    public string first { get; set; }
    public string last { get; set; }
}

public class Picture
{
    public string large { get; set; }
    public string medium { get; set; }
    public string thumbnail { get; set; }
}

public class EnemySearch : MonoBehaviour
{
    [SerializeField] private GameObject _loadWindow;
    [SerializeField] private TMP_Text _playerName;
    [SerializeField] private TMP_Text _enemyName;
    [SerializeField] private Image _enemyImage;
    [SerializeField] private TMP_Text _coinsText;

    private string _url = "https://randomuser.me/api/";

    private void Start()
    {
        string playerName = PlayerPrefs.GetString("PlayerName", "");
        _playerName.text = playerName;
        int coinsQuantity = PlayerPrefs.GetInt("Coins", 0);
        _coinsText.text = coinsQuantity.ToString();
        SearchButton();

    }

    public void FightButton()
    {
        SceneManager.LoadScene("GameScene");
    }

    private IEnumerator SendRequest()
    {
        _loadWindow.SetActive(true);
        yield return new WaitForSeconds(0.5f);

        UnityWebRequest request = UnityWebRequest.Get(_url);
        yield return request.SendWebRequest();
        string myJsonResponse = request.downloadHandler.text;
        Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);

        string enemyName = myDeserializedClass.results[0].name.first;
        _enemyName.text = enemyName;
        PlayerPrefs.SetString("EnemyName", enemyName);

        string enemyImage = myDeserializedClass.results[0].picture.medium;
        UnityWebRequest webRequest = UnityWebRequestTexture.GetTexture(enemyImage);
        yield return webRequest.SendWebRequest();
        Texture texture = ((DownloadHandlerTexture)webRequest.downloadHandler).texture;
        _enemyImage.sprite = Sprite.Create((Texture2D)texture, new Rect(0, 0, texture.width, texture.height), Vector2.zero);

        _loadWindow.SetActive(false);
    }

    public void SearchButton()
    {
        StartCoroutine(SendRequest());
    }
}