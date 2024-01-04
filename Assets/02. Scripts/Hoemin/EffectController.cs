using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Hoemin
{
    /// <summary>
    /// 테스트용 이펙트 관리자
    /// </summary>
    public class EffectController : MonoBehaviour
    {
        private ParticleSystem particle;

        private void Start()
        {
            particle = GetComponent<ParticleSystem>();
            
        }

        private void Update()
        {
            if(particle.isStopped)
            {
                Destroy(this.gameObject);
            }
        }
    }
}

