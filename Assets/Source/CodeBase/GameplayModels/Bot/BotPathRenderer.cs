using Source.CodeBase.Infrastructure.Presenters;
using UnityEngine;
using UnityEngine.AI;
using Zenject;

namespace Source.CodeBase.GameplayModels.Bot
{
    [RequireComponent(typeof(NavMeshAgent), typeof(LineRenderer))]
    public class BotPathRenderer : MonoBehaviour
    {
        [SerializeField] private NavMeshAgent _agent;
        [SerializeField] private LineRenderer _lineRenderer;
        
        private IPathViewPresenter _presenter;

        [Inject]
        private void Construct(IPathViewPresenter presenter)
        {
            _presenter = presenter;
        }

        private void Awake()
        {
            _agent = GetComponent<NavMeshAgent>();
            _lineRenderer = GetComponent<LineRenderer>();
        }

        private void Update()
        {
            if (_agent.hasPath && _presenter.IsPathRendered)
            {
                Vector3[] corners = _agent.path.corners;
                _lineRenderer.positionCount = corners.Length;
                _lineRenderer.SetPositions(corners);
            }
            else
            {
                _lineRenderer.positionCount = 0;
            }
        }
    }
}