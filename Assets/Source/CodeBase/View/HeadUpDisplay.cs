using System;
using Source.CodeBase.GameData;
using Source.CodeBase.Infrastructure.Presenters;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Source.CodeBase.View
{
    public class HeadUpDisplay : MonoBehaviour, IBotSpeedPresenter, ISpawnSpeedPresenter, IPathViewPresenter
    {
        public event Action<float> OnBotSpeedChanged;
        public event Action<float> OnSpawnSpeedChanged;

        [SerializeField] private Toggle _pathRenderer;
        [SerializeField] private Slider _botSpeed;
        [SerializeField] private TMP_Text _oneScore;
        [SerializeField] private TMP_Text _twoScore;

        public bool IsPathRendered => _pathRenderer.isOn;

        private void OnEnable()
        {
            OnBotSpeedChanged?.Invoke(_botSpeed.value);

            _botSpeed.onValueChanged.AddListener(OnPlayerSpeedChanged);
        }

        private void OnDisable()
        {
            _botSpeed.onValueChanged.RemoveListener(OnPlayerSpeedChanged);
        }

        public void Show()
        {
            gameObject.SetActive(true);
        }

        public void OnScoreChanged(Fraction fraction, int value)
        {
            switch (fraction)
            {
                case Fraction.One:
                    _oneScore.text = value.ToString();
                    break;

                case Fraction.Two:
                    _twoScore.text = value.ToString();
                    break;
            }
        }

        private void OnPlayerSpeedChanged(float value) =>
            OnBotSpeedChanged?.Invoke(value);
    }
}