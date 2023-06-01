using UnityEngine;

public class GloabalUpdate : MonoBehaviour
{
    private void Update()
    {
        for (int i = 0; i < MonoCache.AllUpdate.Count; i++)
        {
            MonoCache.AllUpdate[i].Run();
        }
    }
}
