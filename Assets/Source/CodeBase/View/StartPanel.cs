using System;
using Source.CodeBase.Infrastructure.Presenters;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Source.CodeBase.View
{
    public class StartPanel : MonoBehaviour, IStartSignal, IBotCountPresenter
    {
        public event Action OnStartClicked;
        public event Action<int> OnBotCountChanged;

        [SerializeField] private Button _startButton;
        [SerializeField] private Slider _botCounter;
        [SerializeField] private TMP_Text _botCountText;

        private void OnEnable()
        {
            OnPlayerBotCountChanged(_botCounter.value);

            _startButton.onClick.AddListener(OnPlayerStartClicked);
            _botCounter.onValueChanged.AddListener(OnPlayerBotCountChanged);
        }

        private void OnDisable()
        {
            _startButton.onClick.RemoveListener(OnPlayerStartClicked);
            _botCounter.onValueChanged.RemoveListener(OnPlayerBotCountChanged);
        }

        public void Show() => gameObject.SetActive(true);

        public void Hide() => gameObject.SetActive(false);

        private void OnPlayerStartClicked() => OnStartClicked?.Invoke();

        private void OnPlayerBotCountChanged(float count)
        {
            _botCountText.text = count.ToString();
            OnBotCountChanged?.Invoke((int)count);
        }
    }
}