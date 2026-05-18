using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

public class UserForm
{
    [Required(ErrorMessage = "氏名は入力必須です。")]
    public string? Name { get; set; } = string.Empty;
    [Required(ErrorMessage = "年齢は入力必須です。")]
    [Range(1, 100, ErrorMessage = "年齢は1～100の範囲で入力してください。")]
    public int Age { get; set; } = 0;
    [Required(ErrorMessage = "メールアドレスは入力必須です。")]
    [EmailAddress(ErrorMessage = "メールアドレスの形式で入力してください。")]
    public string? Email { get; set; } = string.Empty;
    [Required(ErrorMessage = "電話番号は入力必須です。")]
    [RegularExpression(@"^0\d{1,4}-\d{1,4}-\d{4}$", ErrorMessage = "電話番号の形式（例: 03-1234-5678）で入力してください。")]
    public string? Phone { get; set; } = string.Empty;
}