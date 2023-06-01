using UnityEngine;

public static class Loader
{
    private const string SCORE = "Score";

    public static float MaxScore
    {
        get
        {
            return PlayerPrefs.GetFloat(SCORE, 0);
        }
        set 
        { 
            PlayerPrefs.SetFloat(SCORE, value);
        }
    }
}
