using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
/// <summary>
/// リクエストパラメータの型変換エラー
/// </summary>
[Route("TypeError")]
public class TypeConversionErrorController : Controller
{
    /// <summary>
    /// リクエストパラメータを出力
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("Params")]
    public IActionResult RequestParameter(int id)
    {
        // 型変換エラー?
        if (!ModelState.IsValid)
        {
            // エラーメッセージを出力する
            // パラメータ名をキーにしてErrors配列にアクセスする
            return Content(ModelState["id"]!.Errors[0].ErrorMessage);
        }
        return Content($"リクエストパラメータ:{id}");
    }
}