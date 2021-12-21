using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path
{
    protected Shape[] shapes;
    protected double velocity;
    protected Point currentPoint;
    protected int currentShapeIndex;

    public Path(Shape[] shapes, double velocity)
    {
        for (int i = 0; i < shapes.Length; i++)
        {
            this.shapes[i] = shapes[i];
        }
        this.currentPoint = shapes[0].getStartPoint();
        this.velocity = velocity;
        currentShapeIndex = 0;
    }

    public Point getCurrentPoint()
    {
        return this.currentPoint;
    }

    public double getVelocity()
    {
        return this.velocity;
    }

    public void setCurrentPoint(Point newCurrentPoint)
    {
        this.currentPoint.setX(newCurrentPoint.getX());
        this.currentPoint.setY(newCurrentPoint.getY());
    }

    public void setVelocity(double newVelocity) {
        this.velocity = newVelocity;
    }

    public virtual Point getNextPoint() {
        switch (shapes[this.currentShapeIndex].getName())
        {
            case "Line":
                Line line = (Line)shapes[currentShapeIndex];
                double incline = line.calcIncline();
                if (incline == 0) {
                    if (currentPoint.getX() + velocity > line.getEndPoint().getX())
                    {
                        this.currentShapeIndex++;
                        return shapes[this.currentShapeIndex].getStartPoint();
                    } 
                } else if (incline == double.MaxValue)
                {
                    if (currentPoint.getY() + velocity > line.getEndPoint().getY())
                    {
                        this.currentShapeIndex++;
                        return shapes[this.currentShapeIndex].getStartPoint();
                    }
                }
                else
                {
                    double newX = currentPoint.getX() + velocity;
                    if (newX > shapes[currentShapeIndex].getEndPoint().getX())
                    {
                        this.currentShapeIndex++;
                        return shapes[this.currentShapeIndex].getStartPoint();
                    }
                    else
                    {
                        double newY = (incline * (newX - currentPoint.getX())) + currentPoint.getY();
                        return new Point(newX, newY);
                    }
                }
                return null; // problem, shouldn't reach this
            case "Circle":
                //TODO implement
                return null;
        }
        return null;
    }
}
