using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

    public AudioClip coin;
    private AudioSource audioSource;

    public GameObject pannelLost;
    public GameObject pannelPause;
    public GameObject LeftBtn;
    public GameObject RightBtn;
    public GameObject JumpBtn;
    public Text ScoreText;
    public Text TimeText;
    public Text CoinsText;
    public GameObject PauseBtn;
    public Text textDied;

    private float MaxTime = 400f;
    public bool Death = false;
    [HideInInspector]
    public int score;
    [HideInInspector]
    public int coins;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Coin"))
        {
            audioSource.PlayOneShot(coin);
            coins += 10;
            Destroy(collision.gameObject);
        }
    }
    
    private void Update()
    {
        MaxTime -= Time.deltaTime;
        TimeText.text = "Time:" + "\n" + Mathf.RoundToInt(MaxTime).ToString();
        ScoreText.text = "Score:" + "\n" + score;
        CoinsText.text = "Coins:" + "\n" + coins;
        if(MaxTime <= 0f)
        {
            pannelLost.SetActive(true);
            textDied.text = "TIME UP!";
            SetUp(false);
        }
        if (Death)
        {
            pannelLost.SetActive(true);
            textDied.text = "YOU DIED!";
            SetUp(false);
        }
    }

    
    public void Pause()
    {
        if(Time.timeScale == 1f)
        {
            Time.timeScale = 0f;
            pannelPause.SetActive(true);
            SetUp(false);
        }
    }

    public void Reload()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Continue()
    {
        if(Time.timeScale == 0)
        {
            Time.timeScale = 1f;
            pannelPause.SetActive(false);
            SetUp(true);
        }
    }

    public void Exit()
    {
        Application.Quit();
    }

    private void SetUp(bool stt)
    {
        LeftBtn.SetActive(stt);
        RightBtn.SetActive(stt);
        JumpBtn.SetActive(stt);
        ScoreText.gameObject.SetActive(stt);
        TimeText.gameObject.SetActive(stt);
        CoinsText.gameObject.SetActive(stt);
        gameObject.SetActive(stt);
        PauseBtn.SetActive(stt);
    }
}
