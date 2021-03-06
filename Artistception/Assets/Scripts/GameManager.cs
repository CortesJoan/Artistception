﻿using Cinemachine;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager _instance;
    public int level = 0;
    public PlayerBehaviour player;
    private void Awake()
    {
        if (GameManager._instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(this);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        ChangeLevel(level);

    }
    public void OnLevelWasLoaded(int level)
    {
        if (level == 2)
        {
            FindObjectOfType<Button>().GetComponent<Button>().onClick.AddListener(() => {
                ChangeLevel(3);
            });

        }
        if (level == 3) {
            transform.position = new Vector3(2,9.88f,0);
        }
        player = FindObjectOfType<PlayerBehaviour>();
    }

    // Update is called once per frame
    void Update()
    {
     
    }
    public void ChangeLevel(int newLevel)
    {

        SceneManager.LoadScene(newLevel);
    }
    public void IncreaseLevel()
    {
        level++;
        ChangeLevel(level);
    }

    internal void KillPlayer()
    {

        player = Instantiate(player);
        player.transform.position = this.transform.position;
       FindObjectOfType<CinemachineVirtualCamera>().Follow = player.gameObject.transform;
        
        //   player.transform.position = GetLastCheckPoint();
    }

    private Vector3 GetLastCheckPoint()
    {
        throw new NotImplementedException();
    }
}
