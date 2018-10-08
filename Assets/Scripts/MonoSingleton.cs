using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class MonoSingleton<T> : MonoBehaviour where T : MonoBehaviour
{
    static T _instance;

    private static object _lock = new object();

    //public static T Instance
    //{
    //    get
    //    {
    //        return s_instance ?? new GameObject(typeof(T).Name).AddComponent<T>();
    //    }
    //}

    public static T Instance
    {
        get
        {
            // Reloading of the scene behaves as if it were closing the application, destroying the GameManager singleton

            //if (applicationIsQuitting)
            //{
            //    Debug.LogWarning("[Singleton] Instance '" + typeof(T) +
            //        "' already destroyed on application quit." +
            //        " Won't create again - returning null.");
            //    return null;
            //}

            lock (_lock)
            {
                if (_instance == null)
                {
                    _instance = (T)FindObjectOfType(typeof(T));

                    if (FindObjectsOfType(typeof(T)).Length > 1)
                    {
                        Debug.LogError("[Singleton] Something went really wrong " +
                            " - there should never be more than 1 singleton!" +
                            " Reopening the scene might fix it.");
                        return _instance;
                    }

                    if (_instance == null)
                    {
                        GameObject singleton = new GameObject();
                        _instance = singleton.AddComponent<T>();
                        singleton.name = "(singleton) " + typeof(T).ToString();

                        DontDestroyOnLoad(singleton);

                        Debug.Log("[Singleton] An instance of " + typeof(T) +
                            " is needed in the scene, so '" + singleton +
                            "' was created with DontDestroyOnLoad.");
                    }
                    else
                    {
                        Debug.Log("[Singleton] Using instance already created: " +
                            _instance.gameObject.name);
                    }
                }

                return _instance;
            }
        } //end get
    } //end Instance

    //protected virtual void Awake()
    //{
    //    if (_instance)
    //    {
    //        Debug.LogWarning("A Singleton instance was previously initialized.");
    //        Destroy(gameObject);
    //        return;
    //    }

    //    _instance = GetComponent<T>();
    //    DontDestroyOnLoad(gameObject);
    //}

    //protected virtual void OnEnable()
    //{
    //    if (!_instance)
    //        _instance = GetComponent<T>();
    //}

    //private static bool applicationIsQuitting = false;
    protected virtual void OnDestroy()
    {
        if (_instance != GetComponent<T>())
            return;

        //applicationIsQuitting = true;

        _instance = null;
    }
}
