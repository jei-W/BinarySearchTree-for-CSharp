using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTree
{
    class BinarySearchTree
    {
        public Node rootNode = null;

        public void Insert( int value )
        {
            Node newNode = new Node(value);

            //첫 삽입에 root node가 null이면 루트 노드를 생성한다
            if( rootNode == null )
            {
                rootNode = newNode;
                return;
            }

            try
            {
                Node parentNode = FindParentNodeForInsert(rootNode);

                // 새로운 노드의 부모 셋팅
                newNode.SetParents(parentNode);

                if( parentNode < newNode )
                    parentNode.SetRight(newNode);
                else
                    parentNode.SetLeft(newNode);
            }
            catch( Exception e )
            {
                Console.WriteLine(e.Message);
            }

            Node FindParentNodeForInsert( Node currentNode )
            {
                if( newNode < currentNode )
                {
                    if( currentNode.GetLeft() == null )
                    {
                        return currentNode;
                    }
                    else
                    {
                        return FindParentNodeForInsert(currentNode.GetLeft());
                    }
                }
                else if( newNode > currentNode )
                {
                    if( currentNode.GetRight() == null )
                    {
                        return currentNode;
                    }
                    else
                    {
                        return FindParentNodeForInsert(currentNode.GetRight());
                    }
                }

                else throw new Exception("이미 저장된 데이터와 같은 값의 데이터는 저장할 수 없습니다.");
            }
        }

        public void Remove( int value )
        {
            Node removeNode = Find(value);
            if( removeNode == null )
                return;

            Node parentNode = removeNode.GetParent();
                        
            bool isRightNode = parentNode.GetRight() == removeNode;

            // 2가지를 더해야한다.
            // 왼쪽의 가장 큰노드로 대체햇을 때, 
            // 그 대체노드의 왼쪽 자식의 부모는 대체노드의 부모로 변경해줘야 한다
            // 부모노드일때, 1-1 한쪽이 없으면, 반대쪽이 바로 루트노드, 1-2 둘다 있으면 왼쪽에 가장 큰 노드로 대체
            
            if( removeNode.GetLeft() == null )
            {
                if( removeNode.GetRight() == null )
                {
                    if( isRightNode )
                        parentNode.SetRight(null);
                    else
                        parentNode.SetLeft(null);
                }
                else
                {
                    // 대체해야할 노드를 찾는다.
                    var replaceNode = FindSmallestAtRightside(removeNode.GetRight());

                    // 대체해야할 노드의 부모를, removeNode의 부모로 변경!
                    replaceNode.SetParents(parentNode);

                    // parentNode의 자식을 removeNode가 아닌, replaceNode로 교체한다!
                    if( isRightNode )
                    {
                        parentNode.SetRight(replaceNode);
                    }
                    else
                    {
                        parentNode.SetLeft(replaceNode);
                    }
                }
            }
            else
            {
                var replaceNode = FindBiggestAtLeftside(removeNode.GetLeft());

                if ( removeNode.GetRight() != null )
                {
                    // removenode의 오른쪽 자식은 무조건 없다.
                    // 왼쪽 사이드에선 가장 큰값이니깐.
                    replaceNode.SetRight(removeNode.GetRight());
                    removeNode.GetRight().SetParents(replaceNode);
                }

                replaceNode.SetParents(parentNode);

                if( isRightNode )
                {
                    parentNode.SetRight(replaceNode);
                }
                else
                {
                    parentNode.SetLeft(replaceNode);
                }
            }

            Node FindBiggestAtLeftside(Node currentPosition)
            {
                if( currentPosition.GetRight() == null )
                {
                    if( currentPosition.GetLeft() == null )
                        return currentPosition;
                    else
                        return FindBiggestAtLeftside(currentPosition.GetLeft());
                }
                else
                    return FindBiggestAtLeftside(currentPosition.GetRight());
            }

            Node FindSmallestAtRightside( Node currentPosition )
            {
                if( currentPosition.GetLeft() == null )
                {
                    if( currentPosition.GetRight() == null )
                        return currentPosition;
                    else
                        return FindSmallestAtRightside(currentPosition.GetRight());
                }
                else
                    return FindSmallestAtRightside(currentPosition.GetLeft());
            }
        }

        //전위순회 중-왼-오
        public void PreorderTraversal(Node currentNode)
        {
            if( rootNode == null )
            {
                Console.WriteLine("빈 트리 입니다.");
                return;
            }

            // 나를 출력한다. 
            Console.Write($"{currentNode.GetValue()} ");

            if( currentNode.GetLeft() != null )
            {
                PreorderTraversal(currentNode.GetLeft());
            }

            if( currentNode.GetRight() != null )
            {
                PreorderTraversal(currentNode.GetRight());
            }
        }


        //중위순회 왼-중-오
        public void InorderTraversal( Node currentNode )
        {
            if( rootNode == null )
            {
                Console.WriteLine("빈 트리 입니다.");
                return;
            }

            if( currentNode.GetLeft() != null )
            {
                InorderTraversal(currentNode.GetLeft());
            }

            Console.Write($"{currentNode.GetValue()} ");

            if( currentNode.GetRight() != null )
            {
                InorderTraversal(currentNode.GetRight());
            }
        }


        //후위순회 왼-오-중
        public void PostorderTraversal( Node currentNode )
        {
            if( rootNode == null )
            {
                Console.WriteLine("빈 트리 입니다.");
                return;
            }

            if( currentNode.GetLeft() != null )
            {
                PostorderTraversal(currentNode.GetLeft());
            }

            if( currentNode.GetRight() != null )
            {
                PostorderTraversal(currentNode.GetRight());
            }

            Console.Write($"{currentNode.GetValue()} ");
        }



        Node Find( int value )
        {
            Node currentNode = rootNode;
            return FindNode();


            Node FindNode()
            {
                if( currentNode == value )
                {
                    return currentNode;
                }
                else
                {
                    if( currentNode > value )
                    {
                        currentNode = currentNode.GetLeft();
                        return FindNode();
                    }
                    else
                    {
                        currentNode = currentNode.GetRight();
                        return FindNode();
                    }
                }
            }
        }
    }
}
