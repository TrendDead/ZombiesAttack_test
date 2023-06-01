using System.Collections.Generic;
using UnityEngine;

public abstract class MonoCache : MonoBehaviour
{
    public static List<MonoCache> AllUpdate = new List<MonoCache>(100);

    private void OnEnable() => AllUpdate.Add(this);
    private void OnDisable() => AllUpdate.Remove(this);

    public abstract void Run();
}
