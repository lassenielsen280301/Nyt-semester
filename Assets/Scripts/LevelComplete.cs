using UnityEngine;

public class LevelComplete : MonoBehaviour
{
    public int levelNumber; // Set this in Inspector (1 = Tutorial, 2 = Level1, etc.)

    public void CompleteLevel()
    {
        int unlockedLevel = PlayerPrefs.GetInt("UnlockedLevel", 1);

        if (levelNumber >= unlockedLevel)
        {
            PlayerPrefs.SetInt("UnlockedLevel", levelNumber + 1);
            PlayerPrefs.Save();
        }
        Debug.Log("UnlockedLevel is now: " + PlayerPrefs.GetInt("UnlockedLevel"));

    }
}
