using UnityEngine;
using UnityEngine.SceneManagement;

public class Navigation : MonoBehaviour
{
    public void StartStandartGame() => SceneManager.LoadScene("Game");
    public void QuitGame() => Application.Quit();
    public void BackToMenu() => SceneManager.LoadScene("Menu");
    public void StartKidsMode() => SceneManager.LoadScene("KidsModeGame");
}
