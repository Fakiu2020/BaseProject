using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using FluentValidation.Results;
using Microsoft.AspNetCore.Identity;

namespace Whoever.Common.Extensions
{
    public static class IdentityExtensions
    {
        public const string PasswordText = "Password";
        public const string EmailText = "Email";
        public const string UserNameText = "UserName";

        public static ICollection<ValidationFailure> ToValidationFailureList(this IdentityResult result)
        {
            return result.Errors.Select(x => new ValidationFailure(ParseCode(x.Code), x.Description)).ToList();
        }

        private static string ParseCode(string code)
        {
            
            if (code.Contains(PasswordText))
                return PasswordText;

            if (code.Contains(EmailText))
                return EmailText;

            if (code.Contains(UserNameText))
                return UserNameText;

            return null;
        }
    }
}
