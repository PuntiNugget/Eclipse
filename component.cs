namespace BasicGameEngine.Components
{
    /// <summary>
    /// The abstract base class for all Components.
    /// (e.g., Transform, SpriteRenderer, PhysicsBody, Collider)
    /// </summary>
    public abstract class Component
    {
        /// <summary>
        /// A reference to the GameObject this component is attached to.
        /// </summary>
        public GameObject GameObject { get; internal set; }

        /// <summary>
        /// A quick-access reference to this component's Transform.
        /// </summary>
        public Transform Transform => GameObject.Transform;

        /// <summary>
        /// Called every frame.
        /// Subclasses (like PhysicsBody) will override this
        /// to add their per-frame logic.
        /// </summary>
        public virtual void Update()
        {
            // Base implementation does nothing
        }
    }
}
