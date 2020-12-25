using UnityEngine;
using UnityEngine.UI;

public class PortalBehaviour : MonoBehaviour
{
    private ParticleSystem ps;
    //public GUIText endLevelText;
    bool hasEnded;
    //public string nextLevel;
    public AudioClip onEnter;
    public GameManager gameManager;


    // Use this for initialization
    public Text FinishLevelText;
    void Start()
    {
        ps = GetComponent<ParticleSystem>();
        gameManager = GameObject.FindObjectOfType<GameManager>();
        //	endLevelText.transform.position = new Vector2 (.5f, .5f);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    
         if (collision.tag == "Player")
        {
            Debug.Log("hello");
        }

        if (ps.isPlaying)
        {
            if (collision.tag == "Player")
            {
                //	endLevelText.gameObject.SetActive (true);
                hasEnded = true;

                Time.timeScale = 0;
                /*
                 * 
                 * //TODO codigo audio
                 * 
                 * */
                Time.timeScale = 1f;
                gameManager.IncreaseLevel();
            }

        }
        else
        {
            print("Recull tots els orbes per a activar el portal");

        }

    }
}
