using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using static System.Linq.Expressions.Expression;
using System.Text.RegularExpressions;
using System.Reflection;

namespace LinqFormatString
{
    public partial class StringToExpressionConverter
    {
        private const string PlaceholdersPattern = @"{\d+}";

        private static Expression<TDelegate> CreateLambda<TDelegate>(string str)
        {
            if (str == null)
            {
                throw new ArgumentNullException(nameof(str));
            }

            var parameters = GetParameters<TDelegate>();

            if (!parameters.Any())
            {
                return Lambda<TDelegate>(Constant(str));
            }

            IEnumerable<Expression> concatParameters = GetConcatMethodParameters<TDelegate>(str, parameters).ToList();
            MethodInfo concatMethod = typeof(string)
                .GetMethod(nameof(string.Concat), new[] { typeof(object), typeof(object) });
            Expression expression = concatParameters
                .Aggregate((p, c) => Call(concatMethod, p, c));

            return Lambda<TDelegate>(expression, parameters);
        }

        private static IEnumerable<Expression> GetConcatMethodParameters<TDelegate>(string str, ParameterExpression[] parameters)
        {
            var matches = GetPlaceholdersMatches(str);
            Validate(matches, parameters);
            var lastMatchEnd = matches.Last().Index + matches.Last().Length;

            return matches
                .Select(m => GetPlaceholderValue(m.Value))
                .Zip(GetSplittedStrings(str, matches), (i, s) => new
                {
                    Text = Constant(s),
                    Parameter = ConvertToString(parameters[i])
                })
                .SelectMany(m => new[] { m.Text, m.Parameter })
                .Concat(lastMatchEnd != str.Length ?
                    new[] { Constant(str.Substring(lastMatchEnd)) } : new Expression[] { });
        }

        private static void Validate(IEnumerable<Match> matches, ParameterExpression[] parameters)
        {
            var sortedParametersIndexes = matches
                .Select(m => GetPlaceholderValue(m.Value))
                .OrderBy(n => n)
                .ToList();

            if (sortedParametersIndexes.Any() && (sortedParametersIndexes
                .Zip(sortedParametersIndexes.Skip(1), (f, s) => s - f)
                .Any(n => n != 0 && n != 1) || sortedParametersIndexes.First() != 0))
            {
                throw new FormatException("Placeholder indexes must be consecutive and start from 0.");
            }

            var parametersIndexesCount = sortedParametersIndexes
                .Distinct()
                .Count();

            if (parametersIndexesCount != parameters.Length)
            {
                throw new FormatException(
                    $"Provided number of arguments: {parameters.Length} is wrong. Expected {parametersIndexesCount} arguments.");
            }
        }

        private static ParameterExpression[] GetParameters<TDelegate>()
        {
            var delegateArgumensTypes = typeof(TDelegate).GenericTypeArguments;

            return delegateArgumensTypes
                .Take(delegateArgumensTypes.Length - 1)
                .Select(t => Parameter(t))
                .ToArray();
        }

        private static IEnumerable<Match> GetPlaceholdersMatches(string str) => Regex.Matches(str, PlaceholdersPattern).Cast<Match>();

        private static IEnumerable<string> GetSplittedStrings(string str, IEnumerable<Match> matches)
        {
            var lastMatchEnd = matches.Last().Index + matches.Last().Length;
            return new[] { str.Substring(0, matches.First().Index) }
                .Concat(matches
                .Zip(matches.Skip(1), (f, s) => new
                {
                    Start = f.Index + f.Length,
                    End = s.Index
                })
                .Select(m => str.Substring(m.Start, m.End - m.Start))
                .Concat(new[] { str.Substring(lastMatchEnd) }));
        }

        private static int GetPlaceholderValue(string s) => int.Parse(s.Substring(1, s.Length - 2));

        private static Expression ConvertToString(Expression expression) =>
            Call(Expression.Convert(expression, typeof(object)), typeof(object).GetMethod(nameof(object.ToString)));
    }

    public partial class StringToExpressionConverter
    {
        public static Expression<Func<string>> Convert(string str)
        {
            return CreateLambda<Func<string>>(str);
        }

        public static Expression<Func<T0, string>> Convert<T0>(string str)
        {
            return CreateLambda<Func<T0, string>>(str);
        }

        public static Expression<Func<T0, T1, string>> Convert<T0, T1>(string str)
        {
            return CreateLambda<Func<T0, T1, string>>(str);
        }

        public static Expression<Func<T0, T1, T2, string>> Convert<T0, T1, T2>(string str)
        {
            return CreateLambda<Func<T0, T1, T2, string>>(str);
        }

        public static Expression<Func<T0, T1, T2, T3, string>> Convert<T0, T1, T2, T3>(string str)
        {
            return CreateLambda<Func<T0, T1, T2, T3, string>>(str);
        }

        public static Expression<Func<T0, T1, T2, T3, T4, string>> Convert<T0, T1, T2, T3, T4>(string str)
        {
            return CreateLambda<Func<T0, T1, T2, T3, T4, string>>(str);
        }

        public static Expression<Func<T0, T1, T2, T3, T4, T5, string>> Convert<T0, T1, T2, T3, T4, T5>(string str)
        {
            return CreateLambda<Func<T0, T1, T2, T3, T4, T5, string>>(str);
        }

        public static Expression<Func<T0, T1, T2, T3, T4, T5, T6, string>> Convert<T0, T1, T2, T3, T4, T5, T6>(string str)
        {
            return CreateLambda<Func<T0, T1, T2, T3, T4, T5, T6, string>>(str);
        }

        public static Expression<Func<T0, T1, T2, T3, T4, T5, T6, T7, string>> Convert<T0, T1, T2, T3, T4, T5,
            T6, T7>(string str)
        {
            return CreateLambda<Func<T0, T1, T2, T3, T4, T5, T6, T7, string>>(str);
        }

        public static Expression<Func<T0, T1, T2, T3, T4, T5, T6, T7, T8, string>> Convert<T0, T1, T2, T3, T4,
            T5, T6, T7, T8>(string str)
        {
            return CreateLambda<Func<T0, T1, T2, T3, T4, T5, T6, T7, T8, string>>(str);
        }

        public static Expression<Func<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, string>> Convert<T0, T1, T2, T3,
            T4, T5, T6, T7, T8, T9>(string str)
        {
            return CreateLambda<Func<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, string>>(str);
        }

        public static Expression<Func<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, string>> Convert<T0, T1, T2,
            T3, T4, T5, T6, T7, T8, T9, T10>(string str)
        {
            return CreateLambda<Func<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, string>>(str);
        }
    }
}


