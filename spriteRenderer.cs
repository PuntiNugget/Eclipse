namespace BasicGameEngine.Components
{
    /// <summary>
    /// As requested, this component holds the data
    /// for rendering a sprite.
    /// </summary>
    public class SpriteRenderer : Component
    {
        /// <summary>
        /// This would be a reference to a Texture2D or image.
        /// We'll use a string path for this simulation.
        /// </summary>
        public string SpritePath { get; set; } = "default.png";

        /// <summary>
        /// The color to tint the sprite.
        /// </summary>
        public System.Drawing.Color Color { get; set; } = System.Drawing.Color.White;

        /// <summary>
        /// The sorting order for rendering.
        /// </summary>
        public int OrderInLayer { get; set; } = 0;
    }
}
