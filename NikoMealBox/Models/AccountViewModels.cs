﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;

namespace NikoMealBox.Models
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "電子郵件")]
        public string Email { get; set; }
    }

    public class ExternalLoginListViewModel
    {
        public string ReturnUrl { get; set; }
    }

    public class SendCodeViewModel
    {
        public string SelectedProvider { get; set; }
        public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
        public string ReturnUrl { get; set; }
        public bool RememberMe { get; set; }
    }

    public class VerifyCodeViewModel
    {
        [Required]
        public string Provider { get; set; }

        [Required]
        [Display(Name = "代碼")]
        public string Code { get; set; }
        public string ReturnUrl { get; set; }

        [Display(Name = "記住此瀏覽器?")]
        public bool RememberBrowser { get; set; }

        public bool RememberMe { get; set; }
    }

    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "電子郵件")]
        public string Email { get; set; }
    }

    public class LoginViewModel
    {
        [Required]
        [Display(Name = "電子郵件")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "密碼")]
        public string Password { get; set; }

        [Display(Name = "記住我?")]
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel
    {
        [Required(ErrorMessage = "請輸入Email")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        [Display(Name = "電子郵件")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "{0} 的長度至少必須為 {2} 個字元。", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "密碼")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "確認密碼")]
        [Compare("Password", ErrorMessage = "密碼和確認密碼不相符。")]
        public string ConfirmPassword { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "最少須3個字元")]
        [Display(Name = "姓名")]
        public string Name { get; set; }
        [Required]
        [RegularExpression(@"^\d{4}\-?\d{3}\-?\d{3}$", ErrorMessage = "需為09xx-xxx-xxx")]
        [Display(Name = "行動號碼")]
        public string Mobile { get; set; }
        [Display(Name = "身高")]
        public int Height { get; set; }
        [Display(Name = "體重")]
        public decimal Weight { get; set; }
        [Display(Name = "性別")]
        public string Gender { get; set; }
        [Display(Name = "出生日期")]
        [DataType(DataType.Date)]
        public DateTime Birthday { get; set; }
        [Display(Name = "住址")]
        public string Address { get; set; }
    }

    public class ResetPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "電子郵件")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "{0} 的長度至少必須為 {2} 個字元。", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "密碼")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "確認密碼")]
        [Compare("Password", ErrorMessage = "密碼和確認密碼不相符。")]
        public string ConfirmPassword { get; set; }

        public string Code { get; set; }
    }

    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "電子郵件")]
        public string Email { get; set; }
    }

    public class MemberCenterViewModel
    {
        public string Name { get; set; }
        public string Mobile { get; set; }
        public int Height { get; set; }

        public decimal Weight { get; set; }

        public string Gender { get; set; }

        public DateTime Birthday { get; set; }

        public string Address { get; set; }
    }
    public class MemeberCenterViewModel
    {
        public string Name { get; set; }
        public string Mobile { get; set; }
        public int Height { get; set; }

        public decimal Weight { get; set; }
        public string Address { get; set; }
    }



}
