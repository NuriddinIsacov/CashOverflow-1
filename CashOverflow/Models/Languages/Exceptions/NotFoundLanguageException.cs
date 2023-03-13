﻿using System;
using Xeptions;

namespace CashOverflow.Models.Languages.Exceptions
{
    public class NotFoundLanguageException : Xeption
    {
        public NotFoundLanguageException(Guid languageId):
            base(message : $"Couldn't found languae with id: {languageId}.")
        {       
        }
    }
}
