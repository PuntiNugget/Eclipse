namespace BasicGameEngine.Components
{
    /// <summary>
    /// As requested, the base class for all colliders.
    /// The physics engine would look for these.
    /// </summary>
    public abstract class Collider : Component
    {
        /// <summary>
        /// If true, this collider detects overlaps but doesn't
        /// cause a solid collision.
        /// </summary>
        public bool IsTrigger { get; set; } = false;

        public Vector2 Offset { get; set; } = Vector2.Zero;

        // In a real engine, this would have:
        // public abstract bool IsCollidingWith(Collider other);
        // public event Action<Collision> OnCollisionEnter;
    }
}
