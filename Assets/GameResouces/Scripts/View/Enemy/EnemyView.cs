using UnityEngine;
using UnityEngine.UI;

public class EnemyView : MonoBehaviour
{
    [SerializeField]
    private Slider _slider;

    public void UpdateView(float healthPercent)
    {
        _slider.value = healthPercent;
    }
}
