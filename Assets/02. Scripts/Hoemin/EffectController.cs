using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Hoemin
{
    /// <summary>
    /// �׽�Ʈ�� ����Ʈ ������
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

