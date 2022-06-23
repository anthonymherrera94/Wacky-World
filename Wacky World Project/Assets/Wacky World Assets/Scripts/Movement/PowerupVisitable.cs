namespace Movement
{
    public interface PowerupVisitable
    {
        public void Accept(PowerupVisitor visitor);
        public void ResetValues();
    }
}