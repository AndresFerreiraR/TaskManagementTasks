using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using TaskManagement.Tasks.Application.Common.GenericValidator;
using TaskManagement.Tasks.Application.Dto;

namespace TaskManagement.Tasks.Application.Common.Validations
{
    public class TaskCosmosDbDtoValidation : BaseValidator<TaskCosmosDbDto>
    {
        public TaskCosmosDbDtoValidation()
        {
            RuleFor(c => c.Name).NotEmpty().NotNull().WithMessage("Name cannot be null or empty");
            RuleFor(c => c.Priority).NotEmpty().NotNull().WithMessage("Priority cannot be null or empty");
            RuleFor(c => c.State).NotEmpty().NotNull().WithMessage("State cannot be null or empty");
        }        
    }
}