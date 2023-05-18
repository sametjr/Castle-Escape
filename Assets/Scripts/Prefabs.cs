using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prefabs : MonoBehaviour
{
    #region Singleton
    private static Prefabs instance = null;
    public static Prefabs Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new GameObject("Prefabs").AddComponent<Prefabs>();
            }
            return instance;
        }
    }

    private void OnEnable()
    {
        instance = this;
    }
    #endregion

    [Header("Particles")]
    public GameObject deathParticle;
    public GameObject levelUpParticle;
    public GameObject collectableParticle;
    public GameObject doorOpenParticle;
}
