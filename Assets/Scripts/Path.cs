using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path
{
    protected Point startPoint;
    protected Point endPoint;
    protected Point currentPoint;
    protected double velocity;

    public Path(Point startPoint, Point endPoint, Point currentPoint, double velocity)
    {
        this.startPoint = startPoint;
        this.endPoint = endPoint;
        this.currentPoint = currentPoint;
        this.velocity = velocity;
    }

    public Point getStartPoint()
    {
        return this.startPoint;
    }

    public Point getEndPoint()
    {
        return this.endPoint;
    }

    public Point getCurrentPoint()
    {
        return this.currentPoint;
    }

    public double getVelocity()
    {
        return this.velocity;
    }

    public void setStartPoint(Point newStartPoint)
    {
        this.startPoint.setX(newStartPoint.getX());
        this.startPoint.setY(newStartPoint.getY());
    }

    public void setEndPoint(Point newEndPoint)
    {
        this.endPoint.setX(newEndPoint.getX());
        this.endPoint.setY(newEndPoint.getY());
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
        //Inherited in each specific path class
        return null;                              
    }
}
