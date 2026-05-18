using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
/// <summary>
/// リスト5-2 PRGパターンとTempDataの利用
/// </summary>
[Route("PRG")]
public class PRGController : Controller
{
    /// <summary>
    /// 入力画面を出力する
    /// </summary>
    /// <returns></returns>
    [HttpGet("Enter")]
    public IActionResult Enter()
    {
        var form = new PRGForm();
        return View(form);
    }

    /// <summary>
    /// [送信]ボタンクリック
    /// </summary>
    /// <param name="form">PRGForm</param>
    /// <returns></returns>
    [HttpPost("Result")]
    public IActionResult Result(PRGForm form)
    {
        // LoggerFactory を使って Logger を作成
        using var loggerFactory = LoggerFactory.Create(builder =>
        {
            builder.AddConsole(); // コンソール出力
        });
        ILogger logger = loggerFactory.CreateLogger("PRGController");
        // ログメッセージを表示する
        logger.LogInformation("[送信]ボタンクリック!!!");

        //　バリデーションチェック
        if (!ModelState.IsValid)
        {
            // バリデーションエラーの場合、入力画面を表示する
            return View("Enter", form);
        }
        form!.Length = form.Text?.Length ?? 0;
        return View(form);
        //TempData["PRGForm"] = JsonSerializer.Serialize(form);
        //return RedirectToAction("Result");
    }

    /// <summary>
    /// [戻る]ボタンクリックに対するアクション
    /// </summary>
    /// <returns></returns>
    [HttpGet("Back")]
    public IActionResult Back()
    {
        // 入力画面を出力するアクションメソッドにリダイレクトする
        return RedirectToAction("Enter");
    }
}