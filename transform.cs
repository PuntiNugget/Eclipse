namespace BasicGameEngine.Components
{
    /// <summary>
    /// REQUIRED component. As requested, this stores the
    /// Position, Rotation, and Scale of the GameObject.
    /// The Move, Rotate, and Scale tools manipulate this.
    /// </summary>
    public class Transform : Component
    {
        public Vector2 Position { get; set; } = Vector2.Zero;
        public float Rotation { get; set; } = 0.0f; // In degrees
        public Vector2 Scale { get; set; } = Vector2.One;

        // In a real engine, this would also have methods like
        // Translate(Vector2 direction), Rotate(float angle), etc.
    }
}
