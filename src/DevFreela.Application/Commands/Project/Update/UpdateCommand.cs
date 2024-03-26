﻿
using MediatR;

namespace DevFreela.Application.Commands.Project.Update;

public class UpdateCommand : IRequest<Unit>
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public decimal TotalCost { get; set; }

    public UpdateCommand(int id, string title, string description, decimal totalCost)
    {
        Id = id;
        Title = title;
        Description = description;
        TotalCost = totalCost;
    }
}
