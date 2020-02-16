using Proyecto;
using System;
using UnityEngine;

namespace pc
{
    class pointChecker { 
      
        /* A utility function to calculate area of triangle  
        formed by (x1, y1) (x2, y2) and (x3, y3) */
        private double area(double x1, double y1, double x2,  
                           double y2, double x3, double y3) 
        { 
            return Math.Abs((x1 * (y2 - y3) + 
                             x2 * (y3 - y1) +  
                             x3 * (y1 - y2)) / 2.0); 
        } 
      
        /* A function to check whether point P(x, y) lies 
        inside the triangle formed by A(x1, y1), 
        B(x2, y2) and C(x3, y3) */
        public bool isInside(Tuple<double, double> t1, Tuple<double, double> t2, Tuple<double, double> t3, Vector3 t4) 
        { 

            double x1 = t1.Item1;
            double y1 = t1.Item2;
            double x2 = t2.Item1;
            double y2 = t2.Item2;
            double x3 = t3.Item1;
            double y3 = t3.Item2;
            double x = t4[0];
            double y = t4[1];
            Debug.Log("La posición es: " + x + "," + y);

            /* Calculate area of triangle ABC */
            double A = area(x1, y1, x2, y2, x3, y3); 
      
            /* Calculate area of triangle PBC */
            double A1 = area(x, y, x2, y2, x3, y3); 
      
            /* Calculate area of triangle PAC */
            double A2 = area(x1, y1, x, y, x3, y3); 
      
            /* Calculate area of triangle PAB */
            double A3 = area(x1, y1, x2, y2, x, y); 
      
            /* Check if sum of A1, A2 and A3 is same as A */
            return (A == A1 + A2 + A3); 
        } 
    }
}