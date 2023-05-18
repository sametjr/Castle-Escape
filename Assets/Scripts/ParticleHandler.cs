using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleHandler : MonoBehaviour
{
    #region Singleton
    private static ParticleHandler instance = null;
    public static ParticleHandler Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new GameObject("ParticleHandler").AddComponent<ParticleHandler>();
            }
            return instance;
        }
    }

    private void OnEnable()
    {
        instance = this;
    }
    #endregion

    public void PlayDeathParticles(Vector3 _pos)
    {
        GameObject particle = Instantiate(Prefabs.Instance.deathParticle, _pos, Quaternion.identity);
        Destroy(particle, 1f);
    }

    public void PlayLevelUpParticles(Vector3 _pos)
    {
        GameObject particle = Instantiate(Prefabs.Instance.levelUpParticle, _pos, Quaternion.identity);
        Destroy(particle, 1f);
    }

    public void PlayCollectableParticles(Vector3 _pos)
    {
        GameObject particle = Instantiate(Prefabs.Instance.collectableParticle, _pos, Quaternion.identity);
        Destroy(particle, 1f);
    }

    public void PlayDoorOpenParticles(Vector3 _pos)
    {
        GameObject particle = Instantiate(Prefabs.Instance.doorOpenParticle, _pos, Quaternion.identity);
        Destroy(particle, 1f);
    }
}
