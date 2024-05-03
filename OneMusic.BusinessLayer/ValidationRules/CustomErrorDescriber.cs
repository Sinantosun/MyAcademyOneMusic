﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneMusic.BusinessLayer.ValidationRules
{
    public class CustomErrorDescriber : IdentityErrorDescriber
    {
        public override IdentityError PasswordTooShort(int length)
        {
            return new IdentityError { Code = "PasswordTooShort" , Description="Şifre en az 6 karakterden oluşmalıdır." };
        }
        public override IdentityError PasswordRequiresDigit()
        {
            return new IdentityError { Code = "PasswordTooShort", Description = "Şifre en az bir rakam içermelidir." };
        }
        public override IdentityError PasswordRequiresLower()
        {
            return new IdentityError { Code = "PasswordRequiresLower", Description = "Şifre en az bir küçük harf içermelidir." };
        }
        public override IdentityError PasswordRequiresUpper()
        {
            return new IdentityError { Code = "PasswordRequiresUpper", Description = "Şifre en az bir büyük harf içermelidir." };
        }
        public override IdentityError PasswordRequiresNonAlphanumeric()
        {
            return new IdentityError { Code = "PasswordRequiresNonAlphanumeric", Description = "Şifre en az bir özel karakter içermelidir." };
        }
    }
}
