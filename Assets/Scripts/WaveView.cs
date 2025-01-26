using TMPro;
using UnityEngine;

public class WaveView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI waveText;
    [SerializeField] private WaveCounter waveCounter;

    private void OnEnable()
    {
        waveCounter.OnWaveUpdated += OnChange;
    }

    private void OnDisable()
    {
        waveCounter.OnWaveUpdated -= OnChange;
    }

    private void OnChange()
    {
        waveText.text = waveCounter.Wave.ToString();
    }
}