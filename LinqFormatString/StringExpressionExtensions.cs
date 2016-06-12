using System;
using System.Linq.Expressions;

namespace LinqFormatString
{
    public static partial class StringExpressionExtensions
    {
        public static Expression<Func<string>> ToExpression(this string str)
        {
            return StringToExpressionConverter.Convert(str);
        }

        public static Expression<Func<T0, string>> ToExpression<T0>(this string str)
        {
            return StringToExpressionConverter.Convert<T0>(str);
        }

        public static Expression<Func<T0, T1, string>> ToExpression<T0, T1>(this string str)
        {
            return StringToExpressionConverter.Convert<T0, T1>(str);
        }

        public static Expression<Func<T0, T1, T2, string>> ToExpression<T0, T1, T2>(this string str)
        {
            return StringToExpressionConverter.Convert<T0, T1, T2>(str);
        }

        public static Expression<Func<T0, T1, T2, T3, string>> ToExpression<T0, T1, T2, T3>(this string str)
        {
            return StringToExpressionConverter.Convert<T0, T1, T2, T3>(str);
        }

        public static Expression<Func<T0, T1, T2, T3, T4, string>> ToExpression<T0, T1, T2, T3, T4>(this string str)
        {
            return StringToExpressionConverter.Convert<T0, T1, T2, T3, T4>(str);
        }

        public static Expression<Func<T0, T1, T2, T3, T4, T5, string>> ToExpression<T0, T1, T2, T3, T4, T5>(this string str)
        {
            return StringToExpressionConverter.Convert<T0, T1, T2, T3, T4, T5>(str);
        }

        public static Expression<Func<T0, T1, T2, T3, T4, T5, T6, string>> ToExpression<T0, T1, T2, T3, T4, T5, T6>(this string str)
        {
            return StringToExpressionConverter.Convert<T0, T1, T2, T3, T4, T5, T6>(str);
        }

        public static Expression<Func<T0, T1, T2, T3, T4, T5, T6, T7, string>> ToExpression<T0, T1, T2, T3, T4,
            T5, T6, T7>(this string str)
        {
            return StringToExpressionConverter.Convert<T0, T1, T2, T3, T4, T5, T6, T7>(str);
        }

        public static Expression<Func<T0, T1, T2, T3, T4, T5, T6, T7, T8, string>> ToExpression<T0, T1, T2, T3,
            T4, T5, T6, T7, T8>(this string str)
        {
            return StringToExpressionConverter.Convert<T0, T1, T2, T3, T4, T5, T6, T7, T8>(str);
        }

        public static Expression<Func<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, string>> ToExpression<T0, T1, T2,
            T3, T4, T5, T6, T7, T8, T9>(this string str)
        {
            return StringToExpressionConverter.Convert<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9>(str);
        }

        public static Expression<Func<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, string>> ToExpression<T0, T1,
            T2, T3, T4, T5, T6, T7, T8, T9, T10>(this string str)
        {
            return StringToExpressionConverter.Convert<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(str);
        }
    }
}