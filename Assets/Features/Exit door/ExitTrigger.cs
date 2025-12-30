using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitManager : MonoBehaviour
{
    private ExitManager exitManager;

    public GameObject circlePlayer;
    public GameObject squarePlayer;

    public Collider2D circleExit;
    public Collider2D squareExit;

    public bool circleInside = false;
    public bool squareInside = false;

    public string nextSceneName;

    public int currentLevelIndex;

    private void Start()
    {

    }

    public void CheckBothPlayers()
    {
        if (circleInside == true && squareInside == true)
      {
        Debug.Log("JUBII");

        PlayerPrefs.SetInt(
            "UnlockedLevel",
            Mathf.Max(PlayerPrefs.GetInt("UnlockedLevel", 0), currentLevelIndex + 1)
            
        );
        Debug.Log("UnlockedLevel is now: " + PlayerPrefs.GetInt("UnlockedLevel", -1));
        Debug.Log("currentLevelIndex = " + currentLevelIndex);


        PlayerPrefs.Save();

        SceneManager.LoadScene(nextSceneName);
    }
    }
}