using UnityEngine;

public class Singleton<T>: MonoBehaviour where T : Singleton<T>
{
  public static T Instance;

    protected void Awake()
    {
        if (Instance == null)
        {
            Instance = this as T;
            DontDestroyOnLoad(transform.parent?.gameObject ?? transform.gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }
}