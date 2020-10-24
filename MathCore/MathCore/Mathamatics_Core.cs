using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathCore
{
    public class Mathamatics_Core
    {
        #region Floats
        public static float Add_Float(float a, float b)
        {
            return a + b;
        }

        public static float Subtract_BigFromSmall_Float(float a, float b)
        {
            if (a < b)
            {
                return a - b;
            }
            else
            {
                return b - a;
            }
        }

        public static float Subtract_SmallFromBig_Float(float a, float b)
        {
            if (a > b)
            {
                return a - b;
            }
            else
            {
                return b - a;
            }
        }

        public static float Multiply_Float(float a, float b)
        {
            return a * b;
        }

        public static float Divide_Positive_Float(float a, float b)
        {
                return a / b;
        }

        public static float Divide_Negative_Float(float a, float b)
        {
            if (a < b)
            {
                return a / b;
            }
            else
            {
                return b / a;
            }
        }

        public static int Percentage(float a , float b)
        {
            float valueToMultiply = Divide_Positive_Float(a, b);
            float percentage = Multiply_Float(valueToMultiply,100);
            return (int)Math.Ceiling(percentage);
        }

        public static float Percentage_UnRounded(float a, float b)
        {
            float valueToMultiply = Divide_Positive_Float(a, b);
            float percentage = Multiply_Float(valueToMultiply, 100);
            return percentage;
        }
        #endregion

        #region Integers
        public static float Add_Integer(float a, float b)
        {
            return a + b;
        }

        public static float Subtract_SmallFromBig_Integer(int a, int b)
        {
            if (a < b)
            {
                return a - b;
            }
            else
            {
                return b - a;
            }
        }

        public static float Subtract_BigFromSmall_Integer(int a, int b)
        {
            if (a > b)
            {
                return a - b;
            }
            else
            {
                return b - a;
            }
        }

        public static float Multiply_Integer(int a, int b)
        {
            return a * b;
        }

        public static float Divide_SmallFromBig_Integer(int a, int b)
        {
            if (a < b)
            {
                return a / b;
            }
            else
            {
                return b / a;
            }
        }

        public static float Divide_BigFromSmall_Integer(int a, int b)
        {
            if (a > b)
            {
                return a / b;
            }
            else
            {
                return b / a;
            }
        }
        #endregion
    }
}
