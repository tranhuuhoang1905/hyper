using UnityEngine.SceneManagement;
using UnityEngine;

public class BattleSelectUIController : MonoBehaviour
{
    private int levelToLoad; // Biến để lưu tên Scene level tiếp theo
    public void OnBattleSelectButtonPressed(int level)
    {
        PlayerPrefs.SetInt("LevelIndex", level);
        PlayerPrefs.Save(); // Lưu dữ liệu
        SceneManager.LoadScene("LoadingScene"); // 🔥 Chuyển sang màn hình Loading trước khi vào game

    }
    
    public void OnExitButtonPressed()
    {
        SceneManager.LoadScene("StartScene"); // 🔥 Chuyển sang màn hình Loading trước khi vào game
    }
}
