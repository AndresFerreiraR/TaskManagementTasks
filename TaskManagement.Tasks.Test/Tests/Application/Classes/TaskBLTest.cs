using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Extensions.Logging;
using Moq;
using TaskManagement.Tasks.Application.Classes;
using TaskManagement.Tasks.Application.Dto;
using TaskManagement.Tasks.Common.Common.Resources;
using TaskManagement.Tasks.Domain.Entities;
using TaskManagement.Tasks.Infrastructure.Interfaces;

namespace TaskManagement.Tasks.Test.Tests.Application.Classes
{
    public class TaskBLTest
    {
        private readonly Mock<ILogger<TaskBL>> _mockLogger;
        private readonly Mock<ITaskDL> _mockRepoTask;
        private readonly Mock<IMapper> _mockMapper;
        private readonly TaskBL _taskBL;

        public TaskBLTest()
        {
            _mockLogger = new Mock<ILogger<TaskBL>>();
            _mockRepoTask = new Mock<ITaskDL>();
            _mockMapper = new Mock<IMapper>();
            _taskBL = new TaskBL(_mockRepoTask.Object, _mockMapper.Object, _mockLogger.Object);
        }

        [Fact]
        public async Task CreateTaskCosmos_ShouldReturnSuccess_WhenTaskIsCreated()
        {
            // Arrange
            var taskCosmosDto = new TaskCosmosDbDto { Id = Guid.NewGuid(), CreationDate = DateTime.Now };
            var taskEntity = new TaskCosmosDb { Id = taskCosmosDto.Id, creationDate = DateTime.Now };

            _mockMapper.Setup(m => m.Map<TaskCosmosDb>(taskCosmosDto))
                .Returns(taskEntity);

            _mockRepoTask.Setup(r => r.CreateTaskCosmos(taskEntity))
                .Returns(Task.CompletedTask);

            // Act
            var response = await _taskBL.CreateTaskCosmos(taskCosmosDto);

            // Assert
            Assert.True(response.IsSuccess);
            Assert.Equal(TextResources.RECORD_CREATED, response.Message);
            _mockRepoTask.Verify(r => r.CreateTaskCosmos(It.IsAny<TaskCosmosDb>()), Times.Once);
        }
    }
}