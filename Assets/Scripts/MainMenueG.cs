using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenueG : MonoBehaviour
{
    
    public void StartGame()
    {
        SceneManager.LoadScene("latest"); // to start the game afetr press the button in main menue and load teh secne of first level that calledlatest).
    }
}
