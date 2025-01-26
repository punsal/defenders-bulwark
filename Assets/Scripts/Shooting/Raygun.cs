namespace Shooting
{
    public class Raygun : AShooter
    {
        protected override void Fire()
        {
            var bullet = Instantiate(Data.Prefab, transform.position, transform.rotation);
            bullet.transform.parent = transform;
        }
    }
}