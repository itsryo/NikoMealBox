using NikoMealBox.Models.DataTable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NikoMealBox.Models
{
    public class ECPay:BaseEntity
    {
        /// <summary>
        /// 特店交易編號
        /// </summary>
        public string MerchantTradeNo { get; set; }

        /// <summary>
        /// 特店交易時間
        /// </summary>
        public string MerchantTradeDate { get; set; }

        /// <summary>
        /// 交易金額
        /// </summary>
        public decimal TotalAmount { get; set; }

        /// <summary>
        /// 交易描述
        /// </summary>
        public string TradeDesc { get; set; }

        /// <summary>
        /// 商品名稱
        /// </summary>
        public string ItemName { get; set; }

        /// <summary>
        /// 選擇預設付款方式
        /// </summary>
        public string ChoosePayment { get; set; }

        /// <summary>
        /// 檢查碼
        /// </summary>
        public string CheckMacValue { get; set; }

        /// <summary>
        /// 屬於那張訂單
        /// </summary>
        public int OrderRefId { get; set; }
    }
}