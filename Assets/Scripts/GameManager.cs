using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private List<GameObject> playerList = new List<GameObject>();

    float timer = -1.0f;

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(timer > 0)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene("MainScene");
            }
        }
    }

    public static void AddPlayer(GameObject player)
    {
        instance.playerList.Add(player);
    }

    public static void RemovePlayer(GameObject player)
    {
        instance.playerList.Remove(player);
        if(instance.playerList.Count == 1)
        {
            GameObject obj = GameObject.Find("WinScreen").transform.GetChild(0).gameObject;
            obj.SetActive(true);
            obj.GetComponentInChildren<Text>().text = "Player " + instance.playerList[0].GetComponent<PlayerController>().controllerNumber.ToString() + " Wins";
            instance.timer = 3.0f;
        }
    }
}
