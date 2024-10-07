using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour, IDamageable
{
    private static GameManager Instance;
    private HudManager hudManager;
    private PlayerUI playerUI;
    private int maxLives = 3;
    private int live = 3;

    private bool isPlaying = false;
    private float playTime = 0;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        hudManager = FindObjectOfType<HudManager>();
        playerUI = hudManager.GetComponent<PlayerUI>();

        playerUI.OnPlayBtn += HandlePlay;
        playerUI.OnReturnBtn += HandleReturn;

        LoadLevel(SceneManager.GetActiveScene().name);
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlaying)
        {
            playTime += Time.deltaTime;
            hudManager.SetGameTime(playTime);
        }
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    private void LoadLevel(string levelName)
    {
        if (levelName == "Menu")
        {
            hudManager.SetMenu(Menu.Main);
            LoadScene("Menu");
        } else if (levelName == "Result")
        {
            ResultScreenLoad();
            LoadScene("Result");
        } else
        {
            hudManager.SetMenu(Menu.Gameplay);
            LoadScene("Level1");
        }
    }

    private void HandlePlay()
    {
        live = maxLives;
        hudManager.GainLife(live);
        playTime = 0;
        isPlaying = true;
        LoadLevel("Level1");
    }

    private void HandleReturn()
    {
        LoadLevel("Menu");        
    }

    public void TakeDamage(int damage)
    {
        live -= 1;
        hudManager.DropLife();

        if (live <= 0)
        {
            LoadLevel("Result");
        } else
        {
            LoadScene("Level1");
        }
    }

    public void WinGame()
    {
        LoadLevel("Result");
    }

    private void ResultScreenLoad()
    {
        isPlaying = false;
        hudManager.SetEndGameTime(playTime);

        if (live > 0)
        {
            hudManager.PlayerWin();
        }
        else
        {
            hudManager.PlayerLost();
        }
        hudManager.SetMenu(Menu.Result);
    }
}
