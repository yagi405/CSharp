using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComboBoxSample
{
    /// <summary>
    /// 個々のアイテムを格納するクラス
    /// </summary>
    internal class SampleItem
    {
        /// <summary>
        /// サンプルアイテムのId
        /// </summary>
        public int SampleItemId { get; set; }

        /// <summary>
        /// サンプルアイテムのName
        /// </summary>
        public string? SampleItemName { get; set; }
    }
}
