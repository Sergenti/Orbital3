using System.Collections;
using System.Resources;
using Cinemachine;
using UnityEngine;

namespace Code.UI
{
    public class CameraShake : MonoBehaviour
    {
        [SerializeField] private float shakeDuration = 1f;
        private CinemachineVirtualCamera _camera;

        private float baseGain = 0f;

        private float baseFreq = 0f;
        // Start is called before the first frame update
        void Start()
        {
            _camera = GetComponent<CinemachineVirtualCamera>();
        }

        // Update is called once per frame
        void Update()
        {
        
        }

        public void SuddenShake(float magnitude)
        {
            _camera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = magnitude;
            _camera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_FrequencyGain = magnitude;
            StartCoroutine(Timer(shakeDuration));
        }

        private IEnumerator Timer(float duration)
        {
            yield return new WaitForSeconds(duration);
            Reset();
        }

        private void Reset()
        {
            _camera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_FrequencyGain = baseFreq;
            _camera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = baseGain;
        }
    }
}
