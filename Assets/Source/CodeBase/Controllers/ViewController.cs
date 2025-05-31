using System;
using Source.CodeBase.GameData;
using Source.CodeBase.View;
using Zenject;

namespace Source.CodeBase.Controllers
{
    public class ViewController : IInitializable, IDisposable
    {
        private readonly StartPanel _startPanel;
        private readonly HeadUpDisplay _headUpDisplay;
        private readonly IReadOnlyScore _score;

        public ViewController(
            StartPanel startPanel,
            HeadUpDisplay headUpDisplay,
            IReadOnlyScore score)
        {
            _startPanel = startPanel;
            _headUpDisplay = headUpDisplay;
            _score = score;
        }

        public void Initialize()
        {
            ShowStartPanel();
            
            _startPanel.OnStartClicked += HideStartPanel;
            _score.OnScoreChanged += _headUpDisplay.OnScoreChanged;
        }

        public void Dispose()
        {
            _startPanel.OnStartClicked -= HideStartPanel;
            _score.OnScoreChanged -= _headUpDisplay.OnScoreChanged;
        }

        private void ShowStartPanel() =>
            _startPanel.Show();

        private void HideStartPanel()
        {
            _startPanel.Hide();
            _headUpDisplay.Show();
        }
    }
}