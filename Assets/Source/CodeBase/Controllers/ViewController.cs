using System;
using Source.CodeBase.View;
using Zenject;

namespace Source.CodeBase.Controllers
{
    public class ViewController : IInitializable, IDisposable
    {
        private readonly StartPanel _startPanel;
        private readonly HeadUpDisplay _headUpDisplay;

        public ViewController(StartPanel startPanel, HeadUpDisplay headUpDisplay)
        {
            _startPanel = startPanel;
            _headUpDisplay = headUpDisplay;
        }

        public void Initialize()
        {
            ShowStartPanel();

            _startPanel.OnStartClicked += HideStartPanel;
        }

        public void Dispose() =>
            _startPanel.OnStartClicked -= HideStartPanel;

        private void ShowStartPanel() =>
            _startPanel.Show();

        private void HideStartPanel()
        {
            _startPanel.Hide();
            _headUpDisplay.Show();
        }
    }
}