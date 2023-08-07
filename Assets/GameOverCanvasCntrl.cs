using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverCanvasCntrl : MonoBehaviour
{
    public void OnClickMainMenuBtn()
    {
        SceneManager.LoadScene("MenuScene");
    }
}
