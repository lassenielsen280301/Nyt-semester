using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelectController : MonoBehaviour
{
    [Header("Level Buttons (order: 0 = Tutorial, 1 = Level1, etc.)")]
    public Button[] levelButtons;

    [Header("Scene Names (same order as buttons)")]
    public string[] levelSceneNames;

    private void Start()
    {
        // Initialize unlocked level (Tutorial = 0)
        if (!PlayerPrefs.HasKey("UnlockedLevel"))
        {
            PlayerPrefs.SetInt("UnlockedLevel", 0);
            PlayerPrefs.Save();
        }

        int unlockedLevel = PlayerPrefs.GetInt("UnlockedLevel", 0);

        // Enable only unlocked buttons
        for (int i = 0; i < levelButtons.Length; i++)
        {
            if (levelButtons[i] != null)
                levelButtons[i].interactable = (i <= unlockedLevel);
        }
    }

    /// <summary>
    /// Assign this to all buttons OnClick
    /// </summary>
    /// <param name="levelIndex">0 = Tutorial, 1 = Level1, etc.</param>
    public void LoadLevel(int levelIndex)
    {
        if (levelIndex < 0 || levelIndex >= levelSceneNames.Length)
        {
            Debug.LogError("Invalid level index!");
            return;
        }

        int unlockedLevel = PlayerPrefs.GetInt("UnlockedLevel", 0);

        if (levelIndex <= unlockedLevel)
        {

            string sceneName = levelSceneNames[levelIndex];
            Time.timeScale = 1f;
            SceneManager.LoadScene(sceneName);

        }
        else
        {
            Debug.Log("Level locked!");
        }
    }

    public void OnBackClick()
    {
        SceneManager.LoadScene("(Main menu) Stampe");
    }
}
