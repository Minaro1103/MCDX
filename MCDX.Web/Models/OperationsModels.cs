namespace MCDX.Web.Models;

public sealed record SiteStatus(string Name, int OperationRate, int Alarms, int Stopped, string State);

public sealed record MachineStatus(
    string Code,
    string Maker,
    string Group,
    string Status,
    int OperationRate,
    int LoadRate,
    int Forecast,
    string Alert,
    string LastUpdate);

public sealed record ToolItem(
    int No,
    string Code,
    string Name,
    string Category,
    string Coating,
    string Machine,
    int LifeRate,
    int Remaining,
    string Status,
    string NextChange);

public sealed record BladeExchangeItem(
    int No,
    string Code,
    string Name,
    string Type,
    string Machine,
    int LifeRate,
    int Remaining,
    string Status,
    string ChangeDate,
    string NextPlan);

public sealed record SummaryMetric(string Label, string Value, string Unit, string Delta, string Tone);

public sealed class OperationsDashboardViewModel
{
    public IReadOnlyList<SiteStatus> Sites { get; init; } = [];
    public IReadOnlyList<MachineStatus> Machines { get; init; } = [];
    public IReadOnlyList<ToolItem> Tools { get; init; } = [];
    public IReadOnlyList<BladeExchangeItem> BladeExchanges { get; init; } = [];
    public IReadOnlyList<SummaryMetric> Metrics { get; init; } = [];
    public string ActiveSection { get; init; } = "Dashboard";
    public string PageTitle { get; init; } = "ダッシュボード";
    public string PageSubtitle { get; init; } = "阿久比工場 / 本日 08:45 更新";
}
