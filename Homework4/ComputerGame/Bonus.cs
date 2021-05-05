namespace ComputerGame
{
    public class Bonus
    {
        const int DefaultScore = 5;
        
        public Bonus(double xPos, double yPos)
        {
            XPos = xPos;
            YPos = yPos;
        }

        public virtual int Score => DefaultScore;
        public double XPos { get; private set; }
        public double YPos { get; private set; }
    }
}