using System;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

namespace Source.CodeBase.Controllers
{
    [RequireComponent(typeof(NavMeshAgent), typeof(NavMeshObstacle))]
    public class AgentCorrector : MonoBehaviour
    {
        public Transform Target; // Точка назначения

        [Header("Настройки")] 
        public float stopDistance = 1f;
        public float stuckCheckDelay = 1f;
        public float offsetRadius = 1f;

        private NavMeshAgent _agent;
        private NavMeshObstacle _obstacle;

        private Vector3 finalTarget;
        private float checkTimer = 0f;
        private Vector3 lastPosition;
        private bool isStuck = false;

        private void Awake()
        {
            _agent = GetComponent<NavMeshAgent>();
            _obstacle = GetComponent<NavMeshObstacle>();
        }

        private void Start()
        {
            // Случайный приоритет обхода
            _agent.avoidancePriority = Random.Range(30, 60);
            _agent.obstacleAvoidanceType = ObstacleAvoidanceType.HighQualityObstacleAvoidance;

            // Начинаем движение
            MoveToTarget();
        }

        private void Update()
        {
            checkTimer += Time.deltaTime;

            // Проверка "достигли ли цели"
            if (!_agent.pathPending && _agent.remainingDistance <= stopDistance)
            {
                EnableObstacleMode();
            }
            else
            {
                DisableObstacleMode();
            }

            // Проверка застревания
            if (checkTimer >= stuckCheckDelay)
            {
                float moved = Vector3.Distance(transform.position, lastPosition);
                if (moved < 0.05f && _agent.remainingDistance > stopDistance + 0.5f)
                {
                    if (!isStuck)
                    {
                        isStuck = true;
                        MoveToTarget(); // перепрокладываем
                    }
                }
                else
                {
                    isStuck = false;
                }

                lastPosition = transform.position;
                checkTimer = 0f;
            }
        }

        public void MoveToTarget()
        {
            if (Target == null) return;

            finalTarget = GetOffsetTarget(Target.position);
            if (_agent.enabled)
            {
                _agent.SetDestination(finalTarget);
            }
        }

        private Vector3 GetOffsetTarget(Vector3 center)
        {
            Vector2 offset = Random.insideUnitCircle * offsetRadius;
            return center + new Vector3(offset.x, 0f, offset.y);
        }

        private void EnableObstacleMode()
        {
            if (_agent.enabled)
            {
                _agent.enabled = false;
                _obstacle.enabled = true;
            }
        }

        private void DisableObstacleMode()
        {
            if (!_agent.enabled)
            {
                _obstacle.enabled = false;
                _agent.enabled = true;
                _agent.SetDestination(finalTarget); // восстанавливаем цель
            }
        }
    }
}