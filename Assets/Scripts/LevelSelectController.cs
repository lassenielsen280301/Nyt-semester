using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelectController : MonoBehaviour
{
    public void onTutorialClick()
    {
        SceneManager.LoadScene("Tutorial");
    }
    
    public void OnLvl1Click()
    {
        SceneManager.LoadScene("Level1");
    }

    public void OnLvl2Click()
    {
        SceneManager.LoadScene("Level2");
    }

    public void OnLvl3Click()
    {
        SceneManager.LoadScene("Level3");
    }

    public void OnLvl4Click()
    {
        SceneManager.LoadScene("Level4");
    }

    public void OnLvl5Click()
    {
        SceneManager.LoadScene("Level6");
    }

    public void OnLvl6Click()
    {
        SceneManager.LoadScene("Level7");
    }

    public void OnLvl7Click()
    {
        SceneManager.LoadScene("Level8");
    }

    public void OnLvl8Click()
    {
        SceneManager.LoadScene("Level9");
    }

    public void OnLvl9Click()
    {
        SceneManager.LoadScene("Level10");
    }

    public void OnLvl10Click()
    {
        SceneManager.LoadScene("Level11");
    }

    public void OnBackClick()
    {
        SceneManager.LoadScene("(Main menu) Stampe");
    }
}