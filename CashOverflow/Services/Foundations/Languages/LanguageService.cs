﻿using System;
using System.Threading.Tasks;
using CashOverflow.Brokers.DateTimes;
using CashOverflow.Brokers.Loggings;
using CashOverflow.Brokers.Storages;
using CashOverflow.Models.Languages;

namespace CashOverflow.Services.Foundations.Languages
{
    public partial class LanguageService : ILanguageService
    {
        private readonly IStorageBroker storageBroker;
        private readonly ILoggingBroker loggingBroker;
        private readonly IDateTimeBroker dateTimeBroker;

        public LanguageService(
            IDateTimeBroker dateTimeBroker,
            ILoggingBroker loggingBroker,
            IStorageBroker storageBroker)
        {
            this.dateTimeBroker = dateTimeBroker;
            this.loggingBroker = loggingBroker;
            this.storageBroker = storageBroker;
        }

        public ValueTask<Language> RemoveLanguageByIdAsync(Guid languageId)
        {
            throw new NotImplementedException();
        }
    }
}
