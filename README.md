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



