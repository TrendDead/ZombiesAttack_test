using UnityEngine;

public class PlayerInputSelecter : MonoBehaviour
{
    [SerializeField]
    private GameObject[] _inputs;

    private IPlayerInput[] _playerinputs;

    public IPlayerInput GetInoutSystem(int selectInputType) 
    {
        _playerinputs = GetComponentsInChildren<IPlayerInput>();

        for (int i = 0; i < _playerinputs.Length; i++)
        {
            _inputs[i].SetActive(i == selectInputType);
        }

        return _playerinputs[selectInputType]; 
    }
}
 