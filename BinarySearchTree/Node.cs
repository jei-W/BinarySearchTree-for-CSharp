using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTree
{
    class Node
    {
        Node parents = null;
        Node left = null;
        Node right = null;       

        int value;

        public Node()
        {
        }

        public Node( int value )
        {
            this.value = value;
        }

        public Node GetLeft()
        {
            return left;
        }

        public Node GetRight()
        {
            return right;
        }

        public void SetLeft( Node node )
        {
            left = node;
        }

        public void SetRight( Node node )
        {
            right = node;
        }

        public void SetParents(Node node)
        {
            parents = node;
            return;
        }

        // operator의 오버로딩 : 연산 가능하게 추가
        #region operator
        public static bool operator <( Node lhs, Node rhs )
        {
            return lhs.value < rhs.value;
        }

        public static bool operator >( Node lhs, Node rhs )
        {
            return lhs.value > rhs.value;
        }

        public static bool operator <( Node lhs, int rhs )
        {
            return lhs.value < rhs;
        }

        public static bool operator >( Node lhs, int rhs )
        {
            return lhs.value > rhs;
        }

        public static bool operator ==( Node lhs, int rhs )
        {
            return lhs.value == rhs;
        }

        public static bool operator !=( Node lhs, int rhs )
        {
            return lhs.value == rhs;
        }
        #endregion
    }
}
