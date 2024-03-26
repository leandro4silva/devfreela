﻿using Dapper;
using DevFreela.Application.Services.Interfaces;
using DevFreela.Application.ViewModels;
using DevFreela.Infrastructure.Persistence;
using Microsoft.Extensions.Configuration;
using MySqlConnector;

namespace DevFreela.Application.Services.Implementations;

public class SkillService : ISkillService
{
    private readonly DevFreelaDbContext _dbContext;
    private readonly string _connectionString;

    public SkillService(DevFreelaDbContext dbContext, IConfiguration configuration)
    {
        _dbContext = dbContext;
        _connectionString = configuration.GetConnectionString("DevfreelaDb")!;
    }

    public List<SkillViewModel> GetAll()
    {
        using (var sqlConnection = new MySqlConnection(_connectionString))
        {
            sqlConnection.Open();
            var script = "SELECT Id, Description FROM Skills";

            return sqlConnection.Query<SkillViewModel>(script).ToList();
        }
    }
}
