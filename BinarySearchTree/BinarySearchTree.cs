using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTree
{
    class BinarySearchTree
    {
        Node rootNode = null;

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

        void Remove( int value )
        {
            Node removePosition = Find(value);

            if( removePosition.GetLeft() == null )
            {
                if( removePosition.GetRight() == null )
                    removePosition = null;

                else
                {
                    removePosition = FindSmallestAtRightside(removePosition.GetRight());
                }
            }

            else
                removePosition = FindBiggestAtLeftside(removePosition.GetLeft());


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

        void Print()
        {

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
