using Ardalis.Result;
using Ardalis.Result.FluentValidation;
using Haseroz.DevKit.AspNetCore.SampleMinimalApi.Models;
using Haseroz.DevKit.AspNetCore.SampleMinimalApi.Validators;

namespace Haseroz.DevKit.AspNetCore.SampleMinimalApi.Services;

public class SkuService
{
    private readonly IReadOnlyCollection<Sku> _dbSet = [new() { Id = 1, Code = "SKU001" }];

    public Result<Sku> Get(int _)
    {
        return Result.Unauthorized();
    }

    public Result<IReadOnlyCollection<Sku>> List()
    {
        return Result.Success(_dbSet);
    }

    public Result<Sku> Create(string code)
    {
        var sku = new Sku()
        {
            Id = 2,
            Code = code
        };

        var validator = new SkuValidator();

        var result = validator.Validate(sku);
        if (!result.IsValid)
        {
            return Result.Invalid(result.AsErrors());
        }

        if (_dbSet.Any(x => x.Code == sku.Code))
        {
            return Result.Conflict($"Sku ({sku.Code}) already exists in the system.");
        }

        return Result<Sku>.Created(sku, $"/Skus/{sku.Id}");
    }

    public Result Update(int _, string __)
    {
        return Result.Forbidden();
    }

    public Result Delete(int id)
    {
        if (!_dbSet.Any(x => x.Id == id))
        {
            return Result.NotFound($"Sku with id {id} not found");
        }

        return Result.NoContent();
    }
}
