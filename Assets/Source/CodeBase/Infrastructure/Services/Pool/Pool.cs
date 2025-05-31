using System;
using System.Collections.Generic;
using UnityEngine;

namespace Source.CodeBase.Infrastructure.Services.Pool
{
    public class Pool<T> where T : MonoBehaviour
    {
        private readonly Func<T> _creator;
        private readonly Queue<T> _objects;

        public Pool(Func<T> creator)
        {
            _objects = new();
            _creator = creator;
        }

        public T Get()
        {
            T obj;

            if (_objects.Count > 0)
                obj = _objects.Dequeue();
            else
                obj = _creator.Invoke();

            return obj;
        }

        public void Put(T obj) => _objects.Enqueue(obj);
    }
}