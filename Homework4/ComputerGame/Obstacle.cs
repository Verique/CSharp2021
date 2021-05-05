﻿namespace ComputerGame
{
    public class Obstacle
    {
        public Obstacle(double obstacleSize, double obstaclePosX, double obstaclePosY)
        {
            ObstacleSize = obstacleSize;
            ObstaclePosX = obstaclePosX;
            ObstaclePosY = obstaclePosY;
        }

        public double ObstacleSize { get; private set; }
        public double ObstaclePosX { get; private set; }
        public double ObstaclePosY { get; private set; }
    }
}