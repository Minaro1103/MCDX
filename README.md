# MCDX Web App

工場設備・工具・刃具交換を管理する ASP.NET Core MVC のサンプルアプリです。Visual Studio で `MCDX.sln` を開いて編集できます。

## 起動方法

```powershell
dotnet run --project .\MCDX.Web\MCDX.Web.csproj --urls http://localhost:5178
```

ブラウザで `http://localhost:5178` を開きます。

## 画面

- ダッシュボード
- 設備一覧
- 工具一覧 / 刃物リスト
- 刃具交換リスト
- 負荷サマリ

## 仮データ

現在は [SampleOperationsData.cs](MCDX.Web/Services/SampleOperationsData.cs) に固定値を入れています。
Oracle Database と接続する段階では、`IOperationsData` を実装する Oracle 用サービスを追加し、`Program.cs` の DI 登録を差し替えてください。

接続文字列の仮置き場は [appsettings.json](MCDX.Web/appsettings.json) の `ConnectionStrings:Oracle` です。

## IIS 配置

Visual Studio の発行機能、または以下のコマンドで発行できます。

```powershell
dotnet publish .\MCDX.Web\MCDX.Web.csproj -c Release -o .\publish
```

IIS では .NET 8 Hosting Bundle を入れた上で、発行先フォルダをサイトの物理パスに指定してください。
