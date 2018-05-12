using DarenTechs.Data.TreeData;

namespace DarenTechs.Blog.ViewModels
{
    public class Posts : ITreeNodes<Posts>
    {
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


    }
}
