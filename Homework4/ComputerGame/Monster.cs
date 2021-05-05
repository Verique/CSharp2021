﻿namespace ComputerGame
{
    public class Monster
    {
        public double DefaultSpeed = 3;
        
        public Monster(double xPos, double yPos)
        {
            XPos = xPos;
            YPos = yPos;
        }
        
        public virtual double Speed => DefaultSpeed;
        public double XPos { get; private set; }
        public double YPos { get; private set; }
        
        public void Move(Player target, Obstacle[] obstacles) { }
    }
}