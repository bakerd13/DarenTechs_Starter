using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DarenTechs.Data.TreeData
{
    public class Tree
    {
        public Tree()
        {
            Children = new List<Tree>();
        }

        /// <summary>
        /// Gets or sets the Node Key
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// Gets or sets the Parent Identity
        /// </summary>
        public string ParentId { get; set; }

        /// <summary>
        /// Gets or sets Node Title
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets Urls for href
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// Gets or sets if this is a node or leaf
        /// </summary>
        public bool IsNode { get; set; }

        /// <summary>
        /// Gets or sets Collection of child Nodes
        /// </summary>
        public List<Tree> Children { get; set; }

        public int Count()
        {
            return Children.Count;
        }
    }
}
