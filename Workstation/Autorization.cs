namespace Workstation
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using System.Security.Cryptography;
    using System.Text;

    internal abstract class AuthorizationMethods
    {
        public static readonly char[] AllowedToLoginСharacters = { '-', '.', '\'', '_' };

        private static readonly char[] AllowedToPasswordСharacters = { '-', '.', '\'', '_' };

        public static Users Authorization(string login, string password, ref string errorMessage)
        {
            if (login != string.Empty)
            {
                if (password == string.Empty)
                {
                    errorMessage += "Введите пароль";
                    return null;
                }

                Users user;
                using (var readContext = new MorgueEntities())
                {
                    user = readContext.Users.FirstOrDefault(t => t.login == login);
                    if (user == null)
                    {
                        errorMessage += "Пользователя с таким логином не существует";
                        return null;
                    }
                }

                if (user.password == GenerateHash(password, user.salt))
                {
                    return user;
                }

                errorMessage += "Неверный пароль";
                return null;
            }

            errorMessage += "Введите логин";
            return null;
        }

        [SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1408:ConditionalExpressionsMustDeclarePrecedence", Justification = "Reviewed. Suppression is OK here.")]
        public static bool Registration(string login, string password, string role, ref string errorMessage)
        {
            var errorFlag = false;

            #region Проверка логина

            if (login == string.Empty)
            {
                errorMessage += "Логин не может быть меньше 8 символов\n";
                errorFlag = true;
            }

            var containOnlyAllowedToLoginCharacters = true;
            foreach (var character in login)
            {
                containOnlyAllowedToLoginCharacters &= AllowedToLoginСharacters.Contains(character) ||
                                                character >= 'a' && character <= 'z' ||
                                                character >= 'A' && character <= 'Z' ||
                                                character >= '0' && character <= '9';
            }

            if (!containOnlyAllowedToLoginCharacters)
            {
                errorMessage += "Логин может содержать только цифры, буквы латинского алфавита и символы: - . ' _\n";
                errorFlag = true;
            }  

            #endregion

            #region Проверка пароля
            // TODO: Добавить ограничения на пароль
            if (password.Trim(' ') == string.Empty)
            {
                errorMessage += "Пароль не может быть меньше 8 символов\n";
                errorFlag = true;
            }

            var containOnlyAllowedToPasswordCharacters = true;
            foreach (var character in password)
            {               
                containOnlyAllowedToPasswordCharacters &= AllowedToPasswordСharacters.Contains(character) ||
                                                character >= 'a' && character <= 'z' ||
                                                character >= 'A' && character <= 'Z' ||
                                                character >= '0' && character <= '9';
            }

            if (!containOnlyAllowedToPasswordCharacters)
            {
                errorMessage += "Пароль может содержать только цифры, буквы латинского алфавита и символы: - . ' _ , ^ ( ) \n";
                errorFlag = true;
            }

            try
            {
                if (password[0] == ' ' || password.Last() == ' ')
                {
                    errorMessage += "Пароль не должен начинаться или заканчиваться пробелом\n";
                    errorFlag = true;
                }
            }
            catch (Exception)
            {
                // ignore
            }

            #endregion

            #region Проверка роли

            if (role == string.Empty)
            {
                errorMessage += "Введите роль пользователя\n";
                errorFlag = true;
            }

            #endregion

            if (errorFlag)
            {
                return false;
            }

            #region Регистрация

            using (var readInsertContext = new MorgueEntities())
            {
                if (readInsertContext.Users.FirstOrDefault(t => t.login == login) != null)
                {
                    errorMessage += "Пользователь с таким логином уже зарегистрирован\n";
                    return false;
                }

                var newSalt = GenerateSalt();
                var hashedPassword = GenerateHash(password, newSalt);
                var newUser = new Users
                {
                    login = login,
                    password = hashedPassword,
                    salt = newSalt,
                    role = role,
                    dateOfReg = DateTime.Now
                };
                readInsertContext.Users.Add(newUser);
                readInsertContext.SaveChanges();
            }

            return true;

            #endregion
        }

        private static string GenerateHash(string password, string salt)
        {
            return Convert
                .ToBase64String(SHA512
                    .Create()
                    .ComputeHash(Encoding.UTF8.GetBytes(password + salt)));
        }

        private static string GenerateSalt()
        {
            var p = new RNGCryptoServiceProvider();
            var salt = new byte[64];
            p.GetBytes(salt);
            return Convert.ToBase64String(salt);
        }
    }
}