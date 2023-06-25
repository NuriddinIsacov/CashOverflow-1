﻿// --------------------------------------------------------
// Copyright (c) Coalition of Good-Hearted Engineers
// Developed by CashOverflow Team
// --------------------------------------------------------

using System;
using System.Threading.Tasks;
using CashOverflow.Brokers.DateTimes;
using CashOverflow.Brokers.Loggings;
using CashOverflow.Brokers.Storages;
using CashOverflow.Models.Companies;

namespace CashOverflow.Services.Foundations.Companies
{
    public partial class CompanyService : ICompanyService
    {
        private readonly IStorageBroker storageBroker;
        private readonly IDateTimeBroker dateTimeBroker;
        private readonly ILoggingBroker loggingBroker;

        public CompanyService(
            IStorageBroker storageBroker,
            IDateTimeBroker dateTimeBroker,
            ILoggingBroker loggingBroker)
        {
            this.storageBroker = storageBroker;
            this.dateTimeBroker = dateTimeBroker;
            this.loggingBroker = loggingBroker;
        }

        public ValueTask<Company> RemoveCompanyByIdAsync(Guid companyId) =>
            TryCatch(async () =>
            {
                ValidateCompanyId(companyId);

                Company maybeCompany =
                    await this.storageBroker.SelectCompanyByIdAsync(companyId);

                ValidateStorageCompanyExists(maybeCompany, companyId);

                return await this.storageBroker.DeleteCompanyAsync(maybeCompany);
            });

    }
}
