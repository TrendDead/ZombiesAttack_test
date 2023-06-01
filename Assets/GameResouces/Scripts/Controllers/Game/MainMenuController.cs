using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    [SerializeField]
    private Text _scoreText;
    [SerializeField]
    private Button _startButton;

    private void OnEnable()
    {
        _scoreText.text = $"ћаксимально набранное количество очков: \n {Loader.MaxScore}";
        _startButton.onClick.AddListener(LoadGameScene);
    }

    private void OnDisable()
    {
        _startButton?.onClick.RemoveListener(LoadGameScene);
    }

    private void LoadGameScene()
    {
        SceneManager.LoadScene(1);
    }
}
