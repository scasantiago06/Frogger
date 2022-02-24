using UnityEngine.Events;

namespace UnityEngine
{
    namespace Utilities
    {
        public class UnityEventListener : MonoBehaviour
        {
            #region Properties

            public UnityEvent onEnable, onDisable;
            public UnityEvent onAwake;
            public UnityEvent onStart, onUpdate, onFixedUpdate, onLateUpdate;

            #endregion Properties

            #region Unity functions

            private void OnDisable()
            {
                onDisable?.Invoke();
            }

            private void OnEnable()
            {
                onEnable?.Invoke();
            }

            private void Awake()
            {
                onAwake?.Invoke();
            }

            private void Start()
            {
                onStart?.Invoke();
            }

            private void Update()
            {
                onUpdate?.Invoke();
            }

            private void FixedUpdate()
            {
                onFixedUpdate?.Invoke();
            }

            private void LateUpdate()
            {
                onLateUpdate?.Invoke();
            }

            #endregion Unity functions
        }
    }
}