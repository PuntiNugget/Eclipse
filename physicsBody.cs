namespace BasicGameEngine.Components
{
    /// <summary>
    /// As requested, this component adds Physics.
    /// It gives the object velocity and gravity.
    /// </summary>
    public class PhysicsBody : Component
    {
        /// <summary>
        /// The current velocity of the object, in units per second.
        /// </summary>
        public Vector2 Velocity { get; set; } = Vector2.Zero;
        
        public float Mass { get; set; } = 1.0f;
        
        /// <summary>
        /// Multiplier for gravity. 0 = no gravity. 1 = full gravity.
        /// </summary>
        public float GravityScale { get; set; } = 1.0f;

        /// <summary>
        /// This is the "physics function" you mentioned.
        /// This is the main physics update, called every frame.
        /// </summary>
        public override void Update()
        {
            // 1. Apply Gravity
            if (GravityScale > 0)
            {
                // Add gravitational force to velocity
                Velocity += Physics.Gravity * GravityScale * Time.DeltaTime;
            }

            // 2. Apply Velocity to Position
            // This is how physics "creates movement"
            if (Velocity.Length() > 0)
            {
                Transform.Position += Velocity * Time.DeltaTime;
            }
        }

        /// <summary>
        /// An example "physics function" to add force,
        /// which changes velocity.
        /// </summary>
        public void AddForce(Vector2 force)
        {
            // F = ma, so a = F/m
            // v = u + at -> v += (F/m) * t
            // We'll apply the force over one frame (Time.DeltaTime)
            Velocity += (force / Mass) * Time.DeltaTime;
        }
    }
}
