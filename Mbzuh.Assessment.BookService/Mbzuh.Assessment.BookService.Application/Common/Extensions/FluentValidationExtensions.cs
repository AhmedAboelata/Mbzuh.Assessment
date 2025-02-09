namespace Mbzuh.Assessment.BookService.Application.Common.Extensions;

using System.Text.RegularExpressions;
using Mbzuh.Assessment.BookService.Domain.Constants;

internal static class FluentValidationExtensions
{
    internal static IRuleBuilderOptions<T, string> StringNotEmptyAndMaxLength<T>(this IRuleBuilder<T, string> ruleBuilder, int maxLength)
        => ruleBuilder.NotEmpty().MaximumLength(maxLength);

    internal static IRuleBuilderOptions<T, int> IntShouldBePositive<T>(this IRuleBuilder<T, int> ruleBuilder)
        => ruleBuilder.GreaterThan(0);

    internal static IRuleBuilderOptions<T, Guid> GuidNotEmpty<T>(this IRuleBuilder<T, Guid> ruleBuilder)
        => ruleBuilder.NotNull().NotEqual(Guid.Empty);

    internal static IRuleBuilderOptions<T, string> StringLength<T>(this IRuleBuilder<T, string> ruleBuilder, int minLength, int maxLength)
        => ruleBuilder.Length(minLength, maxLength);

    internal static IRuleBuilderOptions<T, int> IntRange<T>(this IRuleBuilder<T, int> ruleBuilder, int minYear, int maxYear)
        => ruleBuilder.GreaterThanOrEqualTo(minYear).LessThanOrEqualTo(maxYear);
    internal static IRuleBuilderOptions<T, string> NumbersOnly<T>(this IRuleBuilder<T, string> ruleBuilder, string fieldName = "ISBN")
        => ruleBuilder.Must(value => Regex.IsMatch(value, @"^[0-9]*$")).WithMessage(string.Format(Constants.StringAllowNumbersOnly, fieldName));
}
