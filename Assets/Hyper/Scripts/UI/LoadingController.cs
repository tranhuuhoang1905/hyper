using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingManager : MonoBehaviour
{
    [SerializeField] private Slider progressBar; // Thanh tiến trình

    void Start()
    {
        StartCoroutine(LoadBattleScene()); // 🔥 Bắt đầu tải Battle Scene
    }

    IEnumerator LoadBattleScene()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync("BattleScene");
        operation.allowSceneActivation = false; // 🔥 Ngăn Battle Scene tự động load khi chưa xong

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);
            progressBar.value = progress; // Cập nhật progress bar

            if (operation.progress >= 0.9f) // 🔥 Khi load gần xong (progress = 0.9)
            {
                yield return new WaitForSeconds(1f); // Giả lập thời gian chờ 1 giây
                operation.allowSceneActivation = true; // 🔥 Kích hoạt Battle Scene
            }

            yield return null;
        }
    }
}
