using Ardalis.Result;

namespace Haseroz.DevKit.AspNetCore.SampleMinimalApi.Services;

public class HealthService
{
    public Result Maintenance()
    {
        return Result.Unavailable("Service temporarily unavailable due to maintenance.");
    }

    public Result Status()
    {
        return Result.CriticalError();
    }
}
