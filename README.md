<p align='left'>
  <a href="#">
    <img src="https://visitor-badge.glitch.me/badge?page_id=bezier-curve.visitor-badge" />        
  </a>
  <a href="https://www.linkedin.com/in/shamim-akhtar/">
    <img src="https://img.shields.io/badge/linkedin-%230077B5.svg?&flat-square&logo=linkedin&logoColor=white" />
  </a>
  <a href="mailto:shamim.akhtar@gmail.com">
    <img src="https://img.shields.io/badge/Gmail-D14836?flat-square&logo=gmail&logoColor=white" />        
  </a>
  <a href="https://www.facebook.com/faramiraSG/">
    <img src="https://img.shields.io/badge/Facebook-1877F2?flat-square&logo=facebook&logoColor=white" />        
  </a>
</p>

# Implement Bezier Curve using C# in Unity

![Bezier Curve](https://faramira.com/wp-content/uploads/2021/06/Bezier-930x620.jpg)

In this tutorial, we will learn how to implement the Bezier curve using C# in Unity. We will then create a sample application that displays the Bezier curve.
Read the tutorial on [Faramira.](https://faramira.com/implement-bezier-curve-using-csharp-in-unity/)

<p align='left'>
  <a href="#">
    <img src="https://img.shields.io/badge/Unity-2020.3.5f1-green" />        
  </a>
  <a href="#">
    <img src="https://img.shields.io/badge/%20-C%23-blue" />
  </a>
</p>

## Bezier Curve
A Bézier curve is a parametric curve defined by a set of points known as control points. It is widely used in computer graphics and related fields. For a more detailed understanding of Bezier curves, refer to the Wikipedia page.


The generic definition of a point in the Bezier curve is <br/>

> ![Bezier curve](https://github.com/shamim-akhtar/bezier-curve/blob/main/bez.jpg)


Where n is the degree of the curve and

> ![Binomial](https://github.com/shamim-akhtar/bezier-curve/blob/main/bino2.jpg)

are the Binomial coefficients that we can represent as below.

> ![Binomial](https://github.com/shamim-akhtar/bezier-curve/blob/main/bino.jpg)

We can simplify the main equation at the top to 

> ![Bezier Curve](https://github.com/shamim-akhtar/bezier-curve/blob/main/bezier2.jpg)

where 

> ![Bernstein](https://github.com/shamim-akhtar/bezier-curve/blob/main/bernstein.jpg)

are known as <b>Bernstein basis polynomials </b> of degree n.

For an <b> n </b> degree curve, there will be <b>n + 1</b> control points. When the number of control points is two (or a degree of one; n = 1) a Bezier curve becomes a straight line and is equivalent to linear interpolation. When the number of control points is three (or a degree of 2; n = 2) a Bezier curve becomes a parabola.

Our first task will be to implement a bezier curve given a set of control points. You can find a lot of tutorials online on how to create a Bezier curve. However, for the sake of this tutorial, we will make our implementation of the Bezier curve in C#.

## Bezier Curve Implementation
Create a new Unity2D project and name it Bezier. Create a new folder in the Assets directory and call it Scripts.

Right-click on the Scripts folder in the Unity Editor’s Project window and create a new C# script. Name it BezierCurve. Double-click and open it in Visual Studio or your favourite IDE. Remove Monobehavior (we do not want this class to derive from Monobehavior), the Start and the Update methods. The class should look like below.

```csharp
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BezierCurve
{
}
```
Now, let’s see what needs to be there in this class. At the least, we will require a function that returns an interpolated Bezier point given t, where t can be between 0 and 1 (both inclusive), and a list of control points. This function will correspond to the equation:

We can see that the inputs to the function are t and the list of control points. Go ahead and create the procedure that will return us a Bezier point given these two inputs.
```csharp
public class BezierCurve
{
    public static Vector3 Point3(float t, List<Vector3> controlPoints)
    {
    }
}
```
Note that we made the function static so that we do not have to instantiate a BezierCurve class to get the Bezeir points given a set of control points. This function should be self-sustainable and should do our job of calculating the Bezier point.

We now want to implement the actual calculation of the Bezier point. To do so, let’s analyze and break down the function below.

> ![Bezier](https://github.com/shamim-akhtar/bezier-curve/blob/main/bezier2.jpg)

where

> ![Bernstein](https://github.com/shamim-akhtar/bezier-curve/blob/main/bernstein.jpg)

and

> ![Binomial](https://github.com/shamim-akhtar/bezier-curve/blob/main/bino.jpg)

If we look from below to up, we will find that the three diagrams seem not too difficult to implement. Let’s start from the bottom. Calculate the Binomial coefficient with inputs n and i; both integer values.


To do so, we will have to calculate the values of 

> The Factorial of n,
> 
> The Factorial of i, and
> 
> The Factorial of (n – i).

We can implement a function called Factorial that calculates the factorial value given an integer input. Even better, we can precalculate the Factorial values of numbers up to a maximum value of n (let’s say 16 or 20) and use that. So for any Bezier curve that has a degree of this maximum value or less will be able to create the Bezier curve. Now, we can go beyond this maximum value and make a generic factorial function, but this value will suffice for our job for now.
```csharp
public class BezierCurve
{
    // a look up table for factorials. Capped to 16.
    private static float[] Factorial = new float[]
    {
        1.0f,
        1.0f,
        2.0f,
        6.0f,
        24.0f,
        120.0f,
        720.0f,
        5040.0f,
        40320.0f,
        362880.0f,
        3628800.0f,
        39916800.0f,
        479001600.0f,
        6227020800.0f,
        87178291200.0f,
        1307674368000.0f,
        20922789888000.0f,
    };
****
}


With this lookup table, we are okay to proceed with the implementation of the Binomial coefficient.

```csharp
    private static float Binomial(int n, int i)
    {
        float ni;
        float a1 = Factorial[n];
        float a2 = Factorial[i];
        float a3 = Factorial[n - i];
        ni = a1 / (a2 * a3);
        return ni;
    }
```
Note that the function is private as we will only allow internal access to this function. We did not do a validation check if n <= 16. We want the caller of this function to ensure that n <= 16.

Next, we will calculate the Bernstein basis polynomials shown by the following equation.


To do so, we will need to calculate the Binomial coefficient and the two power terms. We have already calculated the Binomial coefficient above. The below function shows the implementation of the calculation of Bernstein basis polynomials.

```csharp
    private static float Bernstein(int n, int i, float t)
    {
        float t_i = Mathf.Pow(t, i);
        float t_n_minus_i = Mathf.Pow((1 - t), (n - i));

        float basis = Binomial(n, i) * t_i * t_n_minus_i;
        return basis;
    }
```
Finally, we calculate the Bezier point as given by the equation below.


This calculation is just the summation of the Bernstein basis polynomials for all the control points. We can implement it as follows.

```csharp
    public static Vector3 Point3(float t, List<Vector3> controlPoints)
    {
        int N = controlPoints.Count - 1;
        if (N > 16)
        {
            Debug.Log("You have used more than 16 control points.");
            Debug.Log("The maximum control points allowed is 16.");
            controlPoints.RemoveRange(16, controlPoints.Count - 16);
        }
        if (t <= 0) return controlPoints[0];
        if (t >= 1) return controlPoints[controlPoints.Count - 1];

        Vector3 p = new Vector3();

        for(int i = 0; i < controlPoints.Count; ++i)
        {
            Vector3 bn = Bernstein(N, i, t) * controlPoints[i];
            p += bn;
        }

        return p;
    }
```
We have successfully implemented the calculation of a Bezier point for a given set of control points at an interval t.

If we want to get a whole list of Bezier points that represents the Bezier curve, then we will need to calculate the Bezier points for the entire duration starting from t = 0 (where the point is the same at the start control point) to t = 1 (where the point is the same as the end control point). The interval duration will depend on the nature of the problem and the distance of the points. For simplicity, we can use 0.01 as the interval. Choosing 0.01 as an interval will mean that there will be 100 points in the Bezier curve.

Let’s implement the method that returns the list of points representing the Bezier curve.

```csharp
    public static List<Vector3> PointList3(List<Vector3> controlPoints, float interval = 0.01f)
    {
        int N = controlPoints.Count - 1;
        if (N > 16)
        {
            Debug.Log("You have used more than 16 control points."); 
            Debug.Log("The maximum control points allowed is 16.");
            controlPoints.RemoveRange(16, controlPoints.Count - 16);
        }

        List<Vector3> points = new List<Vector3>();
        for (float t = 0.0f; t <= 1.0f + interval - 0.0001f; t += interval)
        {
            Vector3 p = new Vector3();
            for (int i = 0; i < controlPoints.Count; ++i)
            {
                Vector3 bn = Bernstein(N, i, t) * controlPoints[i];
                p += bn;
            }
            points.Add(p);
        }

        return points;
    }
```
Similarly, we can implement the same for Vector2 and List<Vector2>.



