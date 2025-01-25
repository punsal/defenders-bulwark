using UnityEngine;

namespace UI
{
    [RequireComponent(typeof(CanvasGroup))]
    public class UIView : MonoBehaviour
    {
        [SerializeField] private Game.Machine.State state = Game.Machine.State.Start;
        
        private CanvasGroup _canvasGroup;

        public Game.Machine.State State => state;
        
        private void Awake()
        {
            _canvasGroup = GetComponent<CanvasGroup>();
        }

        public void Appear()
        {
            _canvasGroup.alpha = 1;
        }

        public void Disappear()
        {
            _canvasGroup.alpha = 0;
        }
        
    }
}