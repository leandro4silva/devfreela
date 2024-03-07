﻿namespace DevFreela.Application.InputModels;


public class UpdateProjectInputModel
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public decimal TotalCost { get; set; }


    public UpdateProjectInputModel(
        int id, 
        string title, 
        string description, 
        decimal totalCost
    )
    {
        Id = id;
        Title = title;
        Description = description;
        TotalCost = totalCost;
    }
}
