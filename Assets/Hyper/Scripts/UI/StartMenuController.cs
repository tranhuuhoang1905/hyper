using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor; // Thêm thư viện UnityEditor để dùng ExitPlaymode()
#endif

public class StartMenuManager : MonoBehaviour
{
    public void OnStartButtonPressed()
    {
        Debug.Log("check abcdef");
        SceneManager.LoadScene("BattleSelectScene"); // 🔥 Chuyển sang màn hình Loading trước khi vào game
    }

    public void OnExitButtonPressed()
    {
        #if UNITY_EDITOR
            EditorApplication.ExitPlaymode(); // 🔥 Thoát hẳn Unity Editor khi nhấn Exit
        #else
            Application.Quit(); // 🔥 Thoát game khi đã build
        #endif
        Debug.Log("Game Quit");
    }
}