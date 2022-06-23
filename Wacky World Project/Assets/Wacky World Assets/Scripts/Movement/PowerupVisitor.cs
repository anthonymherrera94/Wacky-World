namespace Movement
{
    public interface PowerupVisitor
    {
        void Visit(Translator translator);
        void Visit(TopDownMovement topDownMovement);
    }
}