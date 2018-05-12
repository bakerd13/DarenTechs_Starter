using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DarenTechs.Data.TreeData
{
    public class TreeNodes<T> where T : ITreeNodes<T>
    {
        public Tree GenerateTreeNodes(IList<T> treeData)
        {
            var root = GetRootData(treeData);
            
            AddNodes(root, treeData);
            UpdateNodes(root);
            return root;
        }

        private Tree GetRootData(IList<T> treeData)
        {
            var rootData = treeData.Where(n => n.ParentId == string.Empty).FirstOrDefault();

            return rootData != null ? new Tree()
            {
                Key = rootData.Key,
                Title = rootData.Title,
                ParentId = rootData.ParentId,
                Url = rootData.Url,
                IsNode = true
            } : new Tree()
            {
                Key = null,
                Title = "Root",
                ParentId = string.Empty,
                Url = "#",
                IsNode = true
            };
        }

        private Tree AddNodes(Tree rootNode, IList<T> treeData)
        {
            var current = treeData.Where(o => o.ParentId == rootNode.Key);
            foreach (var item in current)
            {
                var child = new Tree()
                {
                    Key = item.Key,
                    Title = item.Title,
                    ParentId = item.ParentId,
                    Url = item.Url ?? "#"
                };
                rootNode.Children.Add(child);
                AddNodes(child, treeData);
            }
            return rootNode;
        }

        private Tree UpdateNodes(Tree rootNode)
        {

            foreach (var child in rootNode.Children)
            {
                if (child.Children.Any())
                {
                    child.IsNode = true;
                }
                UpdateNodes(child);
            }
            return rootNode;
        }
    }
}
