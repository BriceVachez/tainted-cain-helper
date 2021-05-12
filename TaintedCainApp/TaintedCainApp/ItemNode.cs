using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaintedCainApp
{
    public class ItemNode
    {
        private ItemNode parent;

        private List<ItemNode> children;

        public List<ItemNode> Children { get => children; }

        private int itemId;
        public int ItemId { get => itemId; }

        private Recipe recipe;
        public Recipe Recipe { get => recipe; }

        public ItemNode(ItemNode _parent, int _itemId, Recipe _recipe)
        {
            parent = _parent;
            itemId = _itemId;
            recipe = _recipe;

            children = new List<ItemNode>();
        }

        public void AddChild(ItemNode child)
        {
            children.Add(child);
        }

        public int CountLeaf()
        {
            if (IsLeaf())
            {
                return 1;
            }

            int count = 0;
            foreach (ItemNode child in children)
            {
                count += child.CountLeaf();
            }
            return count;
        }

        public bool IsLeaf()
        {
            return children.Count == 0;
        }
    }
}
