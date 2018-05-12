using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DarenTechs.Data.TreeData
{
    public interface ITreeNodes<T>
    {

        /// <summary>
        /// Gets or sets the Node Key
        /// </summary>
        string Key { get; set; }

        /// <summary>
        /// Gets or sets the Parent Identity
        /// </summary>
        string ParentId { get; set; }

        /// <summary>
        /// Gets or sets Node Title
        /// </summary>
        string Title { get; set; }

        /// <summary>
        /// Gets or sets Urls for href
        /// </summary>
        string Url { get; set; }

    }
}
