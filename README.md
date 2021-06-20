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

![Bezier curve](https://lh5.googleusercontent.com/H_5Cm28iYbV_JXahMbnHi3jJpGGOInNUYUWGINgex1zwIEIgpnGBqbcEQqEzYVmR7bL1TtF4Bo4ZL3CH45NBl8K-Ohjc-Fm-OhGeEGhhKPAVV8RrH75OnJYt5ewtPdVtd36mdopK)


Where n is the degree of the curve and<br/>
![Binomial](https://lh6.googleusercontent.com/MHQRrA3IfxRX1MCBX33NbGgqf4rr0P9Fl54pfkE39Caz50KrcdACAPS28DLJGm11GQG5SPFqG_FgIiY0D_XpRRf1WhfIPdMAiUM65Toaqho4ZoEEPU_CgOPdwrjrTe2HKRUl_hwV) are the Binomial coefficients that we can represent as below.
<br/>
![Binomial](https://lh6.googleusercontent.com/93PFiBmQsS_GCus0Rb1ohwssyyG3Pgx5QNAmBVIUFEstI03qdXd589rNaLgnwGlME8GByUWWEQ0o-bpIEQJPlpfYJsu9dd9SXCAoOu28jCR1vHWcVlNTJ5RX56C1zjnrjr9ZbVKn)
<br/>
We can simplify the main equation at the top to 

![Bezier Curve](https://lh3.googleusercontent.com/NDs1lHuiO-R5phS5HfM--hIFD9alKe3AkzFATpBRyX0GAqZlIZB4XJ5c0Aaa7K7BsSKM840SYs7qJbpfZXwRAUCzhrA8bULwBW2XxxLP2fn4t4IXglvEHB1qX2hBF441FcKowBe_)

where 

![Bernstein](https://lh4.googleusercontent.com/tDnfKr0Ty3ftF_AlUWUYBNT7bdBY6CUehdQ8_LHVeSfKyVk5rirefGGbFx15d1bvT5XyHFHf-vJ_dgC6UR78dnQ6ls4G2HcypZgFqZGPUkF542iCa1TrnzvNkJtCViNY_Bxu88Ll)

are known as <b>Bernstein basis polynomials </b> of degree n.

For an <b> n </b> degree curve, there will be <b>n + 1</b> control points. When the number of control points is two (or a degree of one; n = 1) a Bezier curve becomes a straight line and is equivalent to linear interpolation. When the number of control points is three (or a degree of 2; n = 2) a Bezier curve becomes a parabola.

Our first task will be to implement a bezier curve given a set of control points. You can find a lot of tutorials online on how to create a Bezier curve. However, for the sake of this tutorial, we will make our implementation of the Bezier curve in C#.



![Bezier Curve](https://github.com/shamim-akhtar/bezier-curve/blob/main/Bezier.jpg)
