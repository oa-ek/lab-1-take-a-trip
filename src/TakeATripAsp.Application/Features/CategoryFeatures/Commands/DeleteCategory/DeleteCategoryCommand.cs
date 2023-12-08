﻿using MediatR;

namespace TakeTripAsp.Application.Features.CategoryFeatures.Commands.DeleteCategory
{
    public class DeleteCategoryCommand
        : IRequest<int>
    {
        public int Id { get; set; }
    }
}
