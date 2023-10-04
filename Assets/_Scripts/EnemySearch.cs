using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;
using Newtonsoft.Json;
using System.Xml.Linq;

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
    [SerializeField] private TMP_Text _playerName;
    private string _url = "https://randomuser.me/api/";

    private void Start()
    {
        string playerName = PlayerPrefs.GetString("PlayerName", "");
        _playerName.text = playerName;
        StartCoroutine(SendRequest());
    }

    public void FightButton()
    {
        SceneManager.LoadScene("GameScene");
    }

    private IEnumerator SendRequest()
    {
        UnityWebRequest request = UnityWebRequest.Get(_url);
        yield return request.SendWebRequest();
        string myJsonResponse = request.downloadHandler.text;
        Debug.Log(myJsonResponse);
        Debug.Log("-----------------------------------------------------------------------------");

        Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
        Debug.Log(myDeserializedClass.results[0].name.first);
        Debug.Log(myDeserializedClass.results[0].picture.medium);
    }
}
