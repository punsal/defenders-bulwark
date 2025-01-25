using UnityEngine;

public class Player : MonoBehaviour
{
    public void Lose()
    {
        Game.Machine.ChangeState(Game.Machine.State.Over);
    }
}
