// See https://aka.ms/new-console-template for more information
using DekigataModels;
using DekigataSample;
using Newtonsoft.Json;
using System.Configuration;
using System.Diagnostics;

Console.WriteLine("Hello, World!");

var endpointUri = ConfigurationManager.AppSettings["EndpointUri"];
var primaryKey = ConfigurationManager.AppSettings["PrimaryKey"];
if (string.IsNullOrEmpty(endpointUri) || string.IsNullOrEmpty(primaryKey))
    throw new Exception("アプリケーション設定を見直して下さい。");

var context = await DekigataCosmosDbContext.CreateAsync(endpointUri, primaryKey);
await context.GetKoshuContainerAsync();
await context.GetMeasurementItemAsync();
await context.GetMeasurementPointtContainerAsync();
await context.GetMeasurementValueContainerAsync();

var kojiId = "koji-1";

// データを追加
var sampleData = new SampleData(kojiId);
//await AddDataHelper.ExecuteAsync(context, sampleData);
var koshuId = sampleData.Koshus[0].Id;

// データを取得
var dataFromDb = await GetKoshuHelper.ExecuteAsync(context, kojiId, koshuId);
Console.WriteLine(JsonConvert.SerializeObject(dataFromDb, Formatting.Indented));

// データを変更 (Update)
//await UpdateKoshuHelper.ExecuteAsync(context, kojiId, koshuId, "hoge");
//await UpdateKoshuHelper.ExecuteAsync(context, kojiId, koshuId, null);

// データを変更 (Patch)
await PatchKoshuHelper.ExecuteAsync(context, kojiId, koshuId, "hoge");
//await PatchKoshuHelper.ExecuteAsync(context, kojiId, koshuId, null);

// データを削除
//await DeleteKoshuHelper.ExecuteAsync(context, kojiId, koshuId);

Console.WriteLine("Success.");