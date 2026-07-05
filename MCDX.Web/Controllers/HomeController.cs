using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MCDX.Web.Models;
using MCDX.Web.Services;

namespace MCDX.Web.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IOperationsData _operationsData;

    public HomeController(ILogger<HomeController> logger, IOperationsData operationsData)
    {
        _logger = logger;
        _operationsData = operationsData;
    }

    public IActionResult Index()
    {
        return View("Index", _operationsData.GetDashboard("Dashboard", "ダッシュボード", "こんにちは、山田さん！ 今日の設備状況を確認できます。"));
    }

    public IActionResult Facilities()
    {
        return View("Index", _operationsData.GetDashboard("Facilities", "設備一覧（阿久比）", "設備ごとの稼働率、負荷、アラームを一覧表示します。"));
    }

    public IActionResult Tools()
    {
        return View("Index", _operationsData.GetDashboard("Tools", "工具一覧（阿久比）", "工具寿命、在庫、交換予定を確認できます。"));
    }

    public IActionResult BladeExchange()
    {
        return View("Index", _operationsData.GetDashboard("BladeExchange", "刃具交換リスト", "バーコード読み取りと交換アラートを使う想定の画面です。"));
    }

    public IActionResult WorkLogs()
    {
        return View("Index", _operationsData.GetDashboard("WorkLogs", "作業記録", "作業履歴、点検記録、申し送りを確認する画面です。"));
    }

    public IActionResult LoadSummary()
    {
        return View("Index", _operationsData.GetDashboard("LoadSummary", "負荷サマリ（阿久比）", "設備負荷と作業予測をダッシュボード形式で表示します。"));
    }

    public IActionResult Ranking()
    {
        return View("Index", _operationsData.GetDashboard("Ranking", "ランキング", "作業スコア、改善提案、設備稼働のランキングを表示します。"));
    }

    public IActionResult Settings()
    {
        return View("Index", _operationsData.GetDashboard("Settings", "設定", "サイト、設備、権限、通知条件などを管理します。"));
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
