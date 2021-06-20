using System.Collections.Generic;

namespace Infrastructure.Common.Tree
{
    /// <summary>
    /// 描 述：树结构数据
    /// </summary>
    public class TreeModel
    {
        /// <summary>
        /// 节点id
        /// </summary>
        public string id { get; set; }
        /// <summary>
        /// 父级节点ID
        /// </summary>
        public string pid { get; set; }
        /// <summary>
        /// 节点显示数据
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 排序字段
        /// </summary>
        public int sort { get; set; }
        /// <summary>
        /// 子节点列表数据
        /// </summary>
        public List<TreeModel> children { get; set; }
        
    }
}
