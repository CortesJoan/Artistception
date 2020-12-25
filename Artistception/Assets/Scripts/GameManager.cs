using System;
using UnityEngine;
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
        Instantiate(player);
        player.transform.position = this.transform.position;
        //   player.transform.position = GetLastCheckPoint();
    }

    private Vector3 GetLastCheckPoint()
    {
        throw new NotImplementedException();
    }
}
