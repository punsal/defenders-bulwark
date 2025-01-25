namespace Destroyables
{
    public class KamikazeDestroyer : Destroyer
    {
        protected override void Destroy(Destroyable destroyable)
        {
            base.Destroy(destroyable);
            Destroy(gameObject);
        }
    }
}