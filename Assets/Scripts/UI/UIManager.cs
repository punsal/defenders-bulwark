using System.Collections.Generic;
using UnityEngine;

namespace UI
{
    public class UIManager : MonoBehaviour
    {
        [Header("UIViews")]
        [SerializeField] private List<UIView> uiViews;
        
        private void OnEnable()
        {
            Game.Machine.OnStateChangeEvent += OnStateChanged;
        }

        private void OnDisable()
        {
            Game.Machine.OnStateChangeEvent -= OnStateChanged;
        }

        private void OnStateChanged(Game.Machine.State state)
        {
            foreach (var uiView in uiViews)
            {
                if (uiView.State != state)
                {
                    uiView.Disappear();
                }
                else
                {
                    uiView.Appear();
                }
            }
        }
    }
}
