using MCDX.Web.Models;

namespace MCDX.Web.Services;

public interface IOperationsData
{
    OperationsDashboardViewModel GetDashboard(string activeSection, string title, string subtitle);
}

public sealed class SampleOperationsData : IOperationsData
{
    public OperationsDashboardViewModel GetDashboard(string activeSection, string title, string subtitle)
    {
        return new OperationsDashboardViewModel
        {
            ActiveSection = activeSection,
            PageTitle = title,
            PageSubtitle = subtitle,
            Sites =
            [
                new("阿久比", 92, 1, 2, "稼働中"),
                new("大安", 88, 2, 3, "稼働中"),
                new("善明", 90, 0, 1, "稼働中")
            ],
            Metrics =
            [
                new("全設備", "28", "台", "+3", "good"),
                new("稼働中", "22", "台", "79%", "good"),
                new("停止中", "2", "台", "7%", "warn"),
                new("アラーム", "1", "台", "要確認", "danger"),
                new("メンテ中", "3", "台", "11%", "neutral")
            ],
            Machines =
            [
                new("M/C 01", "OKK VM53R", "Aグループ", "稼働中", 92, 78, 86, "-", "08:45"),
                new("M/C 02", "MAKINO V56", "Aグループ", "稼働中", 87, 62, 91, "-", "08:45"),
                new("M/C 03", "FANUC ROBODRILL", "Bグループ", "アラーム", 0, 0, 18, "主軸異常 E101", "08:44"),
                new("M/C 04", "OKK VM43R", "Aグループ", "稼働中", 90, 81, 74, "-", "08:45"),
                new("M/C 05", "DMG MORI NVX5100", "Cグループ", "メンテ中", 0, 0, 35, "定期点検中", "08:30"),
                new("M/C 06", "OKUMA GENOS M560", "Dグループ", "稼働中", 93, 73, 88, "-", "08:45"),
                new("M/C 07", "MAZAK QTE-200", "Eグループ", "停止中", 0, 0, 42, "材料切れ", "07:55"),
                new("M/C 08", "DMG MORI CMX600", "Bグループ", "稼働中", 88, 65, 80, "-", "08:45")
            ],
            Tools =
            [
                new(1, "DLE05005050", "超硬ドリル", "ドリル", "TiAlN", "M/C 01", 78, 22, "良好", "2024/06/01"),
                new(2, "AE-VMS1000", "超硬エンドミル", "エンドミル", "AlTiN", "M/C 02", 87, 13, "良好", "2024/06/03"),
                new(3, "TNGG160408-MP", "旋削チップ", "旋削チップ", "PVD", "M/C 03", 92, 8, "寿命間近", "2024/05/29"),
                new(4, "DLE08008080", "超硬ドリル", "ドリル", "TiAlN", "M/C 04", 63, 37, "良好", "2024/06/10"),
                new(5, "EX-SFT-M10X1.5", "スパイラルタップ", "タップ", "TiCN", "M/C 05", 45, 55, "良好", "2024/06/18"),
                new(6, "AE-BD-R5.0", "超硬ボールエンドミル", "エンドミル", "AlTiN", "M/C 06", 96, 4, "異常摩耗", "2024/05/28"),
                new(7, "CMX45-1603", "面取りカッタ", "面取り", "TiN", "M/C 07", 12, 88, "良好", "2024/07/15"),
                new(8, "GDM4020N-020GM", "溝入れチップ", "溝入れ", "PVD", "M/C 08", 71, 29, "良好", "2024/06/05")
            ],
            BladeExchanges =
            [
                new(1, "AE-VMS1000", "超硬エンドミル 010", "エンドミル", "M/C 02", 87, 13, "交換推奨", "2024/06/03", "2024/06/05"),
                new(2, "DLE05005050", "超硬ドリル 05.0", "ドリル", "M/C 01", 78, 22, "良好", "2024/06/01", "2024/06/02"),
                new(3, "TNGG160408-MP", "旋削チップ", "旋削チップ", "M/C 03", 92, 8, "寿命間近", "2024/05/29", "2024/05/30"),
                new(4, "EX-SFT-M10X1.5", "スパイラルタップ", "タップ", "M/C 05", 45, 55, "良好", "2024/06/18", "2024/06/20"),
                new(5, "GDM4020N-020GM", "溝入れチップ", "溝入れ", "M/C 08", 71, 29, "良好", "2024/06/05", "2024/06/07"),
                new(6, "AE-BD-R5.0", "超硬ボールエンドミル", "エンドミル", "M/C 06", 96, 4, "異常摩耗", "2024/05/28", "2024/05/28")
            ]
        };
    }
}
