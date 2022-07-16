namespace Movement.Powerups
{
    public class Slow:PowerupVisitor
    {
        public float speedFactor;
        public float duration;
        public void Visit(Translator translator)
        {
            translator.currentSpeed *= speedFactor;
            translator.Invoke(nameof(translator.ResetValues), duration);
        }

        public void Visit(TopDownMovement topDownMovement)
        {
            topDownMovement.Speed *= speedFactor;
            topDownMovement.Invoke(nameof(topDownMovement.ResetValues), duration);
        }

        public Slow(float speedFactor, float duration)
        {
            this.speedFactor = speedFactor;
            this.duration = duration;
        }
    }
}