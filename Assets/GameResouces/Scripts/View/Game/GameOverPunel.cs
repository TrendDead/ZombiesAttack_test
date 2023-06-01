using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverPunel : MonoBehaviour
{
    [SerializeField]
    private Text _scoreText;
    [SerializeField]
    private Button _button;

    private void OnEnable()
    {
        _button.onClick.AddListener(LoadMainMenu);
    }

    public void Init(float score)
    {
        _scoreText.text = $"¬аш счет: {score}";
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(LoadMainMenu);
    }

    private void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
