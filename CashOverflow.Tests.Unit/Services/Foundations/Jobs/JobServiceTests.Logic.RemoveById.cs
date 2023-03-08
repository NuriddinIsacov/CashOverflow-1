﻿// --------------------------------------------------------
// Copyright (c) Coalition of Good-Hearted Engineers
// Developed by CashOverflow Team
// --------------------------------------------------------

using System;
using System.Threading.Tasks;
using CashOverflow.Models.Jobs;
using FluentAssertions;
using Force.DeepCloner;
using Moq;
using Xunit;

namespace CashOverflow.Tests.Unit.Services.Foundations.Jobs
{
    public partial class JobServiceTests
    {
        [Fact]
        public async Task ShouldRemoveJobByIdAsync()
        {
            // given
            var randomId = Guid.NewGuid();
            Guid inputJobId = randomId;
            Job randomJob = CreateRandomJob();
            Job storageJob = randomJob;
            Job expectedInputJob = storageJob;
            Job deletedJob = expectedInputJob;
            Job expectedJob = deletedJob.DeepClone();

            this.storageBrokerMock.Setup(broker =>
              broker.SelectJobByIdAsync(inputJobId))
                  .ReturnsAsync(storageJob);

            this.storageBrokerMock.Setup(broker =>
                broker.DeleteJobAsync(expectedInputJob))
                    .ReturnsAsync(deletedJob);

            // when
            Job actualJob = await this.jobService
                .RemoveJobByIdAsync(inputJobId);
            
            //then
            actualJob.Should().BeEquivalentTo(expectedJob);

            this.storageBrokerMock.Verify(broker =>
                broker.SelectJobByIdAsync(inputJobId), Times.Once);

            this.storageBrokerMock.Verify(broker =>
                broker.DeleteJobAsync(expectedInputJob), Times.Once);

            this.storageBrokerMock.VerifyNoOtherCalls();
            this.loggingBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBroker.VerifyNoOtherCalls();
        }
    }
}
